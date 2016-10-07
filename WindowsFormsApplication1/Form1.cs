using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

using System.Net.Sockets;
using System.Threading;
using WebSocketSharp;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int _inputs;
        private int _input1;
        private int _input2;
        private int _input3;
        private int _input4;
        private int _input5;
        private int _input6;
        private int _input7;
        private int _input8;
        private int _input9;
        private int _input10;
        private int _input11;
        private int _input12;
        private int _Outputs;
        private int _Outputs1;
        private int _Outputs2;
        private int _Outputs3;
        private int _Outputs4;
        private int _Outputs5;
        private int _Outputs6;
        private int _Outputs7;
        private int _Outputs8;
        private int _Outputs9;
        private int _Outputs10;
        private int _Outputs11;
        private int _Outputs12;
        private double _Location1;
        private double _Location2;
        private double _Location3;
        private double _Location4;
        private double _Location5;
        private double _Location6;
        private double Loc1;
        private double Loc2;
        private double Loc3;
        private double Loc4;
        private double Loc5;
        private double Loc6;
        private int OutputS;
        private int inputS;
        private int Status;
        private double Analog11;
        private double Analog22;
        private double _analog1;
        private double _analog2;
        private int _Status;
        private bool _FileRunning;
        private bool _Mode;
        private bool _KeyPad;
        private bool _PauseInFile;
        private bool _StopInFile;
        private bool _inStack;
        private System.Timers.Timer tmr;
        private System.Timers.Timer cmmdtmr;
        private int runCount;
        private string currentCommand;
        private ArrayList commandList;
        private ArrayList commandQueue;
        //private ArrayList commandQueue;

        TcpClient tcpClient = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = string.Empty;
        string msg = "Conected to Server ...";
        Random rnd = new Random();

        public Form1(){
            InitializeComponent();
            commandList = new ArrayList();
            commandQueue = new ArrayList();

            int counter = 0;
            string line;

            System.IO.StreamReader file = new StreamReader("drawing.sbp");
            while ((line = file.ReadLine()) != null)
            {
                commandList.Add(line);
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.ReadLine();
            System.Diagnostics.Debug.WriteLine(commandList);

            runCount = 0;
            System.Diagnostics.Debug.WriteLine("Shopbot position:" + readX() + "," + readY() + "," + readZ());

            tmr = new System.Timers.Timer();
            tmr.Interval = 50;
            Timer_Enable = true;
            tmr.Start();

            cmmdtmr = new System.Timers.Timer();
            cmmdtmr.Interval = 100;
            cmmdtmr.Elapsed += new ElapsedEventHandler(runCommand);
            cmmdtmr.Enabled = true;
            connectToServer();
        }


        // Purpose:     Connect to node.js application
        // End Result:  node.js app now has a socket open that can send
        //              messages back to this tcp client application
        private void connectToServer()
        {
            var ws = new WebSocket("ws://pure-beach-75578.herokuapp.com/", "desktop_client");
            ws.OnMessage += (sender, e) =>
            {
                Console.WriteLine("server says: " + e.Data);
                if (e.Data[0] == '{')
                {

                    var jsonObject = JToken.Parse(e.Data);
                    var gcodeArray = jsonObject.Children<JProperty>().FirstOrDefault(x => x.Name == "data").Value as JArray;

                    var fileName = "line_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".sbp";
                    commandQueue.Add(fileName);
                    var file = new StreamWriter(@fileName);
                        foreach (var item in gcodeArray.Children<JValue>())
                        {
                            Console.WriteLine("gcode line: " + item.ToString());
                            file.WriteLine(item.ToString());


                        }
                    file.Close();

                    cmmdtmr.Start();
                   
                    Console.WriteLine("cmmdtmr.enabled" + cmmdtmr.Enabled);
                }
                else
                {
                    Console.WriteLine("not JSON:", e.Data);
                }
            };
            ws.OnClose += (sender, e) =>
            {
                Console.WriteLine("web socket closed" + e.Code);

            };
            ws.OnOpen += (sender, e) =>
            {
                Console.WriteLine("web socket opened" + e);

            };
            ws.Connect();

            ws.Send("{\"name\":\"desktop_client\"}");


        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            //this.status_out.Text = Conversions.ToString(readStatus());
            //this.x_out.Text = Conversions.ToString(readX());
            //this.y_out.Text = Conversions.ToString(readY());
           // this.z_out.Text = Conversions.ToString(readZ());
            if ((this.Status & 32) == 32)
            {
                //System.Diagnostics.Debug.WriteLine("stack is running");

            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("stack is NOT running");

            }
        }


        public bool Timer_Enable
        {
            get
            {
                return this.tmr.Enabled;
            }
            set
            {
                this.tmr.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                this.tmr.Enabled = value;
            }
        }

        public double Timer_Interval
        {
            get
            {
                return this.tmr.Interval;
            }
            set
            {
                this.tmr.Interval = value;
            }
        }

        private int readStatus()
        {
            //  this.Status = rnd.Next(0, 32);
            this.Status = Conversions.ToInteger(Interaction.GetSetting("ShopBot", "UserData", "Status", Conversions.ToString(1)));
            return this.Status;
        }

        private int readSpeed()
        {
            return Conversions.ToInteger(Interaction.GetSetting("ShopBot", "UserData", "VS", Conversions.ToString(1)));

        }

        private Double readX()
        {
            return Conversions.ToDouble(Interaction.GetSetting("ShopBot", "UserData", "Loc_1", Conversions.ToString(0)));
        }
        private Double readY()
        {
            return Conversions.ToDouble(Interaction.GetSetting("ShopBot", "UserData", "Loc_2", Conversions.ToString(0)));
        }

        private Double readZ()
        {
            return Conversions.ToDouble(Interaction.GetSetting("ShopBot", "UserData", "Loc_3", Conversions.ToString(0)));
        }

        private void sendCommand(String command)
        {
            Interaction.SaveSetting("ShopBot", "UserData", "uCommand", command);
        }


        private void command_Click(object sender, EventArgs e)
        {
            cmmdtmr.Start();
            Console.WriteLine("command click called");

        }

        private void runCommand(object sender, System.Timers.ElapsedEventArgs e)
        {

            Console.WriteLine("command queue count"+commandQueue.Count);
            if (commandQueue.Count > 0)
            {
                this.readStatus();
                if (this.Status == 0)
                {
                    //outputField.Text = "sending command to shopbot:" + commandQueue.Count + ":" + this.Status;
                    var command = "FP, " + commandQueue[0] + ", 1, 1, 1, 1, 0, -0.00, 0, 0, 1, 1";
                    this.sendCommand(command);
                   //s this.command_entry.Text = command;
                    this.Status = -1;
                    commandQueue.RemoveAt(0);
                    //Thread.Sleep(50);
                }
                else
                {
                    //outputField.Text = "status down:" + this.Status;

                }


            }
            else
            {
                cmmdtmr.Stop();
            }



        }

        private void go_Click(object sender, EventArgs e)
        {

        }
    }
}


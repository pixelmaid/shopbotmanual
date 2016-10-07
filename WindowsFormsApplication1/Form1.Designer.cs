namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.command = new System.Windows.Forms.Button();
            this.command_entry = new System.Windows.Forms.TextBox();
            this.x_out = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.y_out = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.z_out = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.status_out = new System.Windows.Forms.TextBox();
            this.go = new System.Windows.Forms.Button();
            this.outputField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(41, 243);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(129, 42);
            this.command.TabIndex = 0;
            this.command.Text = "Send Command";
            this.command.UseVisualStyleBackColor = true;
            this.command.Click += new System.EventHandler(this.command_Click);
            // 
            // command_entry
            // 
            this.command_entry.Location = new System.Drawing.Point(41, 204);
            this.command_entry.Name = "command_entry";
            this.command_entry.Size = new System.Drawing.Size(236, 22);
            this.command_entry.TabIndex = 1;
            // 
            // x_out
            // 
            this.x_out.Location = new System.Drawing.Point(114, 66);
            this.x_out.Name = "x_out";
            this.x_out.Size = new System.Drawing.Size(53, 22);
            this.x_out.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "X position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y position";
            // 
            // y_out
            // 
            this.y_out.Location = new System.Drawing.Point(114, 104);
            this.y_out.Name = "y_out";
            this.y_out.Size = new System.Drawing.Size(53, 22);
            this.y_out.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z position";
            // 
            // z_out
            // 
            this.z_out.Location = new System.Drawing.Point(114, 144);
            this.z_out.Name = "z_out";
            this.z_out.Size = new System.Drawing.Size(53, 22);
            this.z_out.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status";
            // 
            // status_out
            // 
            this.status_out.Location = new System.Drawing.Point(114, 27);
            this.status_out.Name = "status_out";
            this.status_out.Size = new System.Drawing.Size(53, 22);
            this.status_out.TabIndex = 8;
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(223, 143);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(75, 23);
            this.go.TabIndex = 11;
            this.go.Text = "go";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // outputField
            // 
            this.outputField.Location = new System.Drawing.Point(41, 309);
            this.outputField.Multiline = true;
            this.outputField.Name = "outputField";
            this.outputField.Size = new System.Drawing.Size(305, 105);
            this.outputField.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(462, 444);
            this.Controls.Add(this.outputField);
            this.Controls.Add(this.go);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.status_out);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.z_out);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.y_out);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.x_out);
            this.Controls.Add(this.command_entry);
            this.Controls.Add(this.command);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ShopbotProxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button command;
        private System.Windows.Forms.TextBox command_entry;
        private System.Windows.Forms.TextBox x_out;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox y_out;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox z_out;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox status_out;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.TextBox outputField;
    }
}


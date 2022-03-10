
namespace MAT_script_runner
{
    partial class MAT_Script_Runner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_TCPIP_Connection = new System.Windows.Forms.Button();
            this.Button_Bluetooth_Connection = new System.Windows.Forms.Button();
            this.Panel_Home = new System.Windows.Forms.Panel();
            this.Panel_Connection = new System.Windows.Forms.Panel();
            this.Button_Start_Bluetooth_Connection = new System.Windows.Forms.Button();
            this.Form2_Back_Button = new System.Windows.Forms.Button();
            this.Button_Filename_Formatting = new System.Windows.Forms.Button();
            this.Button_Open_Folders = new System.Windows.Forms.Button();
            this.Button_Directory_Settings = new System.Windows.Forms.Button();
            this.Panel_Controls = new System.Windows.Forms.Panel();
            this.Checkbox_Voice = new System.Windows.Forms.CheckBox();
            this.Checkbox_Plot_Mode = new System.Windows.Forms.CheckBox();
            this.Checkbox_Auto_Execute = new System.Windows.Forms.CheckBox();
            this.Checkbox_Auto_Increment = new System.Windows.Forms.CheckBox();
            this.Numeric_Quick_Trial = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.COM_Port_Label = new System.Windows.Forms.Label();
            this.Numeric_COM_Port = new System.Windows.Forms.NumericUpDown();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Timer_Receive_Samples = new System.Windows.Forms.Timer(this.components);
            this.Panel_Settings = new System.Windows.Forms.Panel();
<<<<<<< HEAD
<<<<<<< HEAD
            this.Panel_Status = new System.Windows.Forms.Panel();
            this.Panel_Bluetooth = new System.Windows.Forms.Panel();
            this.Panel_TCP = new System.Windows.Forms.Panel();
            this.Textbox_IP = new System.Windows.Forms.TextBox();
            this.Label_IP = new System.Windows.Forms.Label();
            this.Label_Port = new System.Windows.Forms.Label();
            this.Numeric_Port = new System.Windows.Forms.NumericUpDown();
<<<<<<< HEAD
            this.Background_TCP = new System.ComponentModel.BackgroundWorker();
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
            this.Panel_Home.SuspendLayout();
            this.Panel_Connection.SuspendLayout();
            this.Panel_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Quick_Trial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_COM_Port)).BeginInit();
            this.Panel_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_TCPIP_Connection
            // 
            this.Button_TCPIP_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_TCPIP_Connection.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_TCPIP_Connection.Location = new System.Drawing.Point(0, 0);
            this.Button_TCPIP_Connection.Name = "Button_TCPIP_Connection";
            this.Button_TCPIP_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_TCPIP_Connection.TabIndex = 0;
            this.Button_TCPIP_Connection.Text = "TCPIP Connection";
            this.Button_TCPIP_Connection.UseVisualStyleBackColor = true;
            this.Button_TCPIP_Connection.Click += new System.EventHandler(this.Button_TCPIP_Connection_Click);
            // 
            // Button_Bluetooth_Connection
            // 
            this.Button_Bluetooth_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Bluetooth_Connection.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Bluetooth_Connection.Location = new System.Drawing.Point(0, 80);
            this.Button_Bluetooth_Connection.Name = "Button_Bluetooth_Connection";
            this.Button_Bluetooth_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_Bluetooth_Connection.TabIndex = 1;
            this.Button_Bluetooth_Connection.Text = "Bluetooth Connection";
            this.Button_Bluetooth_Connection.UseVisualStyleBackColor = true;
            this.Button_Bluetooth_Connection.Click += new System.EventHandler(this.Button_Bluetooth_Connection_Click);
            // 
            // Panel_Home
            // 
            this.Panel_Home.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Home.Controls.Add(this.Button_Bluetooth_Connection);
            this.Panel_Home.Controls.Add(this.Button_TCPIP_Connection);
            this.Panel_Home.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Home.Location = new System.Drawing.Point(0, 251);
            this.Panel_Home.Name = "Panel_Home";
            this.Panel_Home.Size = new System.Drawing.Size(384, 160);
            this.Panel_Home.TabIndex = 3;
            // 
            // Panel_Connection
            // 
            this.Panel_Connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Connection.Controls.Add(this.Button_Start_Bluetooth_Connection);
            this.Panel_Connection.Controls.Add(this.Form2_Back_Button);
            this.Panel_Connection.Location = new System.Drawing.Point(0, 251);
            this.Panel_Connection.Name = "Panel_Connection";
            this.Panel_Connection.Size = new System.Drawing.Size(384, 160);
            this.Panel_Connection.TabIndex = 6;
            this.Panel_Connection.Visible = false;
            // 
            // Button_Start_Bluetooth_Connection
            // 
            this.Button_Start_Bluetooth_Connection.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Start_Bluetooth_Connection.Location = new System.Drawing.Point(0, 0);
            this.Button_Start_Bluetooth_Connection.Name = "Button_Start_Bluetooth_Connection";
            this.Button_Start_Bluetooth_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_Start_Bluetooth_Connection.TabIndex = 0;
            this.Button_Start_Bluetooth_Connection.Text = "Start Bluetooth Connection";
            this.Button_Start_Bluetooth_Connection.UseVisualStyleBackColor = true;
            this.Button_Start_Bluetooth_Connection.Click += new System.EventHandler(this.Button_Start_Bluetooth_Connection_Click);
            // 
            // Form2_Back_Button
            // 
            this.Form2_Back_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Form2_Back_Button.Location = new System.Drawing.Point(0, 80);
            this.Form2_Back_Button.Name = "Form2_Back_Button";
            this.Form2_Back_Button.Size = new System.Drawing.Size(384, 80);
            this.Form2_Back_Button.TabIndex = 1;
            this.Form2_Back_Button.Text = "Back";
            this.Form2_Back_Button.UseVisualStyleBackColor = true;
            this.Form2_Back_Button.Click += new System.EventHandler(this.Button_Bluetooth_Back_Click);
            // 
            // Button_Filename_Formatting
            // 
            this.Button_Filename_Formatting.AutoSize = true;
            this.Button_Filename_Formatting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Filename_Formatting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Filename_Formatting.Location = new System.Drawing.Point(87, 0);
            this.Button_Filename_Formatting.Name = "Button_Filename_Formatting";
            this.Button_Filename_Formatting.Size = new System.Drawing.Size(187, 23);
            this.Button_Filename_Formatting.TabIndex = 3;
            this.Button_Filename_Formatting.Text = "Filename Formatting";
            this.Button_Filename_Formatting.UseVisualStyleBackColor = true;
            this.Button_Filename_Formatting.Click += new System.EventHandler(this.Button_Filename_Formatting_Click);
            // 
            // Button_Open_Folders
            // 
            this.Button_Open_Folders.AutoSize = true;
            this.Button_Open_Folders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Open_Folders.Dock = System.Windows.Forms.DockStyle.Left;
            this.Button_Open_Folders.Location = new System.Drawing.Point(0, 0);
            this.Button_Open_Folders.Name = "Button_Open_Folders";
            this.Button_Open_Folders.Size = new System.Drawing.Size(87, 23);
            this.Button_Open_Folders.TabIndex = 2;
            this.Button_Open_Folders.Text = "Open Folders";
            this.Button_Open_Folders.UseVisualStyleBackColor = true;
            this.Button_Open_Folders.Click += new System.EventHandler(this.Button_Open_Folders_Click);
            // 
            // Button_Directory_Settings
            // 
            this.Button_Directory_Settings.AutoSize = true;
            this.Button_Directory_Settings.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Directory_Settings.Location = new System.Drawing.Point(274, 0);
            this.Button_Directory_Settings.Name = "Button_Directory_Settings";
            this.Button_Directory_Settings.Size = new System.Drawing.Size(110, 23);
            this.Button_Directory_Settings.TabIndex = 4;
            this.Button_Directory_Settings.Text = "Directory Settings";
            this.Button_Directory_Settings.UseVisualStyleBackColor = true;
            this.Button_Directory_Settings.Click += new System.EventHandler(this.Button_Directory_Settings_Click);
            // 
            // Panel_Controls
            // 
            this.Panel_Controls.Controls.Add(this.Checkbox_Voice);
            this.Panel_Controls.Controls.Add(this.Checkbox_Plot_Mode);
            this.Panel_Controls.Controls.Add(this.Checkbox_Auto_Execute);
            this.Panel_Controls.Controls.Add(this.Checkbox_Auto_Increment);
            this.Panel_Controls.Controls.Add(this.Numeric_Quick_Trial);
            this.Panel_Controls.Controls.Add(this.label1);
            this.Panel_Controls.Controls.Add(this.COM_Port_Label);
            this.Panel_Controls.Controls.Add(this.Numeric_COM_Port);
            this.Panel_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Controls.Location = new System.Drawing.Point(0, 0);
            this.Panel_Controls.Name = "Panel_Controls";
            this.Panel_Controls.Size = new System.Drawing.Size(384, 251);
            this.Panel_Controls.TabIndex = 4;
            // 
            // Checkbox_Voice
            // 
            this.Checkbox_Voice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Voice.Checked = true;
            this.Checkbox_Voice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_Voice.Location = new System.Drawing.Point(145, 191);
            this.Checkbox_Voice.Name = "Checkbox_Voice";
            this.Checkbox_Voice.Size = new System.Drawing.Size(170, 24);
            this.Checkbox_Voice.TabIndex = 11;
            this.Checkbox_Voice.Text = "Enable Voice Prompt";
            this.Checkbox_Voice.UseVisualStyleBackColor = true;
            // 
            // Checkbox_Plot_Mode
            // 
            this.Checkbox_Plot_Mode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Plot_Mode.Location = new System.Drawing.Point(160, 161);
            this.Checkbox_Plot_Mode.Name = "Checkbox_Plot_Mode";
            this.Checkbox_Plot_Mode.Size = new System.Drawing.Size(155, 24);
            this.Checkbox_Plot_Mode.TabIndex = 9;
            this.Checkbox_Plot_Mode.Text = "Enable Plot Mode";
            this.Checkbox_Plot_Mode.UseVisualStyleBackColor = true;
            // 
            // Checkbox_Auto_Execute
            // 
            this.Checkbox_Auto_Execute.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Auto_Execute.Location = new System.Drawing.Point(122, 131);
            this.Checkbox_Auto_Execute.Name = "Checkbox_Auto_Execute";
            this.Checkbox_Auto_Execute.Size = new System.Drawing.Size(193, 24);
            this.Checkbox_Auto_Execute.TabIndex = 8;
            this.Checkbox_Auto_Execute.Text = "Auto-execute MAT Script";
            this.Checkbox_Auto_Execute.UseVisualStyleBackColor = true;
            this.Checkbox_Auto_Execute.CheckedChanged += new System.EventHandler(this.Checkbox_Auto_Execute_CheckedChanged);
            // 
            // Checkbox_Auto_Increment
            // 
            this.Checkbox_Auto_Increment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Auto_Increment.Checked = true;
            this.Checkbox_Auto_Increment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_Auto_Increment.Location = new System.Drawing.Point(99, 101);
            this.Checkbox_Auto_Increment.Name = "Checkbox_Auto_Increment";
            this.Checkbox_Auto_Increment.Size = new System.Drawing.Size(216, 24);
            this.Checkbox_Auto_Increment.TabIndex = 7;
            this.Checkbox_Auto_Increment.Text = "Auto-increment Trial Number";
            this.Checkbox_Auto_Increment.UseVisualStyleBackColor = true;
            // 
            // Numeric_Quick_Trial
            // 
            this.Numeric_Quick_Trial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Numeric_Quick_Trial.Location = new System.Drawing.Point(270, 72);
            this.Numeric_Quick_Trial.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Quick_Trial.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Quick_Trial.Name = "Numeric_Quick_Trial";
            this.Numeric_Quick_Trial.Size = new System.Drawing.Size(95, 23);
            this.Numeric_Quick_Trial.TabIndex = 6;
            this.Numeric_Quick_Trial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Numeric_Quick_Trial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Quick_Trial.ValueChanged += new System.EventHandler(this.Numeric_Quick_Trial_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(189, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trial Number";
            // 
            // COM_Port_Label
            // 
            this.COM_Port_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_Port_Label.AutoSize = true;
            this.COM_Port_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.COM_Port_Label.Location = new System.Drawing.Point(204, 45);
            this.COM_Port_Label.Name = "COM_Port_Label";
            this.COM_Port_Label.Size = new System.Drawing.Size(60, 15);
            this.COM_Port_Label.TabIndex = 1;
            this.COM_Port_Label.Text = "COM Port";
            // 
            // Numeric_COM_Port
            // 
            this.Numeric_COM_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Numeric_COM_Port.Location = new System.Drawing.Point(271, 43);
            this.Numeric_COM_Port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_COM_Port.Name = "Numeric_COM_Port";
            this.Numeric_COM_Port.Size = new System.Drawing.Size(95, 23);
            this.Numeric_COM_Port.TabIndex = 5;
            this.Numeric_COM_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Numeric_COM_Port.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Numeric_COM_Port.ValueChanged += new System.EventHandler(this.Numeric_COM_Port_ValueChanged);
            // 
            // Label_Status
            // 
            this.Label_Status.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label_Status.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_Status.ForeColor = System.Drawing.Color.Gray;
            this.Label_Status.Location = new System.Drawing.Point(0, 45);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(183, 48);
            this.Label_Status.TabIndex = 10;
            this.Label_Status.Text = "Standby";
            this.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer_Receive_Samples
            // 
            this.Timer_Receive_Samples.Interval = 300;
            this.Timer_Receive_Samples.Tick += new System.EventHandler(this.Timer_Receive_Samples_Tick);
            // 
            // Panel_Settings
            // 
            this.Panel_Settings.Controls.Add(this.Button_Filename_Formatting);
            this.Panel_Settings.Controls.Add(this.Button_Open_Folders);
            this.Panel_Settings.Controls.Add(this.Button_Directory_Settings);
            this.Panel_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Settings.Location = new System.Drawing.Point(0, 0);
            this.Panel_Settings.Name = "Panel_Settings";
            this.Panel_Settings.Size = new System.Drawing.Size(384, 23);
            this.Panel_Settings.TabIndex = 5;
            // 
<<<<<<< HEAD
<<<<<<< HEAD
            // Panel_Status
            // 
            this.Panel_Status.Controls.Add(this.Label_Status);
            this.Panel_Status.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Status.Location = new System.Drawing.Point(0, 23);
            this.Panel_Status.Name = "Panel_Status";
            this.Panel_Status.Size = new System.Drawing.Size(198, 125);
            this.Panel_Status.TabIndex = 11;
            // 
            // Panel_Bluetooth
            // 
            this.Panel_Bluetooth.Controls.Add(this.COM_Port_Label);
            this.Panel_Bluetooth.Controls.Add(this.Numeric_COM_Port);
            this.Panel_Bluetooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Bluetooth.Location = new System.Drawing.Point(198, 23);
            this.Panel_Bluetooth.Name = "Panel_Bluetooth";
            this.Panel_Bluetooth.Size = new System.Drawing.Size(186, 125);
            this.Panel_Bluetooth.TabIndex = 12;
            // 
            // Panel_TCP
            // 
            this.Panel_TCP.Controls.Add(this.Textbox_IP);
            this.Panel_TCP.Controls.Add(this.Label_IP);
            this.Panel_TCP.Controls.Add(this.Label_Port);
            this.Panel_TCP.Controls.Add(this.Numeric_Port);
            this.Panel_TCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_TCP.Location = new System.Drawing.Point(198, 23);
            this.Panel_TCP.Name = "Panel_TCP";
            this.Panel_TCP.Size = new System.Drawing.Size(186, 125);
            this.Panel_TCP.TabIndex = 13;
            this.Panel_TCP.Visible = false;
            // 
            // Textbox_IP
            // 
            this.Textbox_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_IP.Location = new System.Drawing.Point(83, 62);
            this.Textbox_IP.Name = "Textbox_IP";
            this.Textbox_IP.PlaceholderText = "192.168.0.1";
            this.Textbox_IP.Size = new System.Drawing.Size(91, 23);
            this.Textbox_IP.TabIndex = 7;
            this.Textbox_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Textbox_IP.TextChanged += new System.EventHandler(this.Textbox_IP_TextChanged);
            // 
            // Label_IP
            // 
            this.Label_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_IP.AutoSize = true;
            this.Label_IP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_IP.Location = new System.Drawing.Point(19, 70);
            this.Label_IP.Name = "Label_IP";
            this.Label_IP.Size = new System.Drawing.Size(17, 15);
            this.Label_IP.TabIndex = 6;
            this.Label_IP.Text = "IP";
            // 
            // Label_Port
            // 
            this.Label_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Port.AutoSize = true;
            this.Label_Port.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_Port.Location = new System.Drawing.Point(19, 101);
            this.Label_Port.Name = "Label_Port";
            this.Label_Port.Size = new System.Drawing.Size(29, 15);
            this.Label_Port.TabIndex = 1;
            this.Label_Port.Text = "Port";
            // 
            // Numeric_Port
            // 
            this.Numeric_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Numeric_Port.Location = new System.Drawing.Point(83, 99);
            this.Numeric_Port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Port.Name = "Numeric_Port";
            this.Numeric_Port.Size = new System.Drawing.Size(91, 23);
            this.Numeric_Port.TabIndex = 5;
            this.Numeric_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Numeric_Port.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Port.ValueChanged += new System.EventHandler(this.Numeric_Port_ValueChanged);
            // 
<<<<<<< HEAD
            // Background_TCP
            // 
            this.Background_TCP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Background_TCP_DoWork);
            // 
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
            // MAT_Script_Runner
            // 
            this.AcceptButton = this.Button_Start_Bluetooth_Connection;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Form2_Back_Button;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.Panel_Settings);
            this.Controls.Add(this.Panel_Connection);
            this.Controls.Add(this.Panel_Controls);
            this.Controls.Add(this.Panel_Home);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MAT_Script_Runner";
            this.Text = "MAT Script Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Home.ResumeLayout(false);
            this.Panel_Connection.ResumeLayout(false);
            this.Panel_Controls.ResumeLayout(false);
            this.Panel_Controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Quick_Trial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_COM_Port)).EndInit();
            this.Panel_Settings.ResumeLayout(false);
            this.Panel_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_TCPIP_Connection;
        private System.Windows.Forms.Button Button_Bluetooth_Connection;
        private System.Windows.Forms.Panel Panel_Home;
        private System.Windows.Forms.Panel Panel_Controls;
        private System.Windows.Forms.Label COM_Port_Label;
        private System.Windows.Forms.Button Form2_Back_Button;
        private System.Windows.Forms.Button Button_Start_Bluetooth_Connection;
        private System.Windows.Forms.Button Button_Directory_Settings;
        private System.Windows.Forms.Button Button_Open_Folders;
        private System.Windows.Forms.NumericUpDown Numeric_COM_Port;
        private System.Windows.Forms.Timer Timer_Receive_Samples;
        private System.Windows.Forms.Panel Panel_Settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Filename_Formatting;
        private System.Windows.Forms.CheckBox Checkbox_Auto_Increment;
        private System.Windows.Forms.CheckBox Checkbox_Auto_Execute;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.CheckBox Checkbox_Plot_Mode;
        private System.Windows.Forms.Panel Panel_Connection;
        public System.Windows.Forms.NumericUpDown Numeric_Quick_Trial;
        private System.Windows.Forms.CheckBox Checkbox_Voice;
<<<<<<< HEAD
<<<<<<< HEAD
        private System.Windows.Forms.Panel Panel_Status;
        private System.Windows.Forms.Panel Panel_Bluetooth;
        private System.Windows.Forms.Panel Panel_TCP;
        private System.Windows.Forms.Label Label_Port;
        private System.Windows.Forms.NumericUpDown Numeric_Port;
        private System.Windows.Forms.Label Label_IP;
        private System.Windows.Forms.TextBox Textbox_IP;
        public System.Windows.Forms.NumericUpDown Numeric_Quick_Participant;
        private System.Windows.Forms.Label label1;
<<<<<<< HEAD
        private System.ComponentModel.BackgroundWorker Background_TCP;
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
    }
}


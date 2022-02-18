﻿
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
            this.Button_Filename_Formatting = new System.Windows.Forms.Button();
            this.Button_Open_Folders = new System.Windows.Forms.Button();
            this.Button_Directory_Settings = new System.Windows.Forms.Button();
            this.Panel_Bluetooth_Connection = new System.Windows.Forms.Panel();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Checkbox_Auto_Execute = new System.Windows.Forms.CheckBox();
            this.Checkbox_Auto_Increment = new System.Windows.Forms.CheckBox();
            this.Numeric_Quick_Trial = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Start_Bluetooth_Connection = new System.Windows.Forms.Button();
            this.Form2_Back_Button = new System.Windows.Forms.Button();
            this.COM_Port_Label = new System.Windows.Forms.Label();
            this.Numeric_COM_Port = new System.Windows.Forms.NumericUpDown();
            this.Timer_Receive_Samples = new System.Windows.Forms.Timer(this.components);
            this.Panel_Settings = new System.Windows.Forms.Panel();
            this.Checkbox_Plot_Mode = new System.Windows.Forms.CheckBox();
            this.Panel_Home.SuspendLayout();
            this.Panel_Bluetooth_Connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Quick_Trial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_COM_Port)).BeginInit();
            this.Panel_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_TCPIP_Connection
            // 
            this.Button_TCPIP_Connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_TCPIP_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_TCPIP_Connection.Location = new System.Drawing.Point(0, 22);
            this.Button_TCPIP_Connection.Name = "Button_TCPIP_Connection";
            this.Button_TCPIP_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_TCPIP_Connection.TabIndex = 0;
            this.Button_TCPIP_Connection.Text = "TCPIP Connection";
            this.Button_TCPIP_Connection.UseVisualStyleBackColor = true;
            this.Button_TCPIP_Connection.Click += new System.EventHandler(this.Button_TCPIP_Connection_Click);
            // 
            // Button_Bluetooth_Connection
            // 
            this.Button_Bluetooth_Connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Bluetooth_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Bluetooth_Connection.Location = new System.Drawing.Point(0, 101);
            this.Button_Bluetooth_Connection.Name = "Button_Bluetooth_Connection";
            this.Button_Bluetooth_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_Bluetooth_Connection.TabIndex = 1;
            this.Button_Bluetooth_Connection.Text = "Bluetooth Connection";
            this.Button_Bluetooth_Connection.UseVisualStyleBackColor = true;
            this.Button_Bluetooth_Connection.Click += new System.EventHandler(this.Button_Bluetooth_Connection_Click);
            // 
            // Panel_Home
            // 
            this.Panel_Home.Controls.Add(this.Button_Bluetooth_Connection);
            this.Panel_Home.Controls.Add(this.Button_TCPIP_Connection);
            this.Panel_Home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Home.Location = new System.Drawing.Point(0, 0);
            this.Panel_Home.Name = "Panel_Home";
            this.Panel_Home.Size = new System.Drawing.Size(384, 361);
            this.Panel_Home.TabIndex = 3;
            // 
            // Button_Filename_Formatting
            // 
            this.Button_Filename_Formatting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Filename_Formatting.Location = new System.Drawing.Point(152, 0);
            this.Button_Filename_Formatting.Name = "Button_Filename_Formatting";
            this.Button_Filename_Formatting.Size = new System.Drawing.Size(125, 23);
            this.Button_Filename_Formatting.TabIndex = 4;
            this.Button_Filename_Formatting.Text = "Filename Formatting";
            this.Button_Filename_Formatting.UseVisualStyleBackColor = true;
            this.Button_Filename_Formatting.Click += new System.EventHandler(this.Button_Filename_Formatting_Click);
            // 
            // Button_Open_Folders
            // 
            this.Button_Open_Folders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open_Folders.Location = new System.Drawing.Point(68, 0);
            this.Button_Open_Folders.Name = "Button_Open_Folders";
            this.Button_Open_Folders.Size = new System.Drawing.Size(85, 23);
            this.Button_Open_Folders.TabIndex = 3;
            this.Button_Open_Folders.Text = "Open Folders";
            this.Button_Open_Folders.UseVisualStyleBackColor = true;
            this.Button_Open_Folders.Click += new System.EventHandler(this.Button_Open_Folders_Click);
            // 
            // Button_Directory_Settings
            // 
            this.Button_Directory_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Directory_Settings.Location = new System.Drawing.Point(276, 0);
            this.Button_Directory_Settings.Name = "Button_Directory_Settings";
            this.Button_Directory_Settings.Size = new System.Drawing.Size(108, 23);
            this.Button_Directory_Settings.TabIndex = 2;
            this.Button_Directory_Settings.Text = "Directory Settings";
            this.Button_Directory_Settings.UseVisualStyleBackColor = true;
            this.Button_Directory_Settings.Click += new System.EventHandler(this.Button_Directory_Settings_Click);
            // 
            // Panel_Bluetooth_Connection
            // 
            this.Panel_Bluetooth_Connection.Controls.Add(this.Checkbox_Plot_Mode);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Label_Status);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Checkbox_Auto_Execute);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Checkbox_Auto_Increment);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Numeric_Quick_Trial);
            this.Panel_Bluetooth_Connection.Controls.Add(this.label1);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Button_Start_Bluetooth_Connection);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Form2_Back_Button);
            this.Panel_Bluetooth_Connection.Controls.Add(this.COM_Port_Label);
            this.Panel_Bluetooth_Connection.Controls.Add(this.Numeric_COM_Port);
            this.Panel_Bluetooth_Connection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Bluetooth_Connection.Location = new System.Drawing.Point(0, 0);
            this.Panel_Bluetooth_Connection.Name = "Panel_Bluetooth_Connection";
            this.Panel_Bluetooth_Connection.Size = new System.Drawing.Size(384, 361);
            this.Panel_Bluetooth_Connection.TabIndex = 4;
            this.Panel_Bluetooth_Connection.Visible = false;
            // 
            // Label_Status
            // 
            this.Label_Status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_Status.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label_Status.ForeColor = System.Drawing.Color.Gray;
            this.Label_Status.Location = new System.Drawing.Point(12, 34);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(183, 48);
            this.Label_Status.TabIndex = 10;
            this.Label_Status.Text = "Standby";
            this.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Checkbox_Auto_Execute
            // 
            this.Checkbox_Auto_Execute.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Auto_Execute.Location = new System.Drawing.Point(129, 122);
            this.Checkbox_Auto_Execute.Name = "Checkbox_Auto_Execute";
            this.Checkbox_Auto_Execute.Size = new System.Drawing.Size(193, 24);
            this.Checkbox_Auto_Execute.TabIndex = 9;
            this.Checkbox_Auto_Execute.Text = "Auto-execute MAT Script";
            this.Checkbox_Auto_Execute.UseVisualStyleBackColor = true;
            this.Checkbox_Auto_Execute.CheckedChanged += new System.EventHandler(this.Checkbox_Auto_Execute_CheckedChanged);
            // 
            // Checkbox_Auto_Increment
            // 
            this.Checkbox_Auto_Increment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Auto_Increment.Checked = true;
            this.Checkbox_Auto_Increment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_Auto_Increment.Location = new System.Drawing.Point(106, 92);
            this.Checkbox_Auto_Increment.Name = "Checkbox_Auto_Increment";
            this.Checkbox_Auto_Increment.Size = new System.Drawing.Size(216, 24);
            this.Checkbox_Auto_Increment.TabIndex = 8;
            this.Checkbox_Auto_Increment.Text = "Auto-increment Trial Number";
            this.Checkbox_Auto_Increment.UseVisualStyleBackColor = true;
            // 
            // Numeric_Quick_Trial
            // 
            this.Numeric_Quick_Trial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Numeric_Quick_Trial.Location = new System.Drawing.Point(276, 63);
            this.Numeric_Quick_Trial.Name = "Numeric_Quick_Trial";
            this.Numeric_Quick_Trial.Size = new System.Drawing.Size(95, 23);
            this.Numeric_Quick_Trial.TabIndex = 7;
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
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(195, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trial Number";
            // 
            // Button_Start_Bluetooth_Connection
            // 
            this.Button_Start_Bluetooth_Connection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_Start_Bluetooth_Connection.Location = new System.Drawing.Point(0, 201);
            this.Button_Start_Bluetooth_Connection.Name = "Button_Start_Bluetooth_Connection";
            this.Button_Start_Bluetooth_Connection.Size = new System.Drawing.Size(384, 80);
            this.Button_Start_Bluetooth_Connection.TabIndex = 4;
            this.Button_Start_Bluetooth_Connection.Text = "Start Bluetooth Connection";
            this.Button_Start_Bluetooth_Connection.UseVisualStyleBackColor = true;
            this.Button_Start_Bluetooth_Connection.Click += new System.EventHandler(this.Button_Start_Bluetooth_Connection_Click);
            // 
            // Form2_Back_Button
            // 
            this.Form2_Back_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Form2_Back_Button.Location = new System.Drawing.Point(0, 281);
            this.Form2_Back_Button.Name = "Form2_Back_Button";
            this.Form2_Back_Button.Size = new System.Drawing.Size(384, 80);
            this.Form2_Back_Button.TabIndex = 3;
            this.Form2_Back_Button.Text = "Back";
            this.Form2_Back_Button.UseVisualStyleBackColor = true;
            this.Form2_Back_Button.Click += new System.EventHandler(this.Button_Bluetooth_Back_Click);
            // 
            // COM_Port_Label
            // 
            this.COM_Port_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.COM_Port_Label.AutoSize = true;
            this.COM_Port_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.COM_Port_Label.Location = new System.Drawing.Point(210, 36);
            this.COM_Port_Label.Name = "COM_Port_Label";
            this.COM_Port_Label.Size = new System.Drawing.Size(60, 15);
            this.COM_Port_Label.TabIndex = 1;
            this.COM_Port_Label.Text = "COM Port";
            // 
            // Numeric_COM_Port
            // 
            this.Numeric_COM_Port.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Numeric_COM_Port.Location = new System.Drawing.Point(277, 34);
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
            // Timer_Receive_Samples
            // 
            this.Timer_Receive_Samples.Interval = 300;
            this.Timer_Receive_Samples.Tick += new System.EventHandler(this.Timer_Receive_Samples_Tick);
            // 
            // Panel_Settings
            // 
            this.Panel_Settings.Controls.Add(this.Button_Open_Folders);
            this.Panel_Settings.Controls.Add(this.Button_Filename_Formatting);
            this.Panel_Settings.Controls.Add(this.Button_Directory_Settings);
            this.Panel_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Settings.Location = new System.Drawing.Point(0, 0);
            this.Panel_Settings.Name = "Panel_Settings";
            this.Panel_Settings.Size = new System.Drawing.Size(384, 23);
            this.Panel_Settings.TabIndex = 5;
            // 
            // Checkbox_Plot_Mode
            // 
            this.Checkbox_Plot_Mode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Checkbox_Plot_Mode.Location = new System.Drawing.Point(167, 152);
            this.Checkbox_Plot_Mode.Name = "Checkbox_Plot_Mode";
            this.Checkbox_Plot_Mode.Size = new System.Drawing.Size(155, 24);
            this.Checkbox_Plot_Mode.TabIndex = 11;
            this.Checkbox_Plot_Mode.Text = "Enable Plot Mode";
            this.Checkbox_Plot_Mode.UseVisualStyleBackColor = true;
            // 
            // MAT_Script_Runner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Panel_Settings);
            this.Controls.Add(this.Panel_Bluetooth_Connection);
            this.Controls.Add(this.Panel_Home);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MAT_Script_Runner";
            this.Text = "MAT Script Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Home.ResumeLayout(false);
            this.Panel_Bluetooth_Connection.ResumeLayout(false);
            this.Panel_Bluetooth_Connection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Quick_Trial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_COM_Port)).EndInit();
            this.Panel_Settings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_TCPIP_Connection;
        private System.Windows.Forms.Button Button_Bluetooth_Connection;
        private System.Windows.Forms.Panel Panel_Home;
        private System.Windows.Forms.Panel Panel_Bluetooth_Connection;
        private System.Windows.Forms.Label COM_Port_Label;
        private System.Windows.Forms.Button Form2_Back_Button;
        private System.Windows.Forms.Button Button_Start_Bluetooth_Connection;
        private System.Windows.Forms.Button Button_Directory_Settings;
        private System.Windows.Forms.Button Button_Open_Folders;
        private System.Windows.Forms.NumericUpDown Numeric_COM_Port;
        private System.Windows.Forms.Timer Timer_Receive_Samples;
        private System.Windows.Forms.Panel Panel_Settings;
        private System.Windows.Forms.NumericUpDown Numeric_Quick_Trial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Filename_Formatting;
        private System.Windows.Forms.CheckBox Checkbox_Auto_Increment;
        private System.Windows.Forms.CheckBox Checkbox_Auto_Execute;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.CheckBox Checkbox_Plot_Mode;
    }
}


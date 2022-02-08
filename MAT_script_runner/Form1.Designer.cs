
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
            this.TCPIP_Connection = new System.Windows.Forms.Button();
            this.Bluetooth_Connection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TCPIP_Connection
            // 
            this.TCPIP_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TCPIP_Connection.Dock = System.Windows.Forms.DockStyle.Top;
            this.TCPIP_Connection.Location = new System.Drawing.Point(0, 0);
            this.TCPIP_Connection.Name = "TCPIP_Connection";
            this.TCPIP_Connection.Size = new System.Drawing.Size(361, 80);
            this.TCPIP_Connection.TabIndex = 0;
            this.TCPIP_Connection.Text = "TCPIP Connection";
            this.TCPIP_Connection.UseVisualStyleBackColor = true;
            this.TCPIP_Connection.Click += new System.EventHandler(this.TCPIP_Connection_Button_Click);
            // 
            // Bluetooth_Connection
            // 
            this.Bluetooth_Connection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Bluetooth_Connection.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bluetooth_Connection.Location = new System.Drawing.Point(0, 80);
            this.Bluetooth_Connection.Name = "Bluetooth_Connection";
            this.Bluetooth_Connection.Size = new System.Drawing.Size(361, 80);
            this.Bluetooth_Connection.TabIndex = 1;
            this.Bluetooth_Connection.Text = "Bluetooth Connection";
            this.Bluetooth_Connection.UseVisualStyleBackColor = true;
            this.Bluetooth_Connection.Click += new System.EventHandler(this.Bluetooth_Connection_Button_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 144);
            this.label1.TabIndex = 2;
            this.label1.Text = "Button pressed: none";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MAT_Script_Runner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bluetooth_Connection);
            this.Controls.Add(this.TCPIP_Connection);
            this.Name = "MAT_Script_Runner";
            this.Text = "MAT Script Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TCPIP_Connection;
        private System.Windows.Forms.Button Bluetooth_Connection;
        private System.Windows.Forms.Label label1;
    }
}


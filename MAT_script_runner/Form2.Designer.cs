
namespace MAT_script_runner
{
    partial class Directory_Settings
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
            this.Textbox_Input_Directory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Textbox_Output_Directory = new System.Windows.Forms.TextBox();
            this.Button_Browse_Input = new System.Windows.Forms.Button();
            this.Button_Output_Browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Directory_Save = new System.Windows.Forms.Button();
            this.Button_Directory_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Textbox_Script_Directory = new System.Windows.Forms.TextBox();
            this.Button_Script_Browse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Textbox_Input_Directory
            // 
            this.Textbox_Input_Directory.Location = new System.Drawing.Point(12, 28);
            this.Textbox_Input_Directory.Name = "Textbox_Input_Directory";
            this.Textbox_Input_Directory.Size = new System.Drawing.Size(479, 23);
            this.Textbox_Input_Directory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Directory";
            // 
            // Textbox_Output_Directory
            // 
            this.Textbox_Output_Directory.Location = new System.Drawing.Point(12, 72);
            this.Textbox_Output_Directory.Name = "Textbox_Output_Directory";
            this.Textbox_Output_Directory.Size = new System.Drawing.Size(479, 23);
            this.Textbox_Output_Directory.TabIndex = 4;
            // 
            // Button_Browse_Input
            // 
            this.Button_Browse_Input.Location = new System.Drawing.Point(499, 28);
            this.Button_Browse_Input.Name = "Button_Browse_Input";
            this.Button_Browse_Input.Size = new System.Drawing.Size(75, 23);
            this.Button_Browse_Input.TabIndex = 3;
            this.Button_Browse_Input.Text = "Browse";
            this.Button_Browse_Input.UseVisualStyleBackColor = true;
            this.Button_Browse_Input.Click += new System.EventHandler(this.Button_Browse_Input_Click);
            // 
            // Button_Output_Browse
            // 
            this.Button_Output_Browse.Location = new System.Drawing.Point(499, 72);
            this.Button_Output_Browse.Name = "Button_Output_Browse";
            this.Button_Output_Browse.Size = new System.Drawing.Size(75, 23);
            this.Button_Output_Browse.TabIndex = 5;
            this.Button_Output_Browse.Text = "Browse";
            this.Button_Output_Browse.UseVisualStyleBackColor = true;
            this.Button_Output_Browse.Click += new System.EventHandler(this.Button_Output_Browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Directory";
            // 
            // Button_Directory_Save
            // 
            this.Button_Directory_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Directory_Save.Location = new System.Drawing.Point(170, 173);
            this.Button_Directory_Save.Name = "Button_Directory_Save";
            this.Button_Directory_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Directory_Save.TabIndex = 0;
            this.Button_Directory_Save.Text = "Save";
            this.Button_Directory_Save.UseVisualStyleBackColor = true;
            this.Button_Directory_Save.Click += new System.EventHandler(this.Button_Directory_Save_Click);
            // 
            // Button_Directory_Cancel
            // 
            this.Button_Directory_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Directory_Cancel.Location = new System.Drawing.Point(341, 173);
            this.Button_Directory_Cancel.Name = "Button_Directory_Cancel";
            this.Button_Directory_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Directory_Cancel.TabIndex = 1;
            this.Button_Directory_Cancel.Text = "Cancel";
            this.Button_Directory_Cancel.UseVisualStyleBackColor = true;
            this.Button_Directory_Cancel.Click += new System.EventHandler(this.Button_Directory_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Script Directory";
            // 
            // Textbox_Script_Directory
            // 
            this.Textbox_Script_Directory.Location = new System.Drawing.Point(12, 116);
            this.Textbox_Script_Directory.Name = "Textbox_Script_Directory";
            this.Textbox_Script_Directory.Size = new System.Drawing.Size(479, 23);
            this.Textbox_Script_Directory.TabIndex = 6;
            // 
            // Button_Script_Browse
            // 
            this.Button_Script_Browse.Location = new System.Drawing.Point(499, 116);
            this.Button_Script_Browse.Name = "Button_Script_Browse";
            this.Button_Script_Browse.Size = new System.Drawing.Size(75, 23);
            this.Button_Script_Browse.TabIndex = 7;
            this.Button_Script_Browse.Text = "Browse";
            this.Button_Script_Browse.UseVisualStyleBackColor = true;
            this.Button_Script_Browse.Click += new System.EventHandler(this.Button_Script_Browse_Click);
            // 
            // Directory_Settings
            // 
            this.AcceptButton = this.Button_Directory_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Directory_Cancel;
            this.ClientSize = new System.Drawing.Size(584, 211);
            this.Controls.Add(this.Button_Script_Browse);
            this.Controls.Add(this.Textbox_Script_Directory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Button_Directory_Cancel);
            this.Controls.Add(this.Button_Directory_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Button_Output_Browse);
            this.Controls.Add(this.Button_Browse_Input);
            this.Controls.Add(this.Textbox_Output_Directory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Textbox_Input_Directory);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "Directory_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Directory Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Textbox_Input_Directory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Textbox_Output_Directory;
        private System.Windows.Forms.Button Button_Browse_Input;
        private System.Windows.Forms.Button Button_Output_Browse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Directory_Save;
        private System.Windows.Forms.Button Button_Directory_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Textbox_Script_Directory;
        private System.Windows.Forms.Button Button_Script_Browse;
    }
}
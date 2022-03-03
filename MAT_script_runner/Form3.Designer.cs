
namespace MAT_script_runner
{
    partial class Filename_Formatting
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
            this.label1 = new System.Windows.Forms.Label();
            this.Textbox_Gesture = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_Filename_Save = new System.Windows.Forms.Button();
            this.Button_Filename_Cancel = new System.Windows.Forms.Button();
            this.Numeric_Participant = new System.Windows.Forms.NumericUpDown();
            this.Numeric_Trial = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Participant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Trial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gesture name";
            // 
            // Textbox_Gesture
            // 
            this.Textbox_Gesture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_Gesture.Location = new System.Drawing.Point(137, 6);
            this.Textbox_Gesture.Name = "Textbox_Gesture";
            this.Textbox_Gesture.Size = new System.Drawing.Size(269, 23);
            this.Textbox_Gesture.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Participant Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Starting Trial Number";
            // 
            // Button_Filename_Save
            // 
            this.Button_Filename_Save.Location = new System.Drawing.Point(89, 108);
            this.Button_Filename_Save.Name = "Button_Filename_Save";
            this.Button_Filename_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Filename_Save.TabIndex = 0;
            this.Button_Filename_Save.Text = "Save";
            this.Button_Filename_Save.UseVisualStyleBackColor = true;
            this.Button_Filename_Save.Click += new System.EventHandler(this.Button_Filename_Save_Click);
            // 
            // Button_Filename_Cancel
            // 
            this.Button_Filename_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Filename_Cancel.Location = new System.Drawing.Point(254, 108);
            this.Button_Filename_Cancel.Name = "Button_Filename_Cancel";
            this.Button_Filename_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Filename_Cancel.TabIndex = 1;
            this.Button_Filename_Cancel.Text = "Cancel";
            this.Button_Filename_Cancel.UseVisualStyleBackColor = true;
            this.Button_Filename_Cancel.Click += new System.EventHandler(this.Button_Filename_Cancel_Click);
            // 
            // Numeric_Participant
            // 
            this.Numeric_Participant.Location = new System.Drawing.Point(137, 31);
            this.Numeric_Participant.Name = "Numeric_Participant";
            this.Numeric_Participant.Size = new System.Drawing.Size(269, 23);
            this.Numeric_Participant.TabIndex = 3;
            // 
            // Numeric_Trial
            // 
            this.Numeric_Trial.Location = new System.Drawing.Point(137, 55);
            this.Numeric_Trial.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Numeric_Trial.Name = "Numeric_Trial";
            this.Numeric_Trial.Size = new System.Drawing.Size(269, 23);
            this.Numeric_Trial.TabIndex = 4;
            // 
            // Filename_Formatting
            // 
            this.AcceptButton = this.Button_Filename_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Filename_Cancel;
            this.ClientSize = new System.Drawing.Size(418, 136);
            this.Controls.Add(this.Numeric_Trial);
            this.Controls.Add(this.Numeric_Participant);
            this.Controls.Add(this.Button_Filename_Cancel);
            this.Controls.Add(this.Button_Filename_Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Textbox_Gesture);
            this.Controls.Add(this.label1);
            this.Name = "Filename_Formatting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filename_Formatting";
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Participant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_Trial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Textbox_Gesture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_Filename_Save;
        private System.Windows.Forms.Button Button_Filename_Cancel;
        private System.Windows.Forms.NumericUpDown Numeric_Participant;
        private System.Windows.Forms.NumericUpDown Numeric_Trial;
    }
}
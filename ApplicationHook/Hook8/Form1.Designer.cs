namespace Hook8 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Log = new System.Windows.Forms.TextBox();
            this.ProcessLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Dock = System.Windows.Forms.DockStyle.Left;
            this.Log.Location = new System.Drawing.Point(0, 0);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(524, 737);
            this.Log.TabIndex = 0;
            // 
            // ProcessLog
            // 
            this.ProcessLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProcessLog.Location = new System.Drawing.Point(530, 0);
            this.ProcessLog.Multiline = true;
            this.ProcessLog.Name = "ProcessLog";
            this.ProcessLog.Size = new System.Drawing.Size(553, 737);
            this.ProcessLog.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 737);
            this.Controls.Add(this.ProcessLog);
            this.Controls.Add(this.Log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.TextBox ProcessLog;
    }
}


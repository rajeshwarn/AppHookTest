namespace ApplicationHookTest {
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
            this.tBoxLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tBoxLog
            // 
            this.tBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxLog.Location = new System.Drawing.Point(0, 0);
            this.tBoxLog.Multiline = true;
            this.tBoxLog.Name = "tBoxLog";
            this.tBoxLog.Size = new System.Drawing.Size(631, 504);
            this.tBoxLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 504);
            this.Controls.Add(this.tBoxLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxLog;
    }
}


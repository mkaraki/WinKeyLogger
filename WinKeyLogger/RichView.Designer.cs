namespace WinKeyLogger
{
    partial class RichView
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
            this.rbox_log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rbox_log
            // 
            this.rbox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbox_log.Location = new System.Drawing.Point(0, 0);
            this.rbox_log.Name = "rbox_log";
            this.rbox_log.ReadOnly = true;
            this.rbox_log.Size = new System.Drawing.Size(800, 450);
            this.rbox_log.TabIndex = 0;
            this.rbox_log.Text = "";
            // 
            // RichView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbox_log);
            this.Name = "RichView";
            this.Text = "RichView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RichView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox rbox_log;
    }
}
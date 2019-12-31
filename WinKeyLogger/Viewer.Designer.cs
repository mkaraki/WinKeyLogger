namespace WinKeyLogger
{
    partial class Viewer
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
            this.lbox_log = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbox_log
            // 
            this.lbox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbox_log.FormattingEnabled = true;
            this.lbox_log.Location = new System.Drawing.Point(0, 0);
            this.lbox_log.Name = "lbox_log";
            this.lbox_log.Size = new System.Drawing.Size(800, 450);
            this.lbox_log.TabIndex = 0;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbox_log);
            this.Name = "Viewer";
            this.Text = "Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox lbox_log;
    }
}
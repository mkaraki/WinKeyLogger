namespace WinKeyLogger
{
    partial class Control
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control));
            this.btn_enable = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.btn_rview = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // btn_enable
            // 
            this.btn_enable.Location = new System.Drawing.Point(12, 12);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(287, 23);
            this.btn_enable.TabIndex = 0;
            this.btn_enable.Text = "Enable";
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.btn_enable_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(12, 41);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(287, 23);
            this.btn_view.TabIndex = 1;
            this.btn_view.Text = "View";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // btn_rview
            // 
            this.btn_rview.Location = new System.Drawing.Point(12, 70);
            this.btn_rview.Name = "btn_rview";
            this.btn_rview.Size = new System.Drawing.Size(287, 23);
            this.btn_rview.TabIndex = 2;
            this.btn_rview.Text = "Rich View";
            this.btn_rview.UseVisualStyleBackColor = true;
            this.btn_rview.Click += new System.EventHandler(this.btn_rview_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "KeyLogger is now working in background";
            this.notifyIcon1.BalloonTipTitle = "KeyLogger is still working";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "KeyLogger";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 143);
            this.Controls.Add(this.btn_rview);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_enable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Control";
            this.Text = "WinKeyLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Control_FormClosing);
            this.Load += new System.EventHandler(this.Control_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Button btn_rview;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}


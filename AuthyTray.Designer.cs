
namespace AuthyTray
{
    partial class AuthyTray
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthyTray));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ProcessStatusChecker = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeAuthyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Authy";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Authy";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.BallonTipClick);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.BallonTipClick);
            // 
            // ProcessStatusChecker
            // 
            this.ProcessStatusChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessStatusChecker_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAuthyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // closeAuthyToolStripMenuItem
            // 
            this.closeAuthyToolStripMenuItem.Image = global::AuthyTray.Properties.Resources.close_icon_png_19;
            this.closeAuthyToolStripMenuItem.Name = "closeAuthyToolStripMenuItem";
            this.closeAuthyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeAuthyToolStripMenuItem.Text = "Close Authy";
            this.closeAuthyToolStripMenuItem.Click += new System.EventHandler(this.BallonTipClick);
            // 
            // AuthyTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 34);
            this.Name = "AuthyTray";
            this.Text = "AuthyTray";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthyTray_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.ComponentModel.BackgroundWorker ProcessStatusChecker;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeAuthyToolStripMenuItem;
    }
}


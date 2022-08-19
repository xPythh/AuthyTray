using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthyTray
{
    public partial class AuthyTray : Form
    {
        public AuthyTray()
        {
            InitializeComponent();
        }

        Boolean isClosed = false;
        static String localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static String authyTrayPath = localAppData + "\\authy\\AuthyTray.exe";
        static String authyPath = localAppData + "\\authy\\Authy Desktop.exe";
        static String authyProcessName = "Authy Desktop";

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsAdministrator())
            {
                RunOnStartup();
                MessageBox.Show("Succesfully installed to startup ! You can now restart your computer.");
                Application.Exit();
            } else
            {
                // Hide application UI at Start 
                BeginInvoke(new MethodInvoker(delegate {
                    this.ShowInTaskbar = false;
                    Hide();
                }));

                // Run Authy at start
                Process.Start(authyPath);
                timer1.Start();
            }


        }


        private void BallonTipClick(object sender, EventArgs e)
        {
            try
            {
                MouseEventArgs mouseClick = (MouseEventArgs)e;
                if (mouseClick.Button.ToString() == "Left")
                {
                    contextMenuStrip1.Hide();

                    if (isClosed)
                        Process.Start(authyPath);
                    else
                        foreach (var process in Process.GetProcessesByName(authyProcessName))
                            process.Kill();

                    // Reverse the boolean for next click 
                    isClosed = !isClosed;
                }
                else if (mouseClick.Button.ToString() == "Right")
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            } catch { };
        }


        // Put back the status to valid depending of the current Authy process status
        private void ProcessStatusChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            var authyProcessFound = false;
            foreach (var process in Process.GetProcessesByName(authyProcessName))
                authyProcessFound = true;

            if (!authyProcessFound && !isClosed)
                isClosed = true;
            else if (authyProcessFound && isClosed)
                isClosed = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProcessStatusChecker.RunWorkerAsync();
        }

        private void AuthyTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName(authyProcessName))
                process.Kill();
            Application.Exit();
        }

        public static void RunOnStartup()
        {
            try
            {
                string destinationPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";
                File.Copy(Environment.GetCommandLineArgs()[0], destinationPath + @"\AuthyTray.exe");
            } catch
            {
                MessageBox.Show("AuthyTray is already installed ! ");
                Application.Exit();
            }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

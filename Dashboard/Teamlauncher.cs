using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaimMCTeam
{
    public partial class Teamlauncher : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nButtomRect,
            int nWidghtEllipse,
            int nHeightEllipse
            );

        public Teamlauncher()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = dashboard.Height;
            pnlNav.Top = dashboard.Top;
            pnlNav.Left = dashboard.Left;
            dashboard.BackColor = Color.FromArgb(46, 51, 73);

            label9.Text = "Dashboard";

            this.dashboardloader.Controls.Clear();
            Dashboard.dashboard_design dashboard_Design = new Dashboard.dashboard_design() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard_Design.FormBorderStyle = FormBorderStyle.None;
            this.dashboardloader.Controls.Add(dashboard_Design);
            dashboard_Design.Show();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = dashboard.Height;
            pnlNav.Top = dashboard.Top;
            pnlNav.Left = dashboard.Left;
            dashboard.BackColor = Color.FromArgb(46, 51, 73);

            label9.Text = "Dashboard";

            this.dashboardloader.Controls.Clear();
            Dashboard.dashboard_design dashboard_Design = new Dashboard.dashboard_design() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard_Design.FormBorderStyle = FormBorderStyle.None;
            this.dashboardloader.Controls.Add(dashboard_Design);
            dashboard_Design.Show();
        }

        private void teamcloud_Click(object sender, EventArgs e)
        {
            pnlNav.Height = teamcloud.Height;
            pnlNav.Top = teamcloud.Top;
            pnlNav.Left = teamcloud.Left;
            teamcloud.BackColor = Color.FromArgb(46, 51, 73);

            label9.Text = "Team Cloud";

            this.dashboardloader.Controls.Clear();
            Team.Teamcloud teamCloud = new Team.Teamcloud() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            teamCloud.FormBorderStyle = FormBorderStyle.None;
            this.dashboardloader.Controls.Add(teamCloud);
            teamCloud.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

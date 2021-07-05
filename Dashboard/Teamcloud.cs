using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ClaimMCTeam.Team
{
    public partial class Teamcloud : Form
    {
        public Teamcloud()
        {
            InitializeComponent();


            DateTime date1 = DateTime.Now;
            datumstring.Text = date1.ToString();

            MySQLMethods.InitializeDB();
            MySQLMethods.InsertPCData(Dns.GetHostName());

            if(MySQLMethods.connected == true)
            {
                conectioninfolabel.Text = "Connected!";
                conectioninfolabel.ForeColor = Color.Green;
            } else
            {
                conectioninfolabel.Text = "Disconnected!";
                conectioninfolabel.ForeColor = Color.Red;
            }

        }

        private void dashboard_Click(object sender, EventArgs e)
        {

            label9.Text = "Cloud";

            this.dashboard.das.Controls.Clear();
            Team.Teamcloud teamCloud = new Team.Teamcloud() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            teamCloud.FormBorderStyle = FormBorderStyle.None;
            this.dashboardloader.Controls.Add(teamCloud);
            teamCloud.Show();
        }
    }
}

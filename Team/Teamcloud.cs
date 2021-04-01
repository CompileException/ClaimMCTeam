using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
    }
}

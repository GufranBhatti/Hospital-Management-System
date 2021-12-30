using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorPanel doctorPanel = new DoctorPanel();
            doctorPanel.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientPanel patientPanel = new PatientPanel();
            patientPanel.Show();
            this.Hide();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

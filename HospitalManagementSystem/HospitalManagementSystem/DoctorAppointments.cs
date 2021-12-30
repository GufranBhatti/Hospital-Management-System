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
    public partial class DoctorAppointments : Form
    {
        public DoctorAppointments()
        {
            InitializeComponent();
        }
        public void display()
        {
            DatabaseOps databaseOps = new DatabaseOps();
            dataGridView1.DataSource = databaseOps.displayappointments("PATIENTS");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DoctorLogin doctorLogin = new DoctorLogin();
            this.Hide();
            doctorLogin.Show();
        }

        private void DoctorAppointments_Load(object sender, EventArgs e)
        {
            label3.Text = DoctorLogin.id.ToString();
            display();
        }
    }
}

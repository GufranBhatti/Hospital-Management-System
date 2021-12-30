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
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();

        }
        public void displaydoc()
        {
            DatabaseOps databaseOps = new DatabaseOps();
            dataGridView1.DataSource=databaseOps.displaydoc();
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            displaydoc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient()
            {
                firstName = textBox1.Text,
                lastName = textBox2.Text,
                Gender = comboBox1.Text,
                age=Convert.ToInt32(textBox4.Text),
                Tel = textBox3.Text,
                DOC_ID=Convert.ToInt32(textBox5.Text),
                address=textBox6.Text

            };
            DatabaseOps insertDoc = new DatabaseOps();
            insertDoc.insert(patient);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

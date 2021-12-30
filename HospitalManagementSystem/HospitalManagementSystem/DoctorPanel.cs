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
    public partial class DoctorPanel : Form
    {
        public DoctorPanel()
        {
            InitializeComponent();
        }

        public void display()
        {
            DatabaseOps databaseOps = new DatabaseOps();
            dataGridView1.DataSource = databaseOps.display("DOCTORS");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor()
            {
                firstName = textBox1.Text,
                lastName = textBox2.Text,
                Gender = comboBox1.Text,
                fees = textBox4.Text,
                Tel = textBox3.Text,
                speciality = textBox6.Text,
                days = comboBox2.Text,
                timing=textBox7.Text,
                Pass=textBox8.Text,
                
            };
            DatabaseOps insertDoc = new DatabaseOps();
            insertDoc.insert(doctor);
            display();
        }

        private void DoctorPanel_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor()
            {
                ID = Convert.ToInt32(textBox5.Text),
                firstName = textBox1.Text,
                lastName = textBox2.Text,
                Gender = comboBox1.Text,
                fees=textBox4.Text,
                Tel = textBox3.Text,
                speciality=textBox6.Text,
                days=comboBox2.Text,
                timing=textBox7.Text,
                Pass=textBox8.Text,
            };
            DatabaseOps updateDoc = new DatabaseOps();
            updateDoc.update(doctor);
            display();
 
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
            {
                comboBox1.Text = "Male";
            }
            else
            {
                comboBox1.Text = "Female";
            }
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Monday")
            {
                comboBox2.Text = "Monday";
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Tuesday")
            {
                comboBox2.Text = "Tuesday";
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Wednesday")
            {
                comboBox2.Text = "Wednesday";
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Thursday")
            {
                comboBox2.Text = "Thursday";
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "Friday")
            {
                comboBox2.Text = "Friday";
            }
            else
            {
                comboBox2.Text = "Saturday";
            }
            textBox7.Text= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length != 0)
            {
                DatabaseOps databaseOps = new DatabaseOps();
                databaseOps.delete("DOCTORS", textBox5.Text);
                display();
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            display();
        }
    }
}


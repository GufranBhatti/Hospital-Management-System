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
    public partial class DoctorLogin : Form
    {
        public DoctorLogin()
        {
            InitializeComponent();
        }
        public static int id;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DoctorLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                logindoctor logindoctor=new logindoctor
                {
                    ID = textBox1.Text,
                    Pass = textBox2.Text
                };
                id = Convert.ToInt32(textBox1.Text);
                logindoctor.login(logindoctor);
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
   
    }
    public class logindoctor
    {
        public string ID { get; set; }
        public string Pass { get; set; }

        public void login(logindoctor doctorLogin)
        {
            DatabaseOps databaseOps = new DatabaseOps();
            databaseOps.login(doctorLogin);
        }
    }
}

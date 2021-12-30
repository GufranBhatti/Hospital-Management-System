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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
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
                UserLogin userLogin = new UserLogin()
                {
                    Username = textBox1.Text,
                    Pass = textBox2.Text
                };
                userLogin.login(userLogin);
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }
    }
    public class UserLogin
    {
        public string Username { get; set; }
        public string Pass { get; set; }

        public void login(UserLogin userLogin)
        {
            DatabaseOps databaseOps = new DatabaseOps();
            databaseOps.login(userLogin);
        }
    }
}

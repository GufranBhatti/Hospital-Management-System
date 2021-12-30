using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    class DatabaseOps
    {
        internal static string connection_string = @"Data Source=DESKTOP-HVATEDP\SQLEXPRESS; Initial Catalog=HMS; Integrated Security=True";
        internal SqlConnection sqlConnection;
        internal SqlDataAdapter sqlDataAdapter;
        internal SqlCommand sqlCommand;

        public DatabaseOps()
        {
            sqlConnection = new SqlConnection(connection_string);
        }

        public void login(UserLogin userLogin)
        {
            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM ADMIN WHERE USERNAME = '" + userLogin.Username + "' AND PASS = '" + userLogin.Pass + "'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                    AdminLogin adminLogin = new AdminLogin();
                    adminLogin.Hide();
                }
                else
                {
                    MessageBox.Show("Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void login(logindoctor logindoctor)
        {
            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM DOCTORS WHERE ID = '" + logindoctor.ID + "' AND PASSWORD = '" + logindoctor.Pass + "'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    DoctorAppointments doctorAppointments = new DoctorAppointments();
                    doctorAppointments.Show();
                    DoctorLogin doctorLogin = new DoctorLogin();
                    doctorLogin.Hide();
                }
                else
                {
                    MessageBox.Show("Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insert(Doctor doctor)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("INSERT INTO DOCTORS(FIRSTNAME, LASTNAME, GENDER, FEES, CONTACTNO, SPECIALITY, DAYS, TIMINGS, USERNAME, PASSWORD) VALUES (@firstname,@lastname,@gender,@fees,@tel,@speciality,@days,@timings,@username,@pass)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@firstname", doctor.firstName);
                sqlCommand.Parameters.AddWithValue("@lastname", doctor.lastName);
                sqlCommand.Parameters.AddWithValue("@gender", doctor.Gender);
                sqlCommand.Parameters.AddWithValue("@fees", doctor.fees);
                sqlCommand.Parameters.AddWithValue("@tel", doctor.Tel);
                sqlCommand.Parameters.AddWithValue("@speciality", doctor.speciality);
                sqlCommand.Parameters.AddWithValue("@days", doctor.days);
                sqlCommand.Parameters.AddWithValue("@timings", doctor.timing);
                sqlCommand.Parameters.AddWithValue("@username", doctor.firstName);
                sqlCommand.Parameters.AddWithValue("@pass", doctor.Pass);
                int a = sqlCommand.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Registered Successfully", "Registered", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data not inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable display(string value)
        {
            sqlConnection.Open();
            if (value == "PATIENTS")
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM PATIENTS", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;

            }
            else 
            {
                sqlDataAdapter = new SqlDataAdapter("select * from " + value + "", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;
            }

                
        }
        public DataTable displaydoc()
        {
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter("select FIRSTNAME,LASTNAME,FEES,SPECIALITY,DAYS,TIMINGS from DOCTORS", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable displayappointments(string value)
        {
            sqlConnection.Open();
            if (value == "PATIENTS")
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM PATIENTS WHERE DOC_ID = '" + DoctorLogin.id + "'", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;

            }
            else
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM " + value + "", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;
            }
        }
            public void insert(Patient patient)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("INSERT INTO PATIENTS(FIRSTNAME, LASTNAME, GENDER, AGE, CONTACTNO, DOC_ID, ADDRESS) VALUES (@firstname,@lastname,@gender,@age,@tel,@doc_id,@address)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@firstname", patient.firstName);
                sqlCommand.Parameters.AddWithValue("@lastname", patient.lastName);
                sqlCommand.Parameters.AddWithValue("@gender", patient.Gender);
                sqlCommand.Parameters.AddWithValue("@age", patient.age);
                sqlCommand.Parameters.AddWithValue("@tel", patient.Tel);
                sqlCommand.Parameters.AddWithValue("@doc_id", patient.DOC_ID);
                sqlCommand.Parameters.AddWithValue("@address", patient.address);

                int a = sqlCommand.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Registered Successfully", "Registered", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data not inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void update(Doctor doctor)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("UPDATE DOCTORS SET FIRSTNAME = @firstname, LASTNAME = @lastname, GENDER = @GENDER, FEES = @fees, CONTACTNO = @TEL, SPECIALITY = @speciality, DAYS = @days, TIMINGS = @timing,USERNAME=@username, PASSWORD = @pass WHERE ID = @ID", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ID", doctor.ID);
                sqlCommand.Parameters.AddWithValue("@firstname", doctor.firstName);
                sqlCommand.Parameters.AddWithValue("@lastname", doctor.lastName);
                sqlCommand.Parameters.AddWithValue("@GENDER", doctor.Gender);
                sqlCommand.Parameters.AddWithValue("@fees", doctor.fees);
                sqlCommand.Parameters.AddWithValue("@TEL", doctor.Tel);
                sqlCommand.Parameters.AddWithValue("@speciality",doctor.speciality);
                sqlCommand.Parameters.AddWithValue("@days", doctor.days);
                sqlCommand.Parameters.AddWithValue("@timing", doctor.timing);
                sqlCommand.Parameters.AddWithValue("@username", doctor.firstName);
                sqlCommand.Parameters.AddWithValue("@pass", doctor.Pass);
                int a = sqlCommand.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to updated Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void update(Patient patient)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("UPDATE PATIENTS SET FIRSTNAME = @firstname, LASTNAME = @lastname, GENDER = @GENDER, AGE=@age, CONTACTNO=@TEL, DOC_ID=@docid, ADDRESS=@add   WHERE PAT_ID = @PAT_ID", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PAT_ID", patient.ID);
                sqlCommand.Parameters.AddWithValue("@firstname", patient.firstName);
                sqlCommand.Parameters.AddWithValue("@lastname", patient.lastName);
                sqlCommand.Parameters.AddWithValue("@GENDER", patient.Gender);
                sqlCommand.Parameters.AddWithValue("@age", patient.age);
                sqlCommand.Parameters.AddWithValue("@TEL", patient.Tel);
                sqlCommand.Parameters.AddWithValue("@docid", patient.DOC_ID);
                sqlCommand.Parameters.AddWithValue("@add", patient.address);

                int a = sqlCommand.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to updated Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delete(string tableValue,string id)
        {
            try
            {
                sqlConnection.Open();
                if (tableValue == "DOCTORS")
                {
                    sqlCommand = new SqlCommand("DELETE FROM DOCTORS WHERE ID = @ID",sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ID", id);
                }
                else if (tableValue == "PATIENTS")
                {
                    sqlCommand = new SqlCommand("DELETE FROM PATIENTS WHERE PAT_ID = @PID",
                    sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@PID", id);
                }
                else
                {
                    MessageBox.Show("Unable to delete Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlCommand.ExecuteNonQuery();
                int a = sqlCommand.ExecuteNonQuery();
                if (a == 0)
                {
                    MessageBox.Show("Data Deleted Successfully", "Deleted", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to delete Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

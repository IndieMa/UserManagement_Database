using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserManagementDatabase
{
    public partial class frmLogin : Form
    {
        string cs = @"Data Source=(LOCALDB)\MSSQLLocalDB;Initial Catalog=usermanagement;Integrated Security=True;";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please provide your Email and Password");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Select * from tblUserManagement where Email=@email and Password=@password", con);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@password", textBoxPassword.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                //MessageBox.Show($"{ds.Tables[0].Rows[0]["Email"].ToString()} {ds.Tables[0].Rows[0]["Password"].ToString()}");
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    var formUser = new frmUser();
                    formUser.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed!");
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

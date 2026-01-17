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
using System.Diagnostics.Eventing.Reader;

namespace PROJECT_SYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string SellerName = "";
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True");
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Username and Password");
            }
            else if (cbSelectRole.SelectedIndex == -1)
            {
                MessageBox.Show("Select the role to login");
            }
            else
            {
                if (cbSelectRole.SelectedItem.ToString() == "Admin")
                {
                    if (username == "SHAHMEER" && password == "ALI")
                    {
                        Product_Form prod = new Product_Form();
                        prod.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("If you are admin, please enter correct Username and Password");
                    }
                }
                else if (cbSelectRole.SelectedItem.ToString() == "Seller")
                {
                    MessageBox.Show("You are in the seller section");
                    // Use parameterized query to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SellersTable WHERE SellerName = @Username AND SellerPassword = @Password", Con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        Con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        Con.Close();

                        if (count == 1)
                        {
                            SellerName = username;
                            Selling_Form sell = new Selling_Form();
                            sell.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username and Password");
                        }
                    }
                }
            }
        }
    }
}

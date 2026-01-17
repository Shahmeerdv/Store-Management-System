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
using System.Linq.Expressions;

namespace PROJECT_SYSTEM
{
    public partial class Seller_Form : Form,IPopulate
    {
        public Seller_Form()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True");
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO SellersTable VALUES (@SellerID, @SellerName, @SellerAge, @SellerMobileNo, @SellerPassword)";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@SellerID", txtSellerID.Text);
                cmd.Parameters.AddWithValue("@SellerName", txtSellerName.Text);
                cmd.Parameters.AddWithValue("@SellerAge", txtSellerAge.Text);
                cmd.Parameters.AddWithValue("@SellerMobileNo", txtSellerMobileNo.Text);
                cmd.Parameters.AddWithValue("@SellerPassword", txtSellerPassword.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");
                Con.Close();
                populate();
                txtSellerID.Text = "";
                txtSellerName.Text = "";
                txtSellerAge.Text = "";
                txtSellerMobileNo.Text = "";
                txtSellerPassword.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSellerID.Text == "" || txtSellerName.Text == "" || txtSellerAge.Text == "" || txtSellerMobileNo.Text == "" || txtSellerPassword.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True"))
                    {
                        Con.Open();

                        string query = "UPDATE SellersTable SET SellerName = @SellerName, SellerAge = @SellerAge, SellerMobileNo = @SellerMobileNo, SellerPassword = @SellerPassword WHERE SellerId = @SellerId";

                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@SellerName", txtSellerName.Text);
                        cmd.Parameters.AddWithValue("@SellerAge", Convert.ToInt32(txtSellerAge.Text));
                        cmd.Parameters.AddWithValue("@SellerMobileNo", txtSellerMobileNo.Text);
                        cmd.Parameters.AddWithValue("@SellerPassword", txtSellerPassword.Text);
                        cmd.Parameters.AddWithValue("@SellerId", txtSellerID.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Seller successfully updated");
                        populate();

                        txtSellerID.Text = "";
                        txtSellerName.Text = "";
                        txtSellerAge.Text = "";
                        txtSellerMobileNo.Text = "";
                        txtSellerPassword.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSellerID.Text == "")
                {
                    MessageBox.Show("Select The Seller to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "DELETE FROM SellersTable WHERE SellerId = @SellerId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@SellerId", txtSellerID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller deleted successfully");
                    Con.Close();
                    populate();

                    txtSellerID.Text = "";
                    txtSellerName.Text = "";
                    txtSellerAge.Text = "";
                    txtSellerMobileNo.Text = "";
                    txtSellerPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from SellersTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Seller_Form_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selling_Form sell = new Selling_Form();
            sell.Show();
            this.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            Category_Form cat = new Category_Form();
            cat.Show();
            this.Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Product_Form product = new Product_Form();
            product.Show();
            this.Hide();
        }
    }
} 

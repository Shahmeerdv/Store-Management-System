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

namespace PROJECT_SYSTEM
{
    public partial class Category_Form : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True");

        public Category_Form()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM CaregoriesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CategoriesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO CaregoriesTbl VALUES (@CategoryID, @CategoryName, @CategoryDescription)";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@CategoryDescription", txtCategoryDescription.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                Con.Close();
                populate();
                txtCategoryID.Text = "";
                txtCategoryName.Text = "";
                txtCategoryDescription.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Category_Form_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CategoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryID.Text = CategoriesDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtCategoryName.Text = CategoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtCategoryDescription.Text = CategoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryID.Text == "" || txtCategoryName.Text == "" || txtCategoryDescription.Text == "")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    Con.Open();
                    string query = "UPDATE CaregoriesTbl SET CatName=@CategoryName, CatDesc=@CategoryDescription WHERE CatID=@CategoryID";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@CategoryDescription", txtCategoryDescription.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category has been updated successfully");
                    Con.Close();
                    populate();
                    txtCategoryID.Text = "";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
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
                if (txtCategoryID.Text == "")
                {
                    MessageBox.Show("Select Category ID to be deleted");
                }
                else
                {
                    Con.Open();
                    string query = "DELETE FROM CaregoriesTbl WHERE CatID=@CategoryID";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category has been deleted");
                    Con.Close();
                    populate();
                    txtCategoryID.Text = "";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnSellers_Click(object sender, EventArgs e)
        {
            Seller_Form Sell = new Seller_Form();
            Sell.Show();
            this.Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Product_Form prod = new Product_Form();
            prod.Show();
            this.Hide();
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            Selling_Form sell = new Selling_Form();
            sell.Show();
            this.Hide();
        }

        private void btnSelling_Click_1(object sender, EventArgs e)
        {
            Selling_Form sell = new Selling_Form();
            sell.Show();
            this.Hide();
        }
    }
}

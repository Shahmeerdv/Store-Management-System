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
    public partial class Product_Form : Form
    {
        public Product_Form()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into ProductsTbl values('" + txtProductID.Text + "','" + txtProductName.Text + "','" + txtProductQuantity.Text + "','" + txtProductPrice.Text + "','" + cbSelectCategory.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
                Con.Close();
                populate();
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtProductQuantity.Text = "";
                txtProductPrice.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillCategory()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CaregoriesTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            cbSearchCategory.ValueMember = "CatName";
            cbSearchCategory.DataSource = dt;
            cbSelectCategory.ValueMember = "CatName";
            cbSelectCategory.DataSource = dt;
            Con.Close();

        }

        private void populate()
        {
            Con.Open();
            string query = "Select * from ProductsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Product_Form_Load(object sender, EventArgs e)
        {
            FillCategory();
            populate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = ProductsDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtProductName.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtProductQuantity.Text = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtProductPrice.Text = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
            cbSelectCategory.SelectedValue = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text == "" || txtProductName.Text == "" || txtProductQuantity.Text == "" || txtProductPrice.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update ProductsTbl set ProdName = '" + txtProductName.Text + "', ProdQty=" + txtProductQuantity.Text + ", ProdPrice= " + txtProductPrice.Text + ", ProdCat='" + cbSelectCategory.SelectedValue.ToString() + "' where ProdId=" + txtProductID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated");
                    Con.Close();
                    populate();
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtProductQuantity.Text = "";
                    txtProductPrice.Text = "";
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
                if (txtProductID.Text == "")
                {
                    MessageBox.Show("Select the Product to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ProductsTbl where ProdId='" + txtProductID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");
                    Con.Close();
                    populate();
                    txtProductID.Text = "";
                    txtProductName.Text = "";
                    txtProductQuantity.Text = "";
                    txtProductPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void cbSearchCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select * from ProductsTbl where ProdCat='" + cbSearchCategory.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void cbSelectCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void cbSelectCategory_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
          
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

        private void button1_Click(object sender, EventArgs e)
        {
            Seller_Form sell = new Seller_Form();
            sell.Show();
            this.Hide();
        }
    }
}

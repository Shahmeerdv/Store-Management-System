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
    public partial class Selling_Form : Form
    {
        public Selling_Form()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shahmeer\source\repos\PROJECT SYSTEM\PROJECT SYSTEM\SMMSD.mdf;Integrated Security=True");
        private void populate()
        {
            try
            {
                Con.Open();
                string query = "SELECT ProdName, ProdQty FROM ProductsTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ProDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void populatebills()
        {
            try
            {
                Con.Open();
                string query = "select * from BillsTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                BillsDGV.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Selling_Form_Load(object sender, EventArgs e)
        {
            populate();
            populatebills();
            FillCategory();
            lblSellerName.Text = Login.SellerName;
        }

        private void ProDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductName.Text = ProDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtProductQuantity.Text = ProDGV.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            lblDate.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" +DateTime.Today.Year.ToString();
        }

        private void FillCategory()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("select CatName from CategoriesTbl", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatName", typeof(string));
                dt.Load(rdr);

                cbSelectCategory.DisplayMember = "CatName";
                cbSelectCategory.ValueMember = "CatName";
                cbSelectCategory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtBillID.Text == "")
            {
                MessageBox.Show("Bill ID Missing");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into BillsTbl Values('" + txtBillID.Text + "','" + lblSellerName.Text + "','" + lblDate.Text + "'," + lblAmount.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("order added Successfully");
                    Con.Close();
                    populatebills();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int GrdTotal = 0, n = 0;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(PrintPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            e.Graphics.DrawString("Store Management System", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));

            
            e.Graphics.DrawString("Bill ID: " + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(100, 70));

         
            e.Graphics.DrawString("Seller Name: " + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(100, 100));

            
            e.Graphics.DrawString("Bill Date: " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(100, 130));

          
            e.Graphics.DrawString("Total Amount: " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(100, 160));

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void cbSelectCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ProdName,ProdQty from ProductsTbl where ProdCat='" + cbSelectCategory.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller_Form sell = new Seller_Form();
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
            Product_Form pro = new Product_Form();
            pro.Show();
            this.Hide();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "" || txtProductQuantity.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    int total = Convert.ToInt32(txtProductPrice.Text) * Convert.ToInt32(txtProductQuantity.Text);
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(OrdersDGV);
                    newRow.Cells[0].Value = n + 1;
                    newRow.Cells[1].Value = txtProductName.Text;
                    newRow.Cells[2].Value = txtProductQuantity.Text;
                    newRow.Cells[3].Value = txtProductPrice.Text;
                    newRow.Cells[4].Value = total;
                    OrdersDGV.Rows.Add(newRow);
                    n++;
                    GrdTotal += total;
                    lblAmount.Text = GrdTotal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

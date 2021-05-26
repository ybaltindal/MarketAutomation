using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewMarketAutomotion
{
    public partial class Product : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4PUM0TH\\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");
        int id;

        public Product()
        {
            InitializeComponent();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Connect.Open();
                SqlCommand Command = new SqlCommand("insert into Product values(@ProductName,@ProductNo,@ProductCategory,@ProductDate,@ProductExpDate,@ProductQuantity,@ProductPrice,@ProductTotalCost,@ProductUser,@ProductActivity)", Connect);
                
                Command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                Command.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);
                Command.Parameters.AddWithValue("@ProductCategory", txtProductCategory.Text);
                Command.Parameters.AddWithValue("@ProductDate", txtProductDate.Text);
                Command.Parameters.AddWithValue("@ProductExpDate", txtProductExpDate.Text);
                Command.Parameters.AddWithValue("@ProductQuantity", txtSalesQuantity.Text);
                Command.Parameters.AddWithValue("@ProductPrice", txtProductSalesPrice.Text);
                Command.Parameters.AddWithValue("@ProductTotalCost", txtTotalSlsCost.Text);
                Command.Parameters.AddWithValue("@ProductUser", txtProductUser.Text);
                Command.Parameters.AddWithValue("@ProductActivity", "True");
                Command.ExecuteNonQuery();                
                Connect.Close();
                this.productTableAdapter.Fill(this.marketOtomasyonDataSet.Product);
                MessageBox.Show("Registration Completed.");      
                

            }
            catch (Exception)
            {

                MessageBox.Show("Registration not Completed.");
                
            }

            this.TraverseControlsAndSetTextEmpty(this);


        }
        private void TraverseControlsAndSetTextEmpty(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var box = c as TextBox;
                if (box != null)
                {
                    box.Text = string.Empty;
                }

                this.TraverseControlsAndSetTextEmpty(c);
            }
        }

    
        
     

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.marketOtomasyonDataSet.Product);
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.marketOtomasyonDataSet.Employee);
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet3.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.marketOtomasyonDataSet.Product);
            
            
            

        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("delete Product where ProductID = @ProductID", Connect);
            Command.Parameters.AddWithValue("@ProductID", id);
            Command.ExecuteNonQuery();          
            Connect.Close();
            this.productTableAdapter.Fill(this.marketOtomasyonDataSet.Product);
            MessageBox.Show("Deleted.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtProductName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductNo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtProductCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProductDate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProductExpDate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSalesQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtProductSalesPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTotalSlsCost.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtProductUser.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("update Product set ProductName = @ProductName,ProductNo=@ProductNo,ProductCategory = @ProductCategory,ProductDate=@ProductDate,ProductExpDate = @ProductExpDate,ProductQuantity=@ProductQuantity,ProductPrice = @ProductPrice,ProductTotalCost=ProductTotalCost,ProductUser=@ProductUser where ProductID=@ProductID", Connect);
            Command.Parameters.AddWithValue("@ProductID", id);
            Command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            Command.Parameters.AddWithValue("@ProductNo", txtProductNo.Text);
            Command.Parameters.AddWithValue("@ProductCategory", txtProductCategory.Text);
            Command.Parameters.AddWithValue("@ProductDate", txtProductDate.Text);
            Command.Parameters.AddWithValue("@ProductExpDate", txtProductExpDate.Text);
            Command.Parameters.AddWithValue("@ProductQuantity", txtSalesQuantity.Text);            
            Command.Parameters.AddWithValue("@ProductPrice", txtProductSalesPrice.Text);       
            Command.Parameters.AddWithValue("@ProductTotalCost", txtTotalSlsCost.Text);
            Command.Parameters.AddWithValue("@ProductUser", txtProductUser.Text);
            Command.Parameters.AddWithValue("@ProductActivity", "True");
            Command.ExecuteNonQuery();
            Connect.Close();
            this.productTableAdapter.Fill(this.marketOtomasyonDataSet.Product);
            MessageBox.Show("Update Completed");
            this.TraverseControlsAndSetTextEmpty(this);
        }
    }
}

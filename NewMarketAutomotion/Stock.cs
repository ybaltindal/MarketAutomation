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

    public partial class Stock : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4PUM0TH\\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");
        int id;
        public Stock()
        {
            InitializeComponent();
        }

        public void comboFill3()
        {
            Connect.Open();
            SqlCommand cmd = new SqlCommand("select ProductName from Product", Connect);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                cmbProductName.Items.Add(Reader["ProductName"].ToString());

            }
            Connect.Close();

        }
        

        

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Connect.Open();
                string str = "select * from Product where ProductName ='" + cmbProductName.Text + "'";
                SqlCommand cmd = new SqlCommand(str, Connect);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtStockNo.Text = dr["ProductNo"].ToString();//column name should be that you want to show on textbox
                                                                 //txtProductQuantity.Text = dr["ProductSalesQuantity"].ToString();

                    txtStockQuantity.Text = dr["ProductQuantity"].ToString();
                    txtStockDepot.Text = dr["ProductCategory"].ToString();

                }
                Connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connect.Open();
                SqlCommand Command = new SqlCommand("insert into Stock values(@StockNo,@StockQuantity,@StockDepot,@ProductName)", Connect);

                
                Command.Parameters.AddWithValue("@StockNo", txtStockNo.Text);
                Command.Parameters.AddWithValue("@StockQuantity", txtStockQuantity.Text);
                Command.Parameters.AddWithValue("@StockDepot", txtStockDepot.Text);
                Command.Parameters.AddWithValue("@ProductName", cmbProductName.Text);
                
                Command.ExecuteNonQuery();
                
                Connect.Close();
                
                MessageBox.Show("Registration Completed.");


            }
            catch (Exception)
            {

                MessageBox.Show("Registration not Completed.");

            }
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void Stock_Load_1(object sender, EventArgs e)
        {
            comboFill3();
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
        private void button3_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("update Stock set StockDepot=@StockDepot where StockID=@StockID", Connect);
            Command.Parameters.AddWithValue("@StockID", id);
            Command.Parameters.AddWithValue("@StockDepot", txtStockDepot.Text);
        
            Command.ExecuteNonQuery();
            Connect.Close();
            
            MessageBox.Show("Update Completed");
            this.TraverseControlsAndSetTextEmpty(this);
        }
    }
    }

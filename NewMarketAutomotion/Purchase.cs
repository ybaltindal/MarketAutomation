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
    public partial class Sales : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4PUM0TH\\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");

        int id;
        public Sales()
        {
            InitializeComponent();
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

        private void txtTotalCost_Click(object sender, EventArgs e)
        {

        }

        
            



            //Connect.Open();

            //SqlCommand cmd2 = new SqlCommand("select * from Product where ProductName=@ProductName", Connect);
            //cmd.Parameters.AddWithValue("@ProductName", cmbItemName.Text);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //da.Fill(dt);

            //cmbItemName.DataSource = dt;
            //cmbItemName.DisplayMember = "ProductName";
            //cmbItemName.SelectedIndex = -1;
            //Connect.Close();

            

        
        //public void comboFill2()
        //{
        //    Connect.Open();
        //    SqlCommand cmd = new SqlCommand("select ProductCategory from Product", Connect);
        //    SqlDataReader Reader = cmd.ExecuteReader();
        //    while (Reader.Read())
        //    {
        //        cmbCategory.Items.Add(Reader["ProductCategory"].ToString());

        //    }
        //    Connect.Close();

        //}
        public void comboFill3()
        {
            Connect.Open();
            SqlCommand cmd = new SqlCommand("select ProductName from Product order by ProductName", Connect);
            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                cmbItemName.Items.Add(Reader["ProductName"].ToString());

            }
            Connect.Close();

        }


            private void Sales_Load(object sender, EventArgs e)
        {
            
           
            comboFill3();
        }

        private void cmbItemID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect.Open();
            string str = "select * from Product where ProductName ='" + cmbItemName.Text + "'";
            SqlCommand cmd = new SqlCommand(str, Connect);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtExpirationDate.Text = dr["ProductExpDate"].ToString();//column name should be that you want to show on textbox
                //txtProductQuantity.Text = dr["ProductSalesQuantity"].ToString();
                txtProductPrice.Text = dr["ProductPrice"].ToString();
                txtItemID.Text = dr["ProductID"].ToString();
                txtCategory.Text = dr["ProductCategory"].ToString();
            }
            Connect.Close();
        }

        private void btnTotalCost_Click(object sender, EventArgs e)
        {
            double val1 = Convert.ToDouble(txtProductPrice.Text);
            double val2 = Convert.ToDouble(txtProductQuantity.Text);
            double val3 = val1 * val2;
            txtTotalCost.Text = val3.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                Connect.Open();
                SqlCommand Command = new SqlCommand();
                Command.Connection = Connect;
                Command.CommandText = " update Product set ProductQuantity = ProductQuantity - " + Convert.ToDouble(txtProductQuantity.Text) + "where ProductID =" + Convert.ToInt32(txtItemID.Text);
                
                
                Command.ExecuteNonQuery();

                Connect.Close();
                //if (dr.Read())
                //{
                //    txtProductQuantity.Text = dr["ProductQuantity"].ToString();//column name should be that you want to show on textbox
                //    //txtProductQuantity.Text = dr["ProductSalesQuantity"].ToString();

                //}
                btnRepay.Visible = true;
                MessageBox.Show("Payment Completed.");
            }
            catch (Exception)
            {

                MessageBox.Show("Payment Not Completed.");
            }
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void btnRepay_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = Connect;

            command.CommandText = "update Product set ProductQuantity = ProductQuantity + " + Convert.ToDouble(txtProductQuantity.Text) + "where ProductID =" + Convert.ToInt32(txtItemID.Text);
            command.ExecuteNonQuery();

            Connect.Close();
            btnRepay.Visible = false;
            MessageBox.Show("Refund Is Completed.");
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


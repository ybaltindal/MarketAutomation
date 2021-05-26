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
    
    public partial class UserAdd : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=Data Source=DESKTOP-4PUM0TH\\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");
        int id;
        public UserAdd()
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

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Connect.Open();
                SqlCommand Command = new SqlCommand("insert into Login values(@Username,@Password,@Activity)", Connect);
                Command.Parameters.AddWithValue("@Username", txtUsername.Text);
                Command.Parameters.AddWithValue("@Password", txtPassword.Text);
                Command.Parameters.AddWithValue("@Activity", "True");
                Command.ExecuteNonQuery();
                this.loginTableAdapter.Fill(this.marketOtomasyonDataSet.Login);
                Connect.Close();
                
                MessageBox.Show("Registration Completed.");
            }
            catch (Exception)
            {

                MessageBox.Show("Registration not Completed.");
            }
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.marketOtomasyonDataSet.Login);
            
            // BUTON CLICK EVENTINDEN SONRA GRIDDEKİ BİLGİLERİN GÜNCELLENMESİ İÇİN BU KODU CONNECT.CLOSE();'dan SONRA BELİRTİLMELİ.
        }



        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("update Login set Username=@Username,Password=@Password where LoginID=@LoginID", Connect);
            Command.Parameters.AddWithValue("@LoginID", id); // ID DEĞİŞKENİNİ BURADA BELİRTTİM
            Command.Parameters.AddWithValue("@Username", txtUsername.Text);
            Command.Parameters.AddWithValue("@Password", txtPassword.Text);
            Command.ExecuteNonQuery();
            Connect.Close();
            
            MessageBox.Show("Update Completed");
            this.TraverseControlsAndSetTextEmpty(this);








        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("delete Login where LoginID = @LoginID", Connect);
            Command.Parameters.AddWithValue("@LoginID", id);
            Command.ExecuteNonQuery();
            Connect.Close();
           
            MessageBox.Show("Deleted.");
            

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }
    }
}

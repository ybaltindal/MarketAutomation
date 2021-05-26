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
    public partial class Login : Form
    {
        SqlConnection Connect = new SqlConnection(@"Data Source=DESKTOP-4PUM0TH\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("select * from Login L where L.Username = @Username and L.Password = @Password", Connect); //DB'de oluşturduğumuz username ve password u Command e attık.
            Command.Parameters.AddWithValue("@Username", txtLoginUsername.Text);
            Command.Parameters.AddWithValue("@Password", txtLoginPassword.Text);
            SqlDataReader Reader = Command.ExecuteReader(); //Komutun içine attığımız textboxları burada okuttuk.
            if (Reader.Read())
            {
                frmMenu frm = new frmMenu();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Connect.Close();
            this.Opacity = 0.0;


        }

        private void btnUserExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void txtLoginUsername_Click(object sender, EventArgs e)
        {
            txtLoginUsername.Text = " ";
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();

            }
            
        }
    }
}

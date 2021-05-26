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
    public partial class Employee : Form
    {
        SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-4PUM0TH\\SQLEXPRESS;Initial Catalog=MarketOtomasyon;Integrated Security=True");
        int id;
        public Employee()
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Connect.Open();
                SqlCommand Command = new SqlCommand("insert into Employee values(@FirstName,@LastName,@NationalID,@Birthday,@Phone,@Address,@Activity)", Connect);
                Command.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
                Command.Parameters.AddWithValue("@LastName", txtLastname.Text);
                Command.Parameters.AddWithValue("@NationalID", txtNationalID.Text);
                Command.Parameters.AddWithValue("@Birthday", txtBirthday.Text);
                Command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                Command.Parameters.AddWithValue("@Address", txtAddress.Text);
                Command.Parameters.AddWithValue("@Activity", "True");
                Command.ExecuteNonQuery();
                dataGridView1.Update();
                dataGridView1.Refresh();
                Connect.Close();
                this.employeeTableAdapter.Fill(this.marketOtomasyonDataSet.Employee);
                MessageBox.Show("Registration Completed.");
            }
            catch (Exception)
            {

                MessageBox.Show("Registration not Completed.");
            }
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("update Employee set FirstName =@FirstName,LastName=@LastName,NationalID = @NationalID,Birthday = @Birthday,Phone = @Phone,Address =@Address where EmployeeID=@EmployeeID", Connect);
            Command.Parameters.AddWithValue("@EmployeeID", id); // ID DEĞİŞKENİNİ BURADA BELİRTTİM //TELEFONDAYIM KONUŞMAIYORUM :D
            Command.Parameters.AddWithValue("@FirstName", txtFirstname.Text);
            Command.Parameters.AddWithValue("@LastName", txtLastname.Text);
            Command.Parameters.AddWithValue("@NationalID", txtNationalID.Text);
            Command.Parameters.AddWithValue("@Birthday", txtBirthday.Text);
            Command.Parameters.AddWithValue("@Phone", txtPhone.Text);
            Command.Parameters.AddWithValue("@Address", txtAddress.Text);
            Command.ExecuteNonQuery();            
            Connect.Close();
            this.employeeTableAdapter.Fill(this.marketOtomasyonDataSet.Employee);
            MessageBox.Show("Update Completed");
            this.TraverseControlsAndSetTextEmpty(this);
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.marketOtomasyonDataSet.Employee);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                txtFirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNationalID.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtBirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connect.Open();
            SqlCommand Command = new SqlCommand("delete Employee where EmployeeID = @EmployeeID", Connect);
            Command.Parameters.AddWithValue("@EmployeeID", id);
            Command.ExecuteNonQuery();
            dataGridView1.Update();
            dataGridView1.Refresh();
            Connect.Close();
            this.employeeTableAdapter.Fill(this.marketOtomasyonDataSet.Employee);
            MessageBox.Show("Deleted.");
        }
    }
}

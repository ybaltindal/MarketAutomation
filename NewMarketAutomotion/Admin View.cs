using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewMarketAutomotion
{
    public partial class Admin_View : Form
    {
        public Admin_View()
        {
            InitializeComponent();
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            UserAdd frm = new UserAdd();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
        }

        private void Admin_View_Load(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockData frm = new StockData();
            frm.Show();
        }

        
    }
}

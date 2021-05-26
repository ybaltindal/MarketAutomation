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
    public partial class frmMenu : Form
    {
        int mouseX = 0;
        int mouseY = 0;
        bool mouseDown;
        public frmMenu()
        {
            InitializeComponent();
        }

        
        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
        }

        private void userAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales frm = new Sales();
            frm.Show();
        }

        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_View frm = new Admin_View();
            frm.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock frm = new Stock();
            frm.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mouseDown = true;
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheckOut frm = new frmCheckOut();
            frm.Show();
        }
    }
}

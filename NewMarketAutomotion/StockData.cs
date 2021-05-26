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
    public partial class StockData : Form
    {
        public StockData()
        {
            InitializeComponent();
        }

        private void StockData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'marketOtomasyonDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.marketOtomasyonDataSet.Stock);

        }
    }
}

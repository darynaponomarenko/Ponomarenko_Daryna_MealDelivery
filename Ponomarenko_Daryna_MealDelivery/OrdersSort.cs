using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponomarenko_Daryna_MealDelivery
{
    public partial class OrdersSort : Form
    {
        public OrdersSort()
        {
            InitializeComponent();
        }

        private void BtnLoadOrders_Click(object sender, EventArgs e)
        {
            lbSort.Items.Clear();

            foreach (Order o in Form1.listO)
                o.WriteShortly(lbSort);
        }

        private void BtnSortAndLoad_Click(object sender, EventArgs e)
        {
            Form1.listO.Sort();

            lbSort.Items.Clear();
            foreach (Order o in Form1.listO)
                o.WriteShortly(lbSort);

        }
    }
}

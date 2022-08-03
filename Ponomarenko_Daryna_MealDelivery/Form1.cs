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
    public partial class Form1 : Form
    {
        IndividualOrderForm individualOrder = new IndividualOrderForm();
        GroupOrderForm groupOrder = new GroupOrderForm();
        ListOfOrders listOfOrders = new ListOfOrders();
        OperatorsForm operatorsForm = new OperatorsForm();
        public static List<Order> listO = new List<Order>();
        

        public Form1()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            individualOrder.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            groupOrder.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listOfOrders.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            operatorsForm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            double cost1 = 0;
            double cost2 = 0;

            double[] sumIO = IndividualOrderForm.sumIO.ToArray();
            double[] sumGO = GroupOrderForm.sumGO.ToArray();
            int n1 = 0;
            int n2 = 0;
            if(listO.Count !=0)
            {
                for(int i=0; i<sumIO.Length;i++)
                {
                    cost1 += sumIO[i];
                    n1++;

                }
                for(int i=0;i<sumGO.Length;i++)
                {
                    cost2 += sumGO[i];
                    n2++;
                }

                int nSum = n1 + n2;
                double averageCost = (cost1 + cost2) / nSum ;
                MessageBox.Show("Average cost of all orders equals: "+averageCost);
            }
            else
            {
                MessageBox.Show("The list is empty!");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OrdersSort ordersSort = new OrdersSort();
            ordersSort.ShowDialog();
        }
    }
}

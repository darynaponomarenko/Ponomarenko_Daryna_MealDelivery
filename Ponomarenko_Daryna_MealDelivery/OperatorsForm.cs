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
    public partial class OperatorsForm : Form
    {
        
        public OperatorsForm()
        {
            InitializeComponent();
        }

        

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt32(comboBox1.SelectedIndex);
            int id2 = Convert.ToInt32(comboBox2.SelectedIndex);

            
                if (IndividualOrderForm.listIO[id1] == IndividualOrderForm.listIO[id2])
                {
                    MessageBox.Show("Objects are equal!");
                }
                if (IndividualOrderForm.listIO[id1] != IndividualOrderForm.listIO[id2])
                {
                    MessageBox.Show("Objects are not equal!");
                }
            

        }

        private void ButtonGreaterThan_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt32(comboBox1.SelectedIndex);
            int id2 = Convert.ToInt32(comboBox2.SelectedIndex);

                if (IndividualOrderForm.listIO[id1] > IndividualOrderForm.listIO[id2])
                {
                    MessageBox.Show("First object costs more!");
                }
                else if(IndividualOrderForm.listIO[id1] < IndividualOrderForm.listIO[id2])
                {
                    MessageBox.Show("Second object costs more!");
                }
                else
                {
                    MessageBox.Show("Both objects cost the same!");
                }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (IndividualOrderForm.listIO.Count > 0)
            {
                buttonEquals.Enabled = true;
                buttonGreaterThan.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

                foreach (IndividualOrder io in IndividualOrderForm.listIO)
                {
                    io.ComboBoxAdd(comboBox1);
                    io.ComboBoxAdd(comboBox2);
                    
                }
               
            }
            else
            {
                
                MessageBox.Show("The list is empty!");
            }

        }
    }
}

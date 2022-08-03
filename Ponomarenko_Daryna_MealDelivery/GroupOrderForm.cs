using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponomarenko_Daryna_MealDelivery
{
    public partial class GroupOrderForm : Form
    {
        public static List<double> sumGO = new List<double>();

        public GroupOrderForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GroupOrder groupOrder = new GroupOrder((Bitmap)pictureBox1.Image);
            groupOrder.GetData(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
            groupOrder.PaymentMethod(comboBox1);
            groupOrder.NumberOfPeople(numericUpDown1);
            groupOrder.PlannedDeliveryDate(dateTimePicker1);
            groupOrder.TotalCost();
            groupOrder.OrderStatus();
            groupOrder.Write(listView1);
            Form1.listO.Add(groupOrder);

            float cost = groupOrder.TotalCost();
            sumGO.Add(cost);

            ClearBoxes();

        }

        private void TextBox6_MouseClick()
        {
            throw new NotImplementedException();
        }

        private void ClearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap photo = new Bitmap(openFileDialog1.OpenFile());
                pictureBox1.Image = photo;
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GroupOrder groupOrder = new GroupOrder();
            groupOrder.CuisineDay();
        }

        private void ButtonDefaultData_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Max";
            textBox2.Text = "Willow";
            textBox3.Text = "mwillow@gmail.com";
            textBox4.Text = "+4(565)232-7845";
            textBox5.Text = "58 Middle Point Rd , SF California(CA), 94124";
            comboBox1.SelectedIndex = 1;
            textBox6.Text = "peanut sensitive";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void TextBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                textBox6.Text= "peanut sensitive";
            }
            else
            {
                MessageBox.Show("If you want to add default data to this box, press left button of your mouth!");
                    
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
                MessageBox.Show("Do you want to load a picture? Use a 'load' button on your right!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Check your name!");
            }

            if (!Regex.IsMatch(textBox2.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Check your surname!");
            }

            if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Z0-9]+$"))
            {
                if (!textBox3.Text.Contains("@") && !textBox3.Text.Contains("."))
                {
                    MessageBox.Show("Check your email!");
                }

            }

            if (textBox4.Text.Length==9)
            {
                if (!Regex.IsMatch(textBox4.Text, @"^[0-9]+$"))
                {
                    MessageBox.Show("Check your phone number!");
                }
            }
            else
            {
                MessageBox.Show("Check your phone number! It must include 10 characters without + and country code!");
            }

            
        }
    }
}

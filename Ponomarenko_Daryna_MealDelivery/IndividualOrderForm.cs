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
    public partial class IndividualOrderForm : Form
    {
        //lista do przechowywania obiektow klasy IndividualOrder
        public static List<IndividualOrder> listIO = new List<IndividualOrder>();
        public static List<double> sumIO = new List<double>();


        public IndividualOrderForm()
        {
            InitializeComponent();
        
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            IndividualOrder individualOrder = new IndividualOrder((Bitmap)pictureBox1.Image);           //jednoargumentowy konstruktor z klasy

            individualOrder.GetData(textBox1, textBox2, textBox3, textBox4,textBox5,textBox6,textBox7);
            individualOrder.PaymentMethod(comboBox1);
            individualOrder.PlannedDeliveryDate(dateTimePicker1);
            individualOrder.Cost();
            individualOrder.OrderStatus();
            individualOrder.Write(listView1);
            Form1.listO.Add(individualOrder);

            float cost = individualOrder.Cost();
            sumIO.Add(cost);

            IndividualOrderForm.listIO.Add(individualOrder);
            ClearBoxes();

        }

        private void ClearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
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

        //default'owe dane 
        private void ButtonDefaultData_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Jane";
            textBox2.Text = "Smith";
            textBox3.Text = "jsmith@gmail.com";
            textBox4.Text = "+1(646)555-4087";
            textBox5.Text = "11 Saxon Court Brooklyn, NY 11238";
            comboBox1.SelectedIndex = 1;
            textBox6.Text = "vegetarian";
            textBox7.Text = "1 extra chopsticks set";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void TextBox1_MouseHover(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Provide your name to complete the order!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {    
            if(!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Check your name!");
            }

            if (!Regex.IsMatch(textBox2.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Check your surname!");
            }

            if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Z0-9]+$"))
            {
                if(!textBox3.Text.Contains("@") && !textBox3.Text.Contains("."))
                {
                    MessageBox.Show("Check your email!");
                }
                
            }

            if (textBox4.Text.Length == 9)
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

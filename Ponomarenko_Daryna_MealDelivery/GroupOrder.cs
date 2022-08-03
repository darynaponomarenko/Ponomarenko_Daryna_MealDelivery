using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponomarenko_Daryna_MealDelivery
{
    class GroupOrder:Order
    {
        
        int numberOfPeople;
        string orderStatus;
        DateTime commitmentDate;
        string comment;
        readonly string[] nationalCuisineDay = new string[7] { 
            "It's ukrainian cuisine day!", 
            "It's polish cuisine day!",
            "It's italian cuisine day!",
            "It's french cuisine day!",
            "It's asian cuisine day!",
            "It's mexican cuisine day!",
            "It's german cuisine day!"}; 
        public GroupOrder():base()
        {
            this.totalCost = TotalCost();
            //this.numberOfPeople = 5;
            this.orderStatus = OrderStatus();
            this.commitmentDate = DateTime.Now;
            //this.comment = "peanut sensitive";
   
        }

        public GroupOrder(Bitmap photo)
        {
            this.photo = photo;
        }

        public GroupOrder(string name, string surname, string email, string phoneNumber, string address, string paymentMethod, float totalCost, string voucherCode, DateTime date, Bitmap photo, int numberOfPeople, string orderStatus, DateTime commitmentDate, string comment) 
            : base(name, surname, email, phoneNumber, address, paymentMethod, totalCost, voucherCode, date, photo)
        {
            this.numberOfPeople = numberOfPeople;
            this.orderStatus = orderStatus;
            this.commitmentDate = commitmentDate;
            this.comment = comment;

        }

        public GroupOrder(GroupOrder g):base(g)
        {
            this.numberOfPeople = g.numberOfPeople;
            this.orderStatus = g.orderStatus;
            this.commitmentDate = g.commitmentDate;
            this.comment = g.comment;
        }

        public void GetData(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6)
        {
            name = textBox1.Text;
            surname = textBox2.Text;
            email = textBox3.Text;
            phoneNumber = textBox4.Text;
            address = textBox5.Text;
            comment = textBox6.Text;
        }

        public void PaymentMethod(ComboBox comboBox1)
        {
            paymentMethod = (string)comboBox1.SelectedItem;
        }

        public void NumberOfPeople(NumericUpDown numericUpDown1)
        {
            numberOfPeople = (int)numericUpDown1.Value;
        }

        public void PlannedDeliveryDate(DateTimePicker dateTimePicker1)
        {
            date = dateTimePicker1.Value;
        }

        override public void Write(ListView lv1)
        {
            string[] row = { id.ToString(), name, surname, email, phoneNumber, address, paymentMethod, totalCost.ToString(), voucherCode, numberOfPeople.ToString(), orderStatus, commitmentDate.ToString(), comment, date.ToString("MM/dd/yyyy") };
            var listViewItem = new ListViewItem(row);
            lv1.Items.Add(listViewItem);
            
            
        }

        public override void Write(ListBox listBox, PictureBox pictureBox)
        {
            base.Write(listBox, pictureBox);
            listBox.Items.Add("Nr of people: "+numberOfPeople);
            listBox.Items.Add("Order status: "+orderStatus);
            listBox.Items.Add("Commitment date: "+commitmentDate);
            listBox.Items.Add("Comment: " + comment);
            listBox.Items.Add("Delivery date: " + date);
        }

        public override void WriteToFile(StreamWriter sw)
        {
            sw.WriteLine("GroupOrder");

            sw.WriteLine(id);
            sw.WriteLine(name);
            sw.WriteLine(surname);
            sw.WriteLine(email);
            sw.WriteLine(phoneNumber);
            sw.WriteLine(address);
            sw.WriteLine(paymentMethod);
            sw.WriteLine(totalCost);
            sw.WriteLine(voucherCode);
            sw.WriteLine(numberOfPeople);
            sw.WriteLine(orderStatus);
            sw.WriteLine(commitmentDate);
            sw.WriteLine(comment);
            sw.WriteLine(date);
        }

        public override void ReadFromFile(StreamReader sr)
        {
            id = Convert.ToInt32(sr.ReadLine());
            name = sr.ReadLine();
            surname = sr.ReadLine();
            email = sr.ReadLine();
            phoneNumber = sr.ReadLine();
            address = sr.ReadLine();
            paymentMethod = sr.ReadLine();
            totalCost = (float)Convert.ToDouble(sr.ReadLine());
            voucherCode = sr.ReadLine();
            numberOfPeople = Convert.ToInt32(sr.ReadLine());
            orderStatus = sr.ReadLine();
            commitmentDate = Convert.ToDateTime(sr.ReadLine());
            comment = sr.ReadLine();
            date = Convert.ToDateTime(sr.ReadLine());

        }

        public override void WritePhotoToFile(string filename, string path)
        {
            if (File.Exists(@path))
            {
                MessageBox.Show("Same file exists");
                File.Delete(@path);
                photo.Save(filename);
            }
            else
            {
                photo.Save(filename);
            }

        }

        public override void ReadPhotoFromFile(string filename)
        {
            photo = (Bitmap)Image.FromFile(filename);
        }

        public float TotalCost()
        {
            totalCost = (float)(numberOfPeople * 12.50);

            if (voucherCode == "23324")
            {
                float discount = totalCost / 10;
                totalCost -= discount;
            }

            if (voucherCode == "72272")
            {
                float discount = (totalCost*20)/100;
                totalCost -= discount;
            }

            if (voucherCode == "-")
            {
                return totalCost;
            }
            return totalCost;
        }

        public string OrderStatus()
        {
            if (date.Date != DateTime.Today)
            {
                orderStatus = "processing";
            }
            else
            {
                orderStatus = "almost done";
            }
            return orderStatus;
        }

        public void CuisineDay()
        {
            if(commitmentDate.DayOfWeek==DayOfWeek.Monday)
            {
                MessageBox.Show(nationalCuisineDay[0]);

            }else if(commitmentDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                MessageBox.Show(nationalCuisineDay[1]);
            }
            else if(commitmentDate.DayOfWeek == DayOfWeek.Wednesday)
            {
                MessageBox.Show(nationalCuisineDay[2]);
            }
            else if(commitmentDate.DayOfWeek == DayOfWeek.Thursday)
            {
                MessageBox.Show(nationalCuisineDay[3]);
            }
            else if(commitmentDate.DayOfWeek == DayOfWeek.Friday)
            {
                MessageBox.Show(nationalCuisineDay[4]);
            }
            else if(commitmentDate.DayOfWeek == DayOfWeek.Saturday)
            {
                MessageBox.Show(nationalCuisineDay[5]);
            }
            else if(commitmentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show(nationalCuisineDay[6]);
            }

        }


    }
}

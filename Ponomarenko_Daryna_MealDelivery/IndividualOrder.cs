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
    public class IndividualOrder : Order
    {
        string foodAdjustments;
        string orderStatus;
        DateTime commitmentDate;
        string comment;

        public IndividualOrder() : base()
        {
            this.totalCost = Cost();
            this.foodAdjustments = "vegetarian";
            this.orderStatus = OrderStatus();
            this.commitmentDate = DateTime.Now;
            this.comment = "1 extra chopsticks set";

        }

        public IndividualOrder(Bitmap photo)
        {
            this.photo = photo;
        }

        public IndividualOrder(string name, string surname, string email, string phoneNumber, string address, string paymentMethod, float totalCost, string voucherCode, DateTime date, Bitmap photo, string foodAdjustment, string orderStatus, DateTime commitmentDate, string comment)
            : base(name, surname, email, phoneNumber, address, paymentMethod, totalCost, voucherCode, date, photo)
        {
            this.foodAdjustments = foodAdjustment;
            this.orderStatus = orderStatus;
            this.commitmentDate = commitmentDate;
            this.comment = comment;
            this.photo = photo;
        }

        public IndividualOrder(IndividualOrder i) : base(i)
        {
            this.foodAdjustments = i.foodAdjustments;
            this.orderStatus = i.orderStatus;
            this.commitmentDate = i.commitmentDate;
            this.comment = i.comment;
            this.photo = i.photo;
        }

        public void GetData(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6, TextBox textBox7)
        {
            
             name = textBox1.Text;
             surname = textBox2.Text;
             email = textBox3.Text;
             phoneNumber = textBox4.Text;
             address = textBox5.Text;
             foodAdjustments = textBox6.Text;
             comment = textBox7.Text;
            
            
        }

        public void PaymentMethod(ComboBox comboBox1)
        {
            paymentMethod = (string)comboBox1.SelectedItem;
        }

        public void PlannedDeliveryDate(DateTimePicker dateTimePicker1)
        {
            date = dateTimePicker1.Value;
        }

        override public void Write(ListView lv2)
        {
            string[] row = { id.ToString(), name, surname, email, phoneNumber, address, paymentMethod, totalCost.ToString(), voucherCode, foodAdjustments, orderStatus, commitmentDate.ToString(), comment, date.ToString("MM/dd/yyyy") };
            var listViewItem = new ListViewItem(row);
            lv2.Items.Add(listViewItem);

        }

        public override void Write(ListBox listBox, PictureBox pictureBox)
        {
            base.Write(listBox, pictureBox);
            listBox.Items.Add("Food adjustments: " + foodAdjustments);
            listBox.Items.Add("Order status: " + orderStatus);
            listBox.Items.Add("Commitment date: " + commitmentDate);
            listBox.Items.Add("Comment: " + comment);
            listBox.Items.Add("Delivery date: " + date);
        }

        public override void WriteToFile(StreamWriter sw)
        {
            sw.WriteLine("IndividualOrder");

            sw.WriteLine(id);
            sw.WriteLine(name);
            sw.WriteLine(surname);
            sw.WriteLine(email);
            sw.WriteLine(phoneNumber);
            sw.WriteLine(address);
            sw.WriteLine(paymentMethod);
            sw.WriteLine(totalCost);
            sw.WriteLine(voucherCode);
            sw.WriteLine(foodAdjustments);
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
            foodAdjustments = sr.ReadLine();
            orderStatus = sr.ReadLine();
            commitmentDate = Convert.ToDateTime(sr.ReadLine());
            comment = sr.ReadLine();
            date = Convert.ToDateTime(sr.ReadLine());
        }

        public override void WritePhotoToFile(string filename, string path)
        {
            using(StreamReader sr=new StreamReader(@path))
            {
                if (File.Exists(@path))
                {
                    MessageBox.Show("Same file exists");

                    //sr.Close();
                    //sr.Dispose();

                    File.Delete(@path);
                    photo.Save(filename);
                }
                else
                {
                    photo.Save(filename);
                }
            }
            
        }

        public override void ReadPhotoFromFile(string filename)
        {
            photo = (Bitmap)Image.FromFile(filename);
        }

        public float Cost()
        {
            if(voucherCode == "23324")
            {
                totalCost = (float)(12.50 - 1.25);
            }
            
            if(voucherCode == "72272")
            {
                totalCost = (float)(12.50 - 2.50);
            }

            if(voucherCode == "-")
            {
                totalCost =(float) 12.50;
            }

            return totalCost;
        }

        public string OrderStatus()
        {
            if(date.Date != DateTime.Today)
            {
                orderStatus = "processing";
            }
            else
            {
                orderStatus = "almost done";
            }
            return orderStatus;
        }
        //idk=============================================================================
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //=================================================================================
        public static bool operator ==(IndividualOrder individualOrder1, IndividualOrder individualOrder2)
        {
            int i = 0;
            bool check = false;

            if (individualOrder1.date == individualOrder2.date) i++;
            if (individualOrder1.paymentMethod == individualOrder2.paymentMethod) i++;
            if (individualOrder1.totalCost == individualOrder2.totalCost) i++;
            if (individualOrder1.voucherCode == individualOrder2.voucherCode) i++;
            if (individualOrder1.address == individualOrder2.address) i++;
            if (individualOrder1.email == individualOrder2.email) i++;
            if (individualOrder1.orderStatus == individualOrder2.orderStatus) i++;
            if (individualOrder1.phoneNumber == individualOrder2.phoneNumber) i++;
            if (individualOrder1.foodAdjustments == individualOrder2.foodAdjustments) i++;
            if (individualOrder1.comment == individualOrder2.comment) i++;
            if (individualOrder1.name == individualOrder2.name) i++;
            if (individualOrder1.surname == individualOrder2.surname) i++;

            if(i==12)
            {
                check=true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        public static bool operator !=(IndividualOrder individualOrder1, IndividualOrder individualOrder2)
        {
            int i = 0;
            bool check = false;

            if (individualOrder1.date != individualOrder2.date) i++;
            if (individualOrder1.paymentMethod != individualOrder2.paymentMethod) i++;
            if (individualOrder1.totalCost != individualOrder2.totalCost) i++;
            if (individualOrder1.voucherCode != individualOrder2.voucherCode) i++;
            if (individualOrder1.address != individualOrder2.address) i++;
            if (individualOrder1.email != individualOrder2.email) i++;
            if (individualOrder1.orderStatus != individualOrder2.orderStatus) i++;
            if (individualOrder1.phoneNumber != individualOrder2.phoneNumber) i++;
            if (individualOrder1.foodAdjustments != individualOrder2.foodAdjustments) i++;
            if (individualOrder1.comment != individualOrder2.comment) i++;
            if (individualOrder1.name != individualOrder2.name) i++;
            if (individualOrder1.surname != individualOrder2.surname) i++;

            if (i > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        public static bool operator >(IndividualOrder individualOrder1, IndividualOrder individualOrder2)
        {
            return individualOrder2.totalCost > individualOrder1.totalCost;
        }
        
        public static bool operator < (IndividualOrder individualOrder1, IndividualOrder individualOrder2)
        {
            return individualOrder2.totalCost < individualOrder1.totalCost;
        }

        public void ComboBoxAdd(ComboBox comboBox)
        {
            comboBox.Items.Add(id);
        }

    }
}

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
    public abstract class Order : IComparable<Order>
    {
        //pola klasy Oreder, wszystkie są protected(żeby później mieć możliwość dziedziczenia)

        protected int id;                    // id zamówienia
        protected string name;               // imię klienta
        protected string surname;            // nazwisko klienta
        protected string email;              // email klienta
        protected string phoneNumber;        // numer komórkowy klienta
        protected string address;            // adres zamieszkania klienta
        protected string paymentMethod;      // metoda płatności
        protected float totalCost;           // koszt całkowity zamówienia
        static int voucherIncluded;          // zmienna dla losowania vouchera rabatowego w metodzie prywatnej IfVoucherIncluded()           
        protected string voucherCode;        // kod rabatowy
        static int nrOfOrders=0;             // zmienna statyczna, używana do zainicjalizowania pola id każdego obiektu
        protected DateTime date;             // nowe pole typu DateTime(lista 6)
        protected Bitmap photo;

        //Konstruktor bezargumentowy
        public Order()
        {
            nrOfOrders += 1;
            this.id = nrOfOrders;
            //this.name = "John";
            //this.surname = "Smith";
            //this.email = "jsmith@gmail.com";
            //this.phoneNumber = "+1(646)555-4087";
            //this.address = "11 Saxon Court Brooklyn, NY 11238";
            //this.paymentMethod = "cash";
            //this.totalCost = 45.50f;
            this.voucherCode =VoucherCode();
            //this.date = date;
            //this.photo = photo;
        }

        //Konstruktor 8-argumentowy
        public Order( string name,string surname,string email,string phoneNumber, string address, string paymentMethod, float totalCost, string voucherCode,DateTime date, Bitmap photo)
        {
            nrOfOrders += 1;
            this.id = nrOfOrders;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.paymentMethod = paymentMethod;
            this.totalCost = totalCost;
            this.voucherCode = voucherCode;
            this.date = date;
            this.photo = photo;
        }

        //Konstruktor kopiujący
        public Order(Order o)
        {
            nrOfOrders += 1;
            this.id = nrOfOrders;
            this.name = o.name;
            this.surname = o.surname;
            this.email = o.email;
            this.phoneNumber = o.phoneNumber;
            this.address = o.address;
            this.paymentMethod = o.paymentMethod;
            this.totalCost = o.totalCost;
            this.voucherCode = o.voucherCode;
            this.date = o.date;
            this.photo = o.photo;

        }

        //Destruktor klasy
        ~Order()
        {
            
        }

        //publiczba metoda Wypisz,  wypisuje wartośći pól obiektu w kontrolce ListView
        public virtual void Write(ListView lv)
        {
            string[] row = { id.ToString(), name, surname, email, phoneNumber, address, paymentMethod, totalCost.ToString(), voucherCode };
            var listViewItem = new ListViewItem(row);
            lv.Items.Add(listViewItem);
            
        }

        public virtual void Write(ListBox listBox, PictureBox pictureBox)
        {
            listBox.Items.Add("ID: "+id);
            listBox.Items.Add("Name: "+name);
            listBox.Items.Add("Surname"+surname);
            listBox.Items.Add("Email: "+email);
            listBox.Items.Add("Phone number: "+phoneNumber);
            listBox.Items.Add("Address: "+address);
            listBox.Items.Add("Payment method: "+paymentMethod);
            listBox.Items.Add("Total cost: "+totalCost);
            listBox.Items.Add("Voucher code: "+voucherCode);
            pictureBox.Image = photo;
        }
        //zostaly dodane 4 virtualne metody zeby byly
        public virtual void WriteToFile(StreamWriter sw)
        {

        }

        public virtual void ReadFromFile(StreamReader sr)
        {

        }

        public virtual void WritePhotoToFile(string filename, string path)
        {

        }

        public virtual void ReadPhotoFromFile(string filename)
        {

        }
        //publiczna metoda VoucherCode, dostaje wylosowany (int)voucherIncluded i przypisuje polu klasy voucherCode odpowiedni kod(string)
        //później dodam metodę, która będzie obliczać koszt całkowity na podstawie kodu rabatowego
        public string VoucherCode()
        {
            IfVoucherIncluded();

            if(voucherIncluded==1)
            {
               voucherCode = "23324";
            }
            else if(voucherIncluded==2)
            {
                voucherCode = "72272";
            }
            else
            {
                voucherCode = "-";
            }
            return voucherCode;
        }

        //prywatna metoda IfVoucherIncluded, losuje liczby od 1-3 i zwraca wylosowany int metodzie VoucherCode()
        private int IfVoucherIncluded()
        {
            Random rnd = new Random();
            voucherIncluded = rnd.Next(1, 4);

            return voucherIncluded;

        }

        public void WriteShortly(ListBox listBox)
        {
            listBox.Items.Add(name + " " + surname + " " + totalCost.ToString());
        }

        public int CompareTo(Order order)
        {
            if (order == null)
                return 1;

            if (String.Compare(this.name, order.name) == 1)
                return 1;
            else if (String.Compare(this.name, order.name) == -1)
                return -1;
            else
            {
                if (String.Compare(this.surname, order.surname) == 1)
                    return 1;
                else if (String.Compare(this.surname, order.surname) == -1)
                    return -1;
                else
                {
                    if (this.totalCost > order.totalCost)
                        return 1;
                    else if (this.totalCost < order.totalCost)
                        return -1;
                    return 0;
                }
            }
        }
    }
}

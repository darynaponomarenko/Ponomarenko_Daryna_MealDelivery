using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponomarenko_Daryna_MealDelivery
{
    public partial class ListOfOrders : Form
    {
        int currentId = -1;

        public ListOfOrders()
        {
            InitializeComponent();
            currentId = -1;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (currentId == 0)
                buttonPrevious.Enabled = false;
            else
                buttonPrevious.Enabled = true;

            if (currentId >= Form1.listO.Count - 1)
                buttonNext.Enabled = false;
            else
                buttonNext.Enabled = true;

            if (currentId < 0)
            {
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
                btnSaveToFile.Enabled = false;
                btnReadFromFile.Enabled = true;
                btnDeleteObject.Enabled = false;
            }
            else
            {
                btnDeleteObject.Enabled = true;
                btnSaveToFile.Enabled = true;
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentId--;
            listBox1.Items.Clear();
            Form1.listO[currentId].Write(listBox1, pictureBox1);
            UpdateButtons();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentId++;
            listBox1.Items.Clear();
            Form1.listO[currentId].Write(listBox1, pictureBox1);
            UpdateButtons();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (Form1.listO.Count > 0)
            {
                currentId = 0;
                listBox1.Items.Clear();
                Form1.listO[currentId].Write(listBox1, pictureBox1);
                UpdateButtons();
            }
            else
                MessageBox.Show("The list is empty!");

        }

        private void BtnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //okno dialogowe do wyboru pliku do zapisu
            sfd.Filter = "text file|*.txt";
            sfd.Title = "Test";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                for (int i = 0; i < Form1.listO.Count; i++)
                {
                    Form1.listO[i].WriteToFile(sw);
                    Form1.listO[i].WritePhotoToFile(@"D:/AppTest/" + i + ".bmp", @"D:/AppTest/" + i + ".bmp");
                    /*if(File.Exists("D:/ AppTest / " + i + ".bmp"))
                    {
                        MessageBox.Show("File exists");
                        File.Delete("D:/ AppTest / " + i + ".bmp");
                        Form1.listO[i].WritePhotoToFile("D:/AppTest/" + i + ".bmp");
                    }
                    else
                    {
                        Form1.listO[i].WritePhotoToFile("D:/AppTest/" + i + ".bmp");
                    }*/
                }
                sw.Close();
            }

        }

        private void BtnReadFromFile_Click(object sender, EventArgs e)
        {
            int i = 0;
            OpenFileDialog ofd = new OpenFileDialog(); //okno dialogowe do wyboru pliku do odczytu danych
            ofd.Filter = "text file|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName); //otwarcie pliku do odczytu
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "IndividualOrder") 
                    { 
                        IndividualOrder individualOrder = new IndividualOrder();
                        individualOrder.ReadFromFile(sr);
                        individualOrder.ReadPhotoFromFile(@"D:/AppTest/" + i + ".bmp");           //co z sciezkamiii
                        Form1.listO.Add(individualOrder);
                        i++;
                    }
                    else if (line == "GroupOrder")
                    {
                        GroupOrder groupOrder = new GroupOrder();
                        groupOrder.ReadFromFile(sr); 
                        groupOrder.ReadPhotoFromFile(@"D:/AppTest/" + i + ".bmp");                //co z sciezkamiii
                        Form1.listO.Add(groupOrder);
                        i++;
                    }
                }
                sr.Close();
            }
        }

        private void BtnDeleteObject_Click(object sender, EventArgs e)
        {
            Form1.listO.RemoveAt(currentId);
            listBox1.ClearSelected();
        }
    }
}

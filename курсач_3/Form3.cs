using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;




namespace курсач
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                if (maskedTextBox1.Enabled == true)
                {
                    if (maskedTextBox1.Text == "")
                    {
                        MessageBox.Show("Введите номер строки");
                    }
                    else
                    {
                        dt[] dats = new dt[20];
                        char[] separator = new char[] { '|' };
                        Create();
                        //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                        //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                        Global.nd = Separat(dats, Global.n, separator);
                        if (Global.nd < Convert.ToInt32(maskedTextBox1.Text))
                            MessageBox.Show("Нет записи");
                        else
                        {
                           // Create();
                            Global.aFile = new FileStream("stud.txt", FileMode.Create);
                            Global.sw = new StreamWriter(Global.aFile, Encoding.Default);
                            for (int i = 0; i < Global.nd; i++)
                            {
                                if ((i + 1) != Convert.ToInt32(maskedTextBox1.Text))
                                {
                                    Global.name = dats[i].name;
                                    Global.phnomber = dats[i].phnomber;
                                    Global.address = dats[i].address;
                                    Global.sw.WriteLine("{0}|{1}|{2}", Global.name, Global.address, Global.phnomber);
                                }
                            }
                            Global.sw.Close();
                            maskedTextBox1.Clear();
                            MessageBox.Show("Запись удалена!");
                        }
                    }
                }
                else if (comboBox1.Enabled == true)
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Выберите номер строки");
                    }
                    else
                    {
                        char[] separator = new char[] { '|' };
                        Create();
                        //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                        //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                        dt[] dats = new dt[20];
                        Global.nd = Separat(dats, Global.n, separator);
                        for (int i = 0; i < Global.nd; i++)
                        {
                            comboBox1.Items.Add(i + 1);
                        }

                        if (Global.nd < Convert.ToInt32(comboBox1.Text))
                            MessageBox.Show("Нет записи");
                        else
                        {
                            //Create();
                            Global.aFile = new FileStream("stud.txt", FileMode.Create);
                            Global.sw = new StreamWriter(Global.aFile, Encoding.Default);
                            for (int i = 0; i < Global.nd; i++)
                            {
                                if ((i + 1) != Convert.ToInt32(comboBox1.Text))
                                {
                                    Global.name = dats[i].name;
                                    Global.phnomber = dats[i].phnomber;
                                    Global.address = dats[i].address;
                                    Global.sw.WriteLine("{0}|{1}|{2}", Global.name, Global.address, Global.phnomber);
                                }
                            }
                            Global.sw.Close();
                            checkBox1.Checked = false;
                            MessageBox.Show("Запись удалена!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не создан");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                if (checkBox1.Checked == true)
                {
                    maskedTextBox1.Enabled = false;
                    comboBox1.Enabled = true;
                    char[] separator = new char[] { '|' };
                     Create();
                    //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                    //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                    dt[] dats = new dt[20];
                    Global.nd = Separat(dats, Global.n, separator);
                    for (int i = 0; i < Global.nd; i++)
                    {
                      comboBox1.Items.Add(i + 1);
                    }   
                }
                else
                {
                    maskedTextBox1.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox1.Items.Clear();
                   
                }
            }
            else
            {
                MessageBox.Show("Файл не создан");
            }
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        public int Separat(dt[] dats, int n, char[] separator)
        {
            while (!Global.sr.EndOfStream)
            {
                string[] slov = Global.sr.ReadLine().Split(separator);
                dats[n].name = slov[0];
                dats[n].address = slov[1];
                dats[n].phnomber = slov[2];
                n++;
            }
            Global.sr.Close();
            return n;
        }
        public void Create()
        {
            Global.aFile = new FileStream("stud.txt", FileMode.Open);
            Global.sr = new StreamReader(Global.aFile, Encoding.Default);
        }




    }
}

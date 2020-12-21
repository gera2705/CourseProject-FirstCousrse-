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

namespace курсач
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
                else
                {
                    
                    char[] separator = new char[] { '|' };
                    Create();
                    int nd = 0;
                    dt[] dats = new dt[20];
                    while (!Global.sr.EndOfStream)
                    {
                        string[] slov = Global.sr.ReadLine().Split(separator);
                        if (maskedTextBox4.Text == "")
                        {
                            if (nd == Convert.ToInt32(comboBox1.Text) - 1)
                            {
                                slov[0] = maskedTextBox3.Text;
                                slov[1] = maskedTextBox2.Text;
                                slov[2] = maskedTextBox1.Text;
                            }
                        }
                        else
                        {
                            if (nd == Convert.ToInt32(maskedTextBox4.Text) - 1)
                            {
                                slov[0] = maskedTextBox3.Text;
                                slov[1] = maskedTextBox2.Text;
                                slov[2] = maskedTextBox1.Text;
                            }
                        }
                        dats[nd].name = slov[0];
                        dats[nd].address = slov[1];
                        dats[nd].phnomber = slov[2];
                        nd++;
                    }
                    Global.sr.Close();
                    //Create();
                    Global.aFile = new FileStream("stud.txt", FileMode.Create);
                    Global.sw = new StreamWriter(Global.aFile, Encoding.Default);
                    for (int i = 0; i < nd; i++)
                    {
                        Global.sw.WriteLine($"{dats[i].name}|{dats[i].address}|{dats[i].phnomber}");
                    }
                    MessageBox.Show("Запись изменена!");
                    Global.sw.Close();
                    maskedTextBox4.Enabled = true;
                    maskedTextBox1.Enabled = false;
                    maskedTextBox2.Enabled = false;
                    maskedTextBox3.Enabled = false;
                    button1.Enabled = false;
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                    maskedTextBox3.Clear();
                    maskedTextBox4.Clear();
                    checkBox1.Checked = false;
                    checkBox1.Enabled = true;
                    comboBox1.SelectedItem = null;
                    comboBox1.SelectedIndex = -1;
                    


                }
            }
            else
            {
                MessageBox.Show("Файл не создан");
            }
            

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) //найти
        {
            if (File.Exists("stud.txt"))
            {
                if (maskedTextBox4.Enabled==true)
                {
                    int nd = 0;
                    int n;
                    string lin = "";
                    dt[] dats = new dt[20];
                    char[] separator = new char[] { '|' };
                    Create();
                    //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                    //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                    while (!Global.sr.EndOfStream)
                    {
                        lin = Global.sr.ReadLine();
                        string[] slov = lin.Split(separator);
                        dats[nd].address = slov[1];
                        dats[nd].phnomber = slov[2];
                        dats[nd].name = slov[0];
                        nd++;

                        if (!int.TryParse(maskedTextBox4.Text, out n) )
                        {
                            MessageBox.Show("Ошибка");
                        }
                        else
                        {
                            if (nd == Convert.ToInt32(maskedTextBox4.Text))
                            {
                                maskedTextBox3.Text = slov[0];
                                maskedTextBox2.Text = slov[1];
                                maskedTextBox1.Text = slov[2];
                            }

                        }
                    }

                    Global.sr.Close();

                    if (int.TryParse(maskedTextBox4.Text, out n))
                    {
                        if (nd < Convert.ToInt32(maskedTextBox4.Text) || maskedTextBox4.Text == "0")
                        {
                            MessageBox.Show("Нет записи");

                        }
                        else
                        {
                            maskedTextBox1.Enabled = true;
                            maskedTextBox2.Enabled = true;
                            maskedTextBox3.Enabled = true;
                            button1.Enabled = true;
                            maskedTextBox4.Enabled = false;
                            checkBox1.Enabled = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
                else if(comboBox1.Enabled == true)
                {
                    int nd = 0;
                    int n;
                    string lin = "";
                    dt[] dats = new dt[20];
                    char[] separator = new char[] { '|' };
                    Create();
                    //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                    //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                    while (!Global.sr.EndOfStream)
                    {
                        lin = Global.sr.ReadLine();
                        string[] slov = lin.Split(separator);
                        dats[nd].address = slov[1];
                        dats[nd].phnomber = slov[2];
                        dats[nd].name = slov[0];
                        nd++;

                        if (!int.TryParse(comboBox1.Text, out n))
                        {
                            MessageBox.Show("Ошибка");
                        }
                        else
                        {
                            if (nd == Convert.ToInt32(comboBox1.Text))
                            {
                                maskedTextBox3.Text = slov[0];
                                maskedTextBox2.Text = slov[1];
                                maskedTextBox1.Text = slov[2];
                            }

                        }
                    }

                    Global.sr.Close();

                    if (int.TryParse(comboBox1.Text, out n))
                    {
                        if (nd < Convert.ToInt32(comboBox1.Text))
                            MessageBox.Show("Нет записи");
                        else
                        {
                            maskedTextBox1.Enabled = true;
                            maskedTextBox2.Enabled = true;
                            maskedTextBox3.Enabled = true;
                            button1.Enabled = true;
                            comboBox1.Enabled = false;
                            checkBox1.Enabled = false;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не создан!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            button1.Enabled = false;
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            comboBox1.Items.Clear();
            checkBox1.Checked = false;
            maskedTextBox4.Enabled = true;
            checkBox1.Enabled = true;
            //comboBox1.SelectedItem = null;
            //comboBox1.SelectedIndex = -1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                if (checkBox1.Checked == true)
                {

                    maskedTextBox4.Enabled = false;
                    comboBox1.Enabled = true;
                    char[] separator = new char[] { '|' };
                    Create();
                    //Global.aFile = new FileStream("stud.txt", FileMode.Open);
                    //Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                    int nd = 0;
                    dt[] dats = new dt[20];
                    while (!Global.sr.EndOfStream)
                    {
                        string[] slov = Global.sr.ReadLine().Split(separator);
                        dats[nd].name = slov[0];
                        dats[nd].address = slov[1];
                        dats[nd].phnomber = slov[2];
                        nd++;
                    }
                    Global.sr.Close();
                    for (int i = 0; i < nd; i++)
                    {
                        comboBox1.Items.Add(i + 1);
                    }
                    //if (maskedTextBox4.Text != "" )
                    //{
                    //    comboBox1.SelectedItem = null;
                    //}
                }
                else
                {

                    maskedTextBox4.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox1.Items.Clear();
                   // comboBox1.SelectedItem = null;
                }
            }
        }

        public void Create()
        {
            Global.aFile = new FileStream("stud.txt", FileMode.Open);
            Global.sr = new StreamReader(Global.aFile, Encoding.Default);
        }
    }
}

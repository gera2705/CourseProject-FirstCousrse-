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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                if (maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
                else 
                {
                    string lin;
                    char[] separator = new char[] { '|' };
                    Global.aFile = new FileStream("stud.txt", FileMode.Open);
                    Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                    int n = 1;
                    while (!Global.sr.EndOfStream)
                    {
                       
                        lin = Global.sr.ReadLine();
                        string[] slov = lin.Split(separator);
                        Global.name = slov[0];
                        Global.address = slov[1];
                        Global.phnomber = slov[2];


                        if (slov[2].IndexOf(maskedTextBox1.Text) == 0)
                        {
                            this.listBox1.Items.Insert(0, slov[0]+$" (номер-{slov[2]})");
                            n++;
                        } 
                        

                    }
                    
                    Global.sr.Close();
                    if (n==1)
                    {
                        MessageBox.Show("Cотрудников с таким номером телефона нет!");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Файл не создан!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            listBox1.Items.Clear();
        }
    }
}

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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
       
        private void Form5_Load(object sender, EventArgs e)
        {
            if (File.Exists("stud.txt"))
            {
                string lin;
                char[] separator = new char[] { '|' };
                Global.aFile = new FileStream("stud.txt", FileMode.Open);
                Global.sr = new StreamReader(Global.aFile, Encoding.Default);
                int nr = 0;
                while (!Global.sr.EndOfStream)
                {
                    lin = Global.sr.ReadLine();
                    string[] slov = lin.Split(separator);
                    Global.name = slov[0];
                    Global.address = slov[1];
                    Global.phnomber = slov[2];
                    this.dataGridView1.Rows.Add();
                    dataGridView1[0, nr].Value = Global.name;
                    dataGridView1[1, nr].Value = Global.address;
                    dataGridView1[2, nr].Value = Convert.ToString(Global.phnomber);
                    nr++;
                }
                Global.sr.Close();
            }
            else
            {
                MessageBox.Show("Файл не создан");
            }
        }
    }
}

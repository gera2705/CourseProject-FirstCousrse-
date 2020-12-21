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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            { this.Close(); }
            
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.ShowDialog();
        }

        private void запрос1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            fr6.ShowDialog();
        }

        private void запрос2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.ShowDialog();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists("stud.txt"))
            {
                MessageBox.Show("Файл уже существует!");
            }
            else
            {
                Global.aFile = new FileStream("stud.txt", FileMode.Create);
                Global.aFile.Close();
                MessageBox.Show("Файл создан!");
            }

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            File.Delete("stud.txt");
            MessageBox.Show("Файл удален!");
        }
    }
    public static class Global
    {
        
        public static FileStream aFile;
        public static StreamWriter sw;
        public static StreamReader sr;
        public static string name;
        public static string phnomber;
        public static string address;
        public static int n=0;
        public static int nd;


    }
    public struct dt
    {
        public string name;
        public string phnomber;
        public string address;
    }

}

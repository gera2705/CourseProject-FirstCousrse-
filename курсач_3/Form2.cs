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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (File.Exists("stud.txt"))
            {
                if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены!");
                }
                else
                {
                    Global.name = maskedTextBox3.Text;
                    Global.phnomber = maskedTextBox1.Text;
                    Global.address = maskedTextBox2.Text;
                    string fileName = "stud.txt";
                    string firstLine = String.Format("{0}|{1}|{2}",
                    Global.name, Global.address, Global.phnomber);
                    File.WriteAllText(fileName, firstLine + Environment.NewLine + File.ReadAllText(fileName, Encoding.Default), Encoding.Default);
                    maskedTextBox3.Text = "";
                    maskedTextBox2.Text = "";
                    maskedTextBox1.Text = "";
                    MessageBox.Show("Запись добавлена!");
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
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
        }
    }
}

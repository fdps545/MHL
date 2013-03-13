using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolClass;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Methods instance;

        public Form1()
        {
            InitializeComponent();
            instance = new Methods();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 main = new Form2();
            main.ShowDialog();
            Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form3 change = new Form3();
            change.ShowDialog();
        }
    }
}

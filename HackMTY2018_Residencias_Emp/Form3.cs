using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackMTY2018_Residencias_Emp
{
    public partial class Form3 : Form
    {
        private string[] datavec;
        private Form1 _parent;
        private Form2 _f2;
        private Form6 _f6;

        public Form3(string[] datavec, ref Form1 parent)
        {
            InitializeComponent();
            this.datavec = datavec;
            _parent = parent;
            CenterToScreen();
        }

        private void Form3_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            _parent.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_f2 == null || _f2.IsDisposed)
            {
                _f2 = new Form2(datavec);
                _f2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_f6 == null || _f6.IsDisposed)
            {
                _f6 = new Form6();
                _f6.Show();
            }
        }
    }
}

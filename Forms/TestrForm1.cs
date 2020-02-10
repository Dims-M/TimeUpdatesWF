using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeUpdatesWF.Forms
{
    public partial class TestrForm1 : Form
    {
        public TestrForm1()
        {
            InitializeComponent();
        }

        private void TestrForm1_Load(object sender, EventArgs e)
        {
            Bl bl = new Bl();

            pictureBox1.Image = bl.CreateBitmapImage("Testtttdtvyhtyhvrtjvyjyjyuy");
        }
    }
}

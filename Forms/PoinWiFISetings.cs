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
    public partial class PoinWiFISetings : Form
    {
        RunWiFiPoint runWiFiPoint;
        public PoinWiFISetings()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
          //  Application.Exit();
            Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            runWiFiPoint = new RunWiFiPoint();
            runWiFiPoint.CreatPoinWiFi(); // Создание точки доступа

        }

        private void button3_Click(object sender, EventArgs e)
        {
            runWiFiPoint = new RunWiFiPoint();
           
            runWiFiPoint.RunCdmComand(); // запуск точки доступа
        }

        private void PoinWiFISetings_Load(object sender, EventArgs e)
        {

        }
    }
}

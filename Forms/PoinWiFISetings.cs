﻿using System;
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
            label1.Text = @"Имя точки доступа = Centr_KKM_Servis ";
            label2.Text = $"Пароль подключения к интернету = k51215045";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            runWiFiPoint = new RunWiFiPoint();
           
            runWiFiPoint.RunCdmComand(); // запуск точки доступа
            labelNamePoinWiFi.Text = "ИМЯ Точки доступа Centr_KKM_Servis";
            labellabelPasswordPoinWiFi.Text = "ПАРОЛЬ для подключения k51215045";
        }

        private void PoinWiFISetings_Load(object sender, EventArgs e)
        {

        }
    }
}

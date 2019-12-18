using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeUpdatesWF
{
    public partial class Form1 : Form
    {

        Bl servis;
        public Form1()
        {
            InitializeComponent();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //запуск старт
        private void button3_Click(object sender, EventArgs e)
        {
            servis = new Bl();
            servis.StartService();
        }

        //Остановить
        private void button4_Click(object sender, EventArgs e)
        {
            servis = new Bl();
            servis.StopService();
        }

        //Выбор автозапуска
        private void checkBoxAvtoStart_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //Выход
        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Перезапуск
        private void btRelod_Click(object sender, EventArgs e)
        {
            servis = new Bl();
            servis.RestartService();
        }

        //При загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            tetstProperty();
        }

        private void tetstProperty()
        {
            servis = new Bl();
            int jj = Properties.Settings.Default.MinuteDef;
            servis.InitMinutes(jj); // загружаем минуты обновлениц

            numericUpDown1.Value = jj;
        }

        //Сохранить настройки
        private void btSave_Click(object sender, EventArgs e)
        {
            //if ()
            //{
            servis = new Bl();
            servis.WrateText("Ntcnnnnn");
            //}
            Properties.Settings.Default.MinuteDef = (int)numericUpDown1.Value;
            Properties.Settings.Default.Save();
        }
    }
}

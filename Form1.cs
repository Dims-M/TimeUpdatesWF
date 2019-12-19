using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            //  servis.TestStart(); // тестовой метод
            
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
            servis = new Bl();
            //servis.CopyLinkAppStartup(true);

            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox

            if (checkBox.Checked == true)
            {
                servis.CopyLinkAppStartup(true);
            }
            else
            {

                servis.CopyLinkAppStartup(false);


            }

        }

        //Выход
        private void btExit_Click(object sender, EventArgs e)
        {
            // servis.Cikle(false); //  запуск метода в новм потоке
            Bl.myThread.Abort();
            Close();
            Application.Exit();
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

        //Указываем количество минут по умолчанию.
        private void tetstProperty()
        {
            servis = new Bl();
            int jj = Properties.Settings.Default.MinuteDef;
            servis.InitMinutes(jj); // загружаем минуты обновлениц
            numericUpDown1.Value = jj;
            servis.Cikle(); //  запуск метода в новм потоке
            
        }

        //Сохранить настройки
        private void btSave_Click(object sender, EventArgs e)
        {
            servis = new Bl();
            int tempMinutes = (int)numericUpDown1.Value;
            Properties.Settings.Default.MinuteDef = tempMinutes;
            Properties.Settings.Default.Save();
            servis.InitMinutes(tempMinutes);
        }

        //При закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bl.myThread.Abort();
            Application.Exit();
            
        }
    }
}

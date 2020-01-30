using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TimeUpdatesWF.Forms;

namespace TimeUpdatesWF
{
    public partial class Form1 : Form
    {

        Bl servis;
        RunWiFiPoint runWiFiPoint;
        public Form1()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            notifyIcon1.Click += notifyIcon1_Click;
            this.WindowState = FormWindowState.Minimized; // форма при запуске свернута
            this.ShowInTaskbar = false; //скрываем форму из раб панельки

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //запуск старт
        private void button3_Click(object sender, EventArgs e)
        {
            servis = new Bl();
            servis.StartService();
            // TestVariable();
          string temp = servis.ExecuteCommandAsAdmin();
          label1.Text = temp;

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
               // servis.CopyLinkAppStartup(true);// Копирование ярлыка в атозагрузку
            }
            else
            {

              //  servis.CopyLinkAppStartup(false);


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
            myDateTime.Text = $"Текущие время{DateTime.Now}\t\n";
            servis = new Bl();
           // Bl.StartBatUpdateTime(); // запуск батника обновления времени Запустится при из 
            tetstProperty(); //загрузка настроек из проперти
           // servis.CopyLinkAppStartup(true);
            //servis.ExecuteCommandAsAdmin(); // запуск обновы через код. Версия 2
            myDateTime.Text += $"Стало: {DateTime.Now}\t\n";

            runWiFiPoint = new RunWiFiPoint(); //созднаие обьекта для работы сточкой доступа
            runWiFiPoint.RunCdmComand(); //запуск включения точки доступа
        }

        //Указываем количество минут по умолчанию.\
        /// <summary>
        /// 
        /// </summary>
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
            notifyIcon1.Visible = false;
            Bl.myThread.Abort();
            Application.Exit();
            
        }

        void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState. Normal;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
           
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("hhhhh");
                //обрабатываем щелчок левой
            }
            else if (e.Button == MouseButtons.Right)
            {
                //обрабатываем щелчок правой
            }
        }

        public void TestVariable()
        {
           // this.Hide();
        }

        private void ппроверитьОбновленияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Скачать последнию версию
        private void скачатьПоследниюВерсиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            servis = new Bl();

            if (servis.GetFailSite() != true)
            {            
                MessageBox.Show("Произошла ошибка при скачивании новой версии:" +
                    "*Проверте интернет," +
                    "*Настрйки анивируса," +
                    "*Запустить программу от имени администратора!"); 
            }

            else
            MessageBox.Show("Обновление скачено! Находится в папке Документы");
            servis.WrateText($"{DateTime.Now}\t\n Обновление скачено!");
            servis.StartUptadeApp();
            // servis.GetFailSite();
        }

        //Кнопка свернуть программу
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // форма при запуске свернута
           
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                //this.mi
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
            this.ShowInTaskbar = false; //скрываем форму из раб панельки
           // Form.Visible = false;
        }

        /// <summary>
        /// Запуск точки доступа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            runWiFiPoint = new RunWiFiPoint();
            servis = new Bl();
            // runWiFiPoint.RunCdmComand();// запуск точки доступа
            //  servis.StartUptadeApp(); //Распаковка скаченой версии обновленной версии
            Bl.StartBatUpdateTime(); //Запуск батника 

            TestJobJson testJobJson = new TestJobJson();
          // testJobJson.SaveDanni();  // запуск процесса сохранения(сеарилизация) настроек в Json
          //  testJobJson.ReadingSettngsJson();  // запуск скачивания настроек в Json с сайта


            // servis.GetFailSite();
        }

        //Кнопка настройки работы с точкой доступа
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoinWiFISetings poinWiFISetings = new PoinWiFISetings();
            poinWiFISetings.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

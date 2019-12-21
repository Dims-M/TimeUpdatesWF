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

            this.ShowInTaskbar = true;
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
            TestVariable();
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
            servis.CopyLinkAppStartup(true);
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
           // servis.InitMinutes(tempMinutes);
            servis.GetFailSite();
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
            this.WindowState = FormWindowState.Normal;
           // this.WindowState = FormWindowState.Minimized;
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

        }
    }
}

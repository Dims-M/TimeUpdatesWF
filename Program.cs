using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TimeUpdatesWF
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Проверка на запущенность нескольких экземпляров приложения
            using (var mutex = new Mutex(false, "TimeUpdatesWF.exe"))
            {
                
                if (mutex.WaitOne(TimeSpan.FromSeconds(3))) // Подождать три секунды - вдруг предыдущий экземпляр еще закрывается
                    Application.Run(new Form1()); // запуск главной формы

                else
                {
                    Bl servis = new Bl();
                    servis.WrateText("Папытка запуска ghbkj;tybz \t\n Другой экземпляр приложения уже запущен");
                     MessageBox.Show("Другой экземпляр приложения уже запущен");
                }

                   
            }

          //  Application.Run(new Form1());
        }
    }
}

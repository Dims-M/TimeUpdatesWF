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

            using (var mutex = new Mutex(false, "TimeUpdatesWF.exe"))
            {
                if (mutex.WaitOne(TimeSpan.FromSeconds(3))) // Подождать три секунды - вдруг предыдущий экземпляр еще закрывается
                    Application.Run(new Form1()); // запуск главной формы

                else
                    MessageBox.Show("Другой экземпляр приложения уже запущен");
            }

          //  Application.Run(new Form1());
        }
    }
}

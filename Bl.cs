using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace TimeUpdatesWF
{
  public  class Bl
    {
        /// <summary>
        /// Класс для работы с логикой
        /// </summary>
        // https://www.youtube.com/watch?v=Ier5xem-TTA&list=PL0lO_mIqDDFWOMqSKFaLypANf1W7-o87q&index=5&t=594s
        // //План
        // Сделать автозагрузку времени из прпиртес, работающий устанвщик минут

            private const string myServise = "W32Time";
            private int UpdatesMinute = 10;
            string tempLog = "";

            // Запуск службы
            public void StartService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);

            try
            {

                // Проверяем не запущена ли служба
                if (service.Status != ServiceControllerStatus.Running)
                {
                    // Запускаем службу
                    service.Start();
                    // В течении минуты ждём статус от службы
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));
                    // Console.WriteLine("Служба была успешно запущена!");
                }
                else
                {
                    // Console.WriteLine("Служба уже запущена!");
                }

            }
            catch (Exception ex)
            {
                tempLog = $"Произошла ошибка при запуске службы \t\n{ex}";
            }
        }


            // Останавливаем службу
            public void StopService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);
            try
            {
                // Если служба не остановлена
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    // Останавливаем службу
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));
                    //  Console.WriteLine("Служба была успешно остановлена!");
                }
                else
                {
                    //   Console.WriteLine("Служба уже остановлена!");
                }
            }
            catch (Exception ex)
            {
                tempLog = $"Произошла ошибка при остановке службы \t\n{ex}";
            }
        }


            // Перезапуск службы
            public void RestartService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);
                TimeSpan timeout = TimeSpan.FromMinutes(UpdatesMinute);

            try
            {

                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    //  Console.WriteLine("Перезапуск службы. Останавливаем службу...");
                    // Останавливаем службу
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    //  Console.WriteLine("Служба была успешно остановлена!");
                }
                if (service.Status != ServiceControllerStatus.Running)
                {
                    //   Console.WriteLine("Перезапуск службы. Запускаем службу...");
                    // Запускаем службу
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    //   Console.WriteLine("Служба была успешно запущена!");
                }
            }
            catch (Exception ex)
            {
                tempLog = $"Произошла ошибка при перезапуске службы \t\n{ex}";
            }
        }

        //Иницализация минут по умолчанию
            public bool InitMinutes(int myMinutes)
            {
                UpdatesMinute = myMinutes;
                // RestartService(myServise, myMinutes);
                return true;
            }

        //Получеение минут по имолчанию
            public int GettMinutes(int myMinutes)
            {

                return UpdatesMinute;
            }


        /// <summary>
        /// Запись в автозагрузку
        /// </summary>
        /// <param name="swixh"></param>
        public void CopyLinkAppStartup(bool swixh)
        {
            String s3 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            s3 += "\\";
            //WrateText("Строка подключения \n" + s3);
            // MessageBox.Show(s3);

            //string a = "~runme.lnk"; GetProcesses.exe
            string a = "GetProcesses.lnk";
            //string b = @"C:\EoU\"; myPachDir
           // string b = myPachDirFileApp;// + "GetProcesses\\";
            string c = s3;

            try
            {
                if (swixh)
                {
                    #region НЕ смотреть
                    // var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    // key.SetValue("Отправка чеков в ОФД", Application.ExecutablePath);
                    //  key.SetValue("Отправка чеков в ОФД", @"C:\EoU\EthOverUsb.exe");
                    // String s = System.Environment.GetEnvironmentVariable("programfiles");
                    //  String s2 = System.Environment.GetEnvironmentVariable("Startup");
                    //String s3 = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                    //  File.Delete(c + a);
                    #endregion

                  //  System.IO.File.Copy(b + a, c + a);
                    //File.Copy(@"C:\EoU\~runme", patchStartup);
                    WrateText("Копирование ярлыка завершено!!");
                }

                else
                {
                    //  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
                    //  key.DeleteValue("Отправка чеков в ОФД",true);
                    // File.Delete(@"C:\EoU\EthOverUsb.exe");
                    System.IO.File.Delete(c + a);
                    WrateText("Не актуальный ярлык удален");
                }

            }
            catch (Exception ex)
            {
                WrateText("Ошибка при при копировании ярлыка в автозагрузки" + ex);
            }
        }


        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Журнал событий
        /// </summary>
        /// <param name="myText"></param>
        public void WrateText(string myText)
        {
            string tempPathDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //DirectoryInfo dirInfo = new DirectoryInfo(@"Log");
            FileInfo dirInfo = new FileInfo(@"tempPathDir\Log.txt");
            try
            {
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание кaтолога
                }

            }

            catch (Exception ex)
            {

            }

            using (StreamWriter sw = new StreamWriter($"{tempPathDir}"+@"\Log.txt", true, System.Text.Encoding.Default))

            // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }

        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Временное логирования
        /// </summary>
        /// <param name="myText"></param>
        //public void WrateTextTemp(string myText, string myPachDir)
        //{
        //    //DirectoryInfo dirInfo = new DirectoryInfo("\\Log");

        //    try
        //    {
        //    //    if (!dirInfo.Exists)
        //    //    {
        //    //        dirInfo.Create();// создание кaтолога
        //    //        //Directory.CreateDirectory(myPachDir + "Log"); //создание папки лога
        //    //        // File.Create(myPachDir + @"Log\texLog.txt");
        //    //    }

        //        using (StreamWriter sw = new StreamWriter(myPachDir, System.Text.Encoding.Default))
        //        //using (StreamWriter sw = new StreamWriter(@"Log\Log.txt", true, System.Text.Encoding.Default))
        //        {
        //            // sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись
        //            sw.WriteLine(myText); // запись

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
    }



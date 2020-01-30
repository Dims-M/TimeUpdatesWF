using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.ServiceProcess;
using System.Text;
using System.Threading;
//using System.Windows;
using System.Windows.Forms;

namespace TimeUpdatesWF
{
    public class Bl
    {
        /// <summary>
        /// Класс для работы с логикой
        /// </summary>
       
        private const string myServise = "W32Time";
        private static int UpdatesMinute = 60;
        string tempLog = "";
        private string myPachDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\UtilKKM-Servis\";
        private string linkAppPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\TimeUpdatesWF.lnk";



        //запускаем служюу обновления времени в отдельном потоке
        public static  Thread myThread = new Thread(new ThreadStart(TimeSynchronization));



        // Запуск службы через службы. На вин 8 что то не  работает
        public void StartService(string serviceName = myServise)
        {
            ///Обьект для работы с сервсами. Запуск, установка...и Т,Д,
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

                else if (service.Status != ServiceControllerStatus.Stopped)
                {
                   // service.Continue();
                }

                else
                {
                    // Console.WriteLine("Служба уже запущена!");
                }

                

                }
            catch (Exception ex)
            {
                tempLog = $"Произошла ошибка при запуске службы \t\n{ex}";
                WrateText(tempLog);

            }
            finally
            {
                service.Dispose();
            }
        }

        #region Тестовой метод
        public void TestStart()
        {

            //int exitCode;

            //using (var process = new Process())
            //{
            //    var startInfo = process.StartInfo;
            //    startInfo.FileName = "W32Time";
            //    startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //    startInfo.Arguments = string.Format("failure \"{0}\" reset= 0 actions= restart/5000", "W32Time");

            //    process.Start();
            //    process.WaitForExit();

            //    exitCode = process.ExitCode;

            //    process.Close();
            //}

            //if (exitCode != 0)
            //    throw new InvalidOperationException();

            //using (var serviceController = new ServiceController(myServise))
            //{
            //   // serviceController.Start();
            //    serviceController.WaitForStatus(ServiceControllerStatus.Running);
            //    serviceController.Start();
            //}


            //  System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
            //  // processInfo.FileName = myServise; Служба времени Windows
            //  processInfo.FileName = "W32Time";
            ////  processInfo. FileName = "Служба времени Windows";
            //  processInfo.Arguments = "config ServiceName start = auto»"; // auto|demand|disabled|delayed-auto
            //  processInfo.UseShellExecute = true;
            //  processInfo.Verb = "runas"; // от имени администратора
            //  processInfo.WindowStyle = ProcessWindowStyle.Hidden; // скрыть окно

            //  System.Diagnostics.Process pr = new System.Diagnostics.Process();

            //  try
            //  {
            //      pr = Process.Start(processInfo);
            //  }
            //  catch (Exception ex)
            //  {
            //      tempLog = $"Произошла ошибка при запуске ntcnjdjq службы \t\n{ex}";
            //      WrateText(tempLog);
            //      //Ничего не делаем, потому что пользователь, возможно, нажал кнопку «Нет»
            //      // в ответ на вопрос о запуске программы в окне предупреждения UAC (для Windows 7)
            //  }

            //  pr.WaitForExit();
            //pr.
        }
        #endregion

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
                WrateText(tempLog);
            }
            finally
            {
                service.Dispose();
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
                WrateText(tempLog);
            }
            finally
            {
                service.Dispose();
            }
        }

        //Иницализация минут по умолчанию
        public bool InitMinutes(int myMinutes)
        {
            UpdatesMinute = myMinutes;
            WrateText($"Время обновление изменено на {myMinutes}");
            return true;
        }

        //Получеение минут по умолчанию
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
            string pathApp = Application.StartupPath;
            string a = @"\TimeUpdatesWF.exe";
            string b = pathApp; 
            string c = s3;

            try
            {
                if (swixh!=false)
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
                    File.Delete(c + a);
                    System.IO.File.Copy(b + a, c + a);
                    WrateText("Копирование ярлыка завершено!!");
                }

                else
                {
                    //  var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
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
          //  string tempPathDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tempPathDir = @"Log\"; // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //DirectoryInfo dirInfo = new DirectoryInfo(@"Log");

            FileInfo dirInfo = new FileInfo($"{tempPathDir}"+@"\Log.txt");
            DirectoryInfo directoryInfo = new DirectoryInfo(tempPathDir);


            try
            {
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create(); // Создание ктолога лога
                }

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();// создание файла
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи лога \t\n "+ex);
            }

            using (StreamWriter sw = new StreamWriter($"{tempPathDir}" + @"Log.txt", true, System.Text.Encoding.Default))

            // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись

            }
        }

        /// <summary>
        /// Запуск потока обновления времени
        /// </summary>
        /// <param name="z"></param>
        public  void Cikle()
        {
           myThread.Start(); // запускаем поток   
        }

        /// <summary>
        /// Метод обновления времени
        /// </summary>
        /// <param name="xx"></param>
        public static void TimeSynchronization()
        {
            while (true)
            {
                StartBatUpdateTime(); // один раз срабытывает при запуске приложения
                //Process p = new Process();
                //p.StartInfo.Arguments = "/resync";
                //p.StartInfo.CreateNoWindow = true;
                //p.StartInfo.FileName = "w32tm.exe";
                //p.StartInfo.UseShellExecute = false;
                //p.Start(); // запуск
                //p.WaitForExit(); 
                Thread.Sleep(UpdatesMinute * 60000);
                continue;
            }
          
        }


        /// <summary>
        /// Получение файла обновления ссайта 000webhostapp.com
        /// </summary>
        public bool GetFailSite()
        {
           
            string errorLog = $"{DateTime.Now.ToString()}\t\n";
           // string pathFile =  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ $@"\UtilKKM-Servis\ОбновлениеВремени{errorLog}.zip"; // загрузка обновления
            //string pathFile = Application.ExecutablePath + $@"\UtilKKM-Servis\ОбновлениеВремени{errorLog}.zip"; // загрузка обновления
           // string pathFile = Application.StartupPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip"; // загрузка обновления
            string pathFile = Application.StartupPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip"; // загрузка обновления
            string serFtp = @"https://testkkm.000webhostapp.com/GetUpTime/TimeUpdatesWF.zip";
            string absolitPath = Application.StartupPath;
            bool resul = false;

            if (!Directory.Exists(absolitPath + @"\UtilKKM-Servis\"));
            {
                Directory.CreateDirectory(absolitPath + @"\UtilKKM-Servis\");
                Directory.CreateDirectory(absolitPath + @"\UtilKKM-Servis\OldApp\");

            }



           // File.Delete(pathFile);
           

            //if (System.IO.File.Exists(pathFile))
            //{
            //    errorLog += $"Данный файл уже существует \t\n{serFtp}\t\n";
            //    WrateText(errorLog);
            //    File.Delete(pathFile);
            //    errorLog += $"Старый файл был удален \t\n{serFtp}\t\n";
            //}

           //else 
            
                File.Delete(pathFile);
                using (var web = new WebClient())
                {
                    try
                    {
                        // скачиваем откуда и куда
                        web.DownloadFile(serFtp, pathFile);
                    resul = true;

                    }
                    catch (Exception ex)
                    {
                        WrateText("Ошибка при скачивании обновлений \t\n"+ex);
                        resul = false;
                    }
                }
            
            return resul;
        }


        /// <summary>
        /// Разорхивация файлов с указание что и куда орхивировать
        /// </summary>
        /// <param name="MyzipFail">Путь для файла.Откуда и какой архив</param>
        /// <param name="MyExtractPath">Куда распаковыватьы</param>
        public void ZipArhivMyPath(string MyzipFail, string MyExtractPath)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(MyzipFail))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(MyExtractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }
                // ZipFile.ExtractToDirectory(MyzipFail, MyExtractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }

            // File.Delete(MyzipFail);
        }


        /// <summary>
        /// Распаковка скаченой версии обновленной версии
        /// </summary>
        public bool StartUptadeApp()
        {
            string absolitPath = Application.StartupPath;
            string zipPath = absolitPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip";
            string extractPath = absolitPath + @"\UtilKKM-Servis\ОбновлениеВремени\";
            string tempPachh = absolitPath+ @"\UtilKKM-Servis\OldApp\jj.zip";

            try
            {
                using (ZipFile zip = ZipFile.Read(zipPath))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }

                File.Move(zipPath, tempPachh);
                // string tempPachh = extractPath + @"\OldApp\";// + $"Старая версияAPP{DateTime.Now}.zip";
                // FileInfo fileInf = new FileInfo(zipPath);
                // fileInf.MoveTo(tempPachh); // перенос старого файла

                //установка новой версии
                StartNewApliccation(extractPath + @"TimeUpdatesWF.msi");
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }



            return true;
        }

        /// <summary>
        /// запуск нового скаченного файла
        /// </summary>
        /// <param name="pathName"></param>
        public void StartNewApliccation(string pathName)
        {
            try
            {
                Process.Start(pathName);
                WrateText("Попытка установки обновления программы");
            }
            catch (Exception ex)
            {
                WrateText("Ошибка при запуске обновленного диструбутива");
            }
           
            Thread.Sleep(30);
            Application.Exit();
        }


        //Распаковка архива в нужный каталог
        public void ZipArhivJob()
        {
            string zipPath = @"C:\EoUTemp\EoU.zip";
            string extractPath = @"C:\";

            try
            {
               // ZipFile.ExtractToDirectory(zipPath, extractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }


        }

        public void testUbdate1()
        {
            //System.Diagnostics.Process.Start("cmd.exe", "/C " + "w32tm /config /manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update");
            //System.Diagnostics.Process.Start("cmd.exe", "/C " + "net start w32time");
            //System.Diagnostics.Process.Start("cmd.exe", "/C " + @"net time /setsntp:88.147.254.232");

            //System.Diagnostics.Process.Start("cmd.exe", "/C " + "w32tm /config /update");
            // System.Diagnostics.Process.Start("cmd.exe", "/C " + "net start w32time");
            // System.Diagnostics.Process.Start("cmd.exe", "/C " + "w32tm /config /manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update");

            Process p = new Process();
            // p.StartInfo.Arguments = "/resync";
           // p.StartInfo.Arguments = @"/manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update";
          //  p.StartInfo.Arguments = "/config/syncfromflags:manual/manualpeerlist:time.windows.com";
            // p.StartInfo.Arguments = @"//server.lan.local/set/y";

           // p.StartInfo.CreateNoWindow = false;
           // p.StartInfo.FileName = "w32time";
           // p.StartInfo.FileName = "w32tm.exe";
           // p.StartInfo.UseShellExecute = false;
            // p.Start(); // запуск

            string command = @"w32tm /config /syncfromflags:manual /manualpeerlist:88.147.254.232";
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd";
            startInfo.Arguments = "/c " + command;
           // startInfo.Arguments = "/c " + "";
            startInfo.UseShellExecute = true;

            startInfo.Verb = "runas"; // run elevated            
           
            //var proc = Process.Start(startInfo);
            //Console.WriteLine(proc);

            // p.WaitForExit();
        }




        /// <summary>
        /// Запуск батника обновления времени
        /// </summary>
        public static void StartBatUpdateTime()
        {

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"1.bat";
            proc.StartInfo.CreateNoWindow = false;
          //  proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //скрытиетие  окна
            proc.Start();
            proc.WaitForExit(3000);


        }


        /// <summary>
        /// Поточная команда сдм на обновление времени
        /// </summary>
        /// <returns></returns>
        public string ExecuteCommandAsAdmin()
        {
            try
            {
                //string command = @"w32tm /config /syncfromflags:manual /manualpeerlist:88.147.254.232";
                //string command = @"w32tm /config /syncfromflags:manual /manualpeerlist:88.147.254.232";
                string command = @"w32tm /config /manualpeerlist:time.windows.com /syncfromflags:manual /reliable:yes /update";
                string tempLog = "";

                ProcessStartInfo procStartInfo = new ProcessStartInfo()
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = "runas.exe",
                Arguments = "/user:Administrator \"cmd /c" + command + "\""
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();
                Thread.Sleep(300);
                    //string output = proc.StandardOutput.ReadToEnd();

                    //if (string.IsNullOrEmpty(output))
                    //    output = proc.StandardError.ReadToEnd();
                    proc.Close();
                    return "Обновление времени";
            }
               
            }

            catch (Exception ex)
            {
                tempLog = ex.ToString();
                WrateText(tempLog);
                return tempLog;
            }

            //return tempLog;
        }

            #region Тестовой метод проверки обновления
            ///// <summary>
            ///// ****
            ///// </summary>
            ///// <returns></returns>
            ////Тестовой метод проверки обновления
            //public bool Сheck()
            //{
            //   // VersionChecker verChecker = new VersionChecker();
            //    string s = "";
            //    string localVersion = "";
            //    try
            //    {
            //        while (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) //ждем пока подрубимся к сети
            //        {
            //            System.Threading.Thread.Sleep(60000);
            //        }
            //        localVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //получение версии запущенной программы
            //        WebClient w = new WebClient();
            //        s = w.DownloadString("http:// domen.ru/version.txt");
            //        w.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //       // errors(ex.Message);
            //    }
            //    string[] q = s.Split(‘|’); // у меня в файле указана не только версия, но и адрес для загрузки последней версии программы через знак ‘|’
            //    //if (verChecker.NewVersionExists(localVersion, q[0])) // отправляем две версии другому методу для их сверки
            //    //{
            //    //    load_obnovlenie(q[1]); //версия старая и запускаем метод по обновлению нашей программы(будет в следующей статье)
            //    //}
            //    else
            //    {
            //        return false; //версия новая
            //    }
            //    return true; //даем знать основной команде, которая вызвала метод, что мол, есть обнова и лучше нам пока не начинать работать
            //}
            #endregion

        }
}



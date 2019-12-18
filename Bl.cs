using System;
using System.Collections.Generic;
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

            // Запуск службы
            public void StartService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);

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


            // Останавливаем службу
            public void StopService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);

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


            // Перезапуск службы
            public void RestartService(string serviceName = myServise)
            {
                ServiceController service = new ServiceController(serviceName);
                TimeSpan timeout = TimeSpan.FromMinutes(UpdatesMinute);

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

        }
    }



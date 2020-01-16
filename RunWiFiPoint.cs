using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimeUpdatesWF
{
    /// <summary>
    /// Запуск точки доступа
    /// </summary>
   public  class RunWiFiPoint
    {
        private const string myServise = "Служба автонастройки WLAN и Общий доступ к подключению к Интернет(ICS)";
       
        Bl bl;

        /// <summary>
        /// Запуск точки доступа
        /// </summary>
        /// <returns></returns>
      public  bool RunCdmComand()
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            try
            { 
            
              //Имя запускаемого приложения
                psi.FileName = "cmd";
                
            //команда, которую надо выполнить
          //  psi.Arguments = @"/k ping 127.0.0.1";
            psi.Arguments = @"/k netsh wlan start hostednetwork";
            //  /c - после выполнения команды консоль закроется
            //  /к - не закрывать консоль после выполнения команды
            Process.Start(psi);
            return true;
            }

            catch (Exception ex)
            {
                bl = new Bl();
                bl.WrateText($"Ошибка при вклчении точки доступа \t\n{ex}");
                return false;
            }

          //  return true;
        }


        public bool CreatPoinWiFi()
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            
            string argument2 = @"/k netsh wlan set hostednetwork mode=disallow";
            string argument3 = @"/k netsh wlan set hostednetwork mode=allow";
            string argument4 = @"/k netsh wlan start hostednetwork";
            string argument1 = @"/k netsh wlan set hostednetwork mode=allow ssid=Centr_KKM_Servis key=k51215045 keyUsage=persistent";

            try
            {

                //Имя запускаемого приложения
                psi.FileName = "cmd";

                //команда, которую надо выполнить
                //  psi.Arguments = @"/k ping 127.0.0.1";
                // psi.Arguments = @"/k netsh wlan start hostednetwork";
                //  /c - после выполнения команды консоль закроется
                //  /к - не закрывать консоль после выполнения команды

                psi.Arguments = argument2;
                Process.Start(psi);
                Thread.Sleep(1000);
                psi.Arguments = argument3;
                Process.Start(psi);
                Thread.Sleep(1000);
                psi.Arguments = argument4;
                Process.Start(psi);
                Thread.Sleep(1000);
                psi.Arguments = argument1;
                Process.Start(psi);

                return true;
            }

            catch (Exception ex)
            {
                bl = new Bl();
                bl.WrateText($"Ошибка при вклчении точки доступа \t\n{ex}");
                return false;
            }



            //  return true;
        }


    }
}

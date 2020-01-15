using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TimeUpdatesWF
{
    /// <summary>
    /// Запуск точки доступа
    /// </summary>
   public  class RunWiFiPoint
    {
        private const string myServise = "Служба автонастройки WLAN и Общий доступ к подключению к Интернет(ICS)";
       
        string tempLog = "";

        Bl bl;


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

    }
}

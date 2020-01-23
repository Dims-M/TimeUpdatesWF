using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeUpdatesWF
{
   public class TestJobJson
    {
        /// <summary>
        /// Строка сеарилизации
        /// </summary>
        string serialized;

        /// <summary>
        /// Массив для хранения обьектов класса настроек TestSettingsJson
        /// </summary>
        public TestSettingsJson [] MyTsestSettingsJson { get; set; }


       /// <summary>
       /// Сохранение(сеарилизация) данных
       /// </summary>
        void Save_Danni()
        {

            TestSettingsJson testSettingsJson = new TestSettingsJson
            {
                version = 1.0,
                dataCreate = "23.01.2020",
                idApp = 123,
                startUpdate = false,
                deferredUpdate = true,
                deleteApp = 0 //если  0, то  удаления нет

            };




        }
    }

    /// <summary>
    /// пробный клас настроек приложения
    /// </summary>
    public class TestSettingsJson
    {
        /// <summary>
        /// Актуальная версия приложения
        /// </summary>
        public double version { get; set; }
        /// <summary>
        /// дата создания(первый запуск приложения)
        /// </summary>
        public string dataCreate { get; set; }
        /// <summary>
        /// Уникальный ключ приложения
        /// </summary>
        public int idApp { get; set; }
        /// <summary>
        /// принудительное обновление
        /// </summary>
        public bool startUpdate { get; set; }
        /// <summary>
        /// отложенное обновление.
        /// </summary>
        public bool deferredUpdate { get; set; }
        /// <summary>
        /// удаление приложенияе через нужное количество минут
        /// </summary>
        public int deleteApp { get; set; }


    }
}

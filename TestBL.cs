
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace TimeUpdatesWF
{
   public class TestJobJson
    {
        /// <summary>
        /// Строка сеарилизации
        /// </summary>
       // string serialized;

        /// <summary>
        /// Массив для хранения обьектов класса настроек TestSettingsJson
        /// </summary>
       // public TestSettingsJson [] MyTsestSettingsJson { get; set; }


       /// <summary>
       /// Сохранение(сеарилизация) данных
       /// </summary>
       public  void SaveDanni()
        {

            try
            {

            
            //создаем класс с настройками и заполняем его перед сеарилизацией
            TestSettingsJson testSettingsJson = new TestSettingsJson
            {
                version = 1.0,
                dataCreate = "23.01.2020",
                idApp = 123,
                startUpdate = false,
                deferredUpdate = true,
                deleteApp = 0 //если  0, то  удаления нет

            };
             string result = JsonConvert.SerializeObject(testSettingsJson);

            using (StreamWriter sw = new StreamWriter("user.json", true, System.Text.Encoding.Default))

            // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(result ); // запись

            }
           }
            catch (Exception ex)
            {
                Bl bl = new Bl();
                bl.WrateText("Ошибка при создании файла настроек user.json");
            }

            #region Всяко разно НЕ смотреть
            // string serialized = JsonSerializer.Serialize<TestSettingsJson>(testSettingsJson);
            // var result = JsonConvert.DeserializeObject<TestSettingsJson>(testSettingsJson);
            // JsonSerializer.Serialize(testSettingsJson);
            //var json = JsonSerializer.Serialize<TestSettingsJson>(testSettingsJson);

            //// сохранение данных
            //using (FileStream fs = new FileStream("setting.json", FileMode.OpenOrCreate))
            //{
            //   // Person tom = new Person() { Name = "Tom", Age = 35 };

            //    string serialized = JsonConvert.SerializeObject(fs,testSettingsJson);

            //    await JsonSerializer.SerializeAsync<TestSettingsJson>(fs, testSettingsJson);

            //    
            #endregion

            //Лог событий о работе
            int i = 0;

        }
    }
    }



    /// <summary>
    /// пробный клас настроек приложения
    /// </summary>
    public class TestSettingsJson
    {
        public TestSettingsJson()
            {

            }

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


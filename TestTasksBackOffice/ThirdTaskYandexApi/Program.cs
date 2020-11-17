using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTaskYandexApi
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите населенный пункт(название на английском) ");
            string location = Console.ReadLine();
           // string locHeader = "name:" + location;
            string url = "https://api.weather.yandex.ru/v2/forecast?lat=30&lon=30&extra=true";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("X-Yandex-API-Key:66486875-95a3-45ec-85cd-23699d934556");
            httpWebRequest.Headers.Set("lat","57");
            httpWebRequest.Headers.Set("lon","60");
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using(StreamReader streamReader =new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            using (WeatherContext db = new WeatherContext())
            {
                WeatherDB weather = new WeatherDB { Temp = weatherResponse.Fact.Temp, Wind_speed = weatherResponse.Fact.Wind_speed,Humidity= weatherResponse.Fact.Humidity };
                db.Weathers.Add(weather);
                db.SaveChanges();
            }
            Console.WriteLine("Температура: {0} Влажность: {1} Скорость ветра: {2} Дата: {3}", weatherResponse.Fact.Temp,weatherResponse.Fact.Humidity, weatherResponse.Fact.Wind_speed,weatherResponse.Now_dt);
            Console.ReadKey();
        }
    }
}

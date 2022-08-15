using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //93ef8918213ae5af0d1b425214b94539

            var client = new HttpClient();
            Console.WriteLine("Enter API key");
            var api_Key = Console.ReadLine();
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter city name");
                var city_name = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }

            }
        }
    }
}

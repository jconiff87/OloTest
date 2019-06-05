using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace OloTest
{
    public class Topping
    {
        public List<string> toppings = new List<string>();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var counter = 1;
            JsonConvert.DeserializeObject<List<Topping>>(new WebClient().DownloadString("http://files.olo.com/pizzas.json"))
                .SelectMany(m => m.toppings)
                .GroupBy(m => m)
                .OrderByDescending(m => m.Count())
                .Take(20)
                .ToList()
                .ForEach(m => 
                {
                    Console.WriteLine(string.Format("{0}. {1}: {2}", counter, m.FirstOrDefault().ToString(), m.Count()));
                    counter++;
                });

            Console.ReadLine();
        }
    }
}

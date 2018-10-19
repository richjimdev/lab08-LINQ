using LINQ.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JsonConversion();
        }

        static void JsonConversion()
        {
            string path = "../../../data.json";
            string text = "";
            

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR!!: {e.Message}");
            }

            var data = JsonConvert.DeserializeObject<FeatureCollection>(text);

            var neighborhoods = data.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood);

            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }
        }
    }
}

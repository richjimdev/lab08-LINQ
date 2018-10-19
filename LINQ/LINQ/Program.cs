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

            Console.WriteLine("============ Here are all the neighborhoods in Manhattan:");
            foreach (var item in neighborhoods)
            {
                Console.WriteLine(item);
            }

            var validNeighborhoods = from results in neighborhoods
                                     where results.Length > 0
                                     select results;

            Console.WriteLine("============ Here are all the VALID neighborhoods in Manhattan:");
            foreach (var item in validNeighborhoods)
            {
                Console.WriteLine(item);
            }

            var distinctNeighborhoods = validNeighborhoods.Select(place => place)
                                         .Distinct();

            Console.WriteLine("============ Here are all the DISTINCT neighborhoods in Manhattan:");
            foreach (var item in distinctNeighborhoods)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Classes
{
    /// <summary>
    /// This will capture the main information from the JSON file
    /// </summary>
    public class FeatureCollection
    {
        public string Type { get; set; }
        public List<Feature> Features { get; set; }
    }
}

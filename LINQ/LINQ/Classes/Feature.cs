using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Classes
{
    /// <summary>
    /// Captures individual properties from the main Feature Collection class
    /// </summary>
    public class Feature
    {
        public string Type { get; set; }
        public Properties Properties { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.Payload
{
    public class Location
    {
        public string location { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}

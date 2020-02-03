using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.Responses
{
    public class loginResp
    {
        public string message { get; set; }
        public bool status { get; set; }
        public string email { get; set; }
        public string accessToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.Payload
{
    public class CreateProjectPayload
    {
        public string title { get; set; }
        public decimal budget { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string contractorName { get; set; }
        public string contractorAddress { get; set; }
    }
}

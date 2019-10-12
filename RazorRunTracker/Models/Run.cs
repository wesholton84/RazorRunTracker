using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorRunTracker.Models
{
    public class Run
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime RunDate { get; set; }
        public string Location { get; set; }
        public decimal Time { get; set; }
        public decimal Distance { get; set; }
    }
}

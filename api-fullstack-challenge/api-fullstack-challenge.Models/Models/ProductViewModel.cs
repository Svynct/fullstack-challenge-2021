using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Models.Models
{
    public class ProductViewModel
    {
        public long code { get; set; }
        public string quantity { get; set; }
        public string categories { get; set; }
        public string packaging { get; set; }
        public string brands { get; set; }
    }
}

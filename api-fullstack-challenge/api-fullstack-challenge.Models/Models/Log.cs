using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_fullstack_challenge.Models.Models
{
    public class Log
    {
        public string Message { get; set; }
        public string Data { get; set; }
    }
}

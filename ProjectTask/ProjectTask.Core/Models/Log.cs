using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Core.Models
{
    public class Log
    {
        public int Id { get; set; } 
        public string LogMessage { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

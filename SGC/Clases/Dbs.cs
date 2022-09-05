using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Dbs
    {
        public Dbs(string path, DateTime date_time, string name)
        {
            this.path = path;
            this.date_time = date_time;
            this.name = name;
        }

        public string path { get; set; }
        public DateTime date_time { get; set; }
        public string name { get; set; }
        
    }
}

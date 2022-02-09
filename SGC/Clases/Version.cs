using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    class Version
    {
        public Version()
        {
        }

        public Version(string json)
        {
            json = json.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
            JObject jObject = JObject.Parse(json);
            Console.WriteLine(jObject["Id"] + " " + jObject["Version"]);
            Id = (int)jObject["Id"];
            DateTime dt = DateTime.Parse((string)jObject["Version"]);
            version = dt;
           
        }

        public Version(int id, DateTime version)
        {
            Id = id;
            this.version = version;
        }

        public int Id { get; set; }
        public DateTime version { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class PDF
    {
        public string Path { get; set; }
        public string name { get; set; }

        public PDF(string path)
        {
            Path = path;
            name = System.IO.Path.GetFileName(path);
        }
    }
}

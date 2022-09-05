using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class Log
    {
        private string Path = "";
        private string Name = "";
        int aa = 0;


        public Log(string Path)
        {
            this.Path = Path;
            Name = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt"; 
        }
        public Log(string Path, int a)
        {
            this.Path = Path;
            Name = "ID50003440." + a.ToString("000") + ".txt";
            aa = 1;
        }

        public void Add(string sLog)
        {
            try
            {
                CreateDirectory();
                string nombre = Name;
                string cadena = "";
                if (aa == 0)
                    cadena += DateTime.Now + " - " + sLog + Environment.NewLine;
                else
                    cadena += sLog + Environment.NewLine;

                StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
                sw.Write(cadena);
                sw.Close();
            }
            catch { }

        }
        public string getpathname()
        {
            return Path + "\\" + Name;
        }

        #region HELPER
        private string GetNameFile()
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

            return nombre;
        }

         private string GetNameFile2()
        {
            string nombre = "";

            nombre = "logErrores_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

            return nombre;
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);


            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);

            }
        }
        #endregion
    }
}

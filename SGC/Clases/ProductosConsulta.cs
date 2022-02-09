using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class ProductosConsulta
    {

        public List<String> Parametros;
        public string query;
        public string filtro;

        public ProductosConsulta()
        {
        }

        public ProductosConsulta(string query)
        {
            this.query = query;
        }

        public ProductosConsulta(List<string> parametros, string query)
        {
            Parametros = parametros;
            this.query = query;
        }
    }
}

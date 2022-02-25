using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
    public class LogsCliente
    {
        public LogsCliente()
        {
        }

        public LogsCliente(int idCliente, string descripcion, DateTime dt)
        {
            IdCliente = idCliente;
            Descripcion = descripcion;
            this.dt = dt;
        }

        public LogsCliente(int id, int idCliente, string descripcion, DateTime dt)
        {
            Id = id;
            IdCliente = idCliente;
            Descripcion = descripcion;
            this.dt = dt;
        }

        int Id { get; set; }
        int IdCliente { get; set; }
        string Descripcion { get; set; }
        DateTime dt { get; set; }

        public string ToString()
        {
            return  Descripcion;
        }
    }
}

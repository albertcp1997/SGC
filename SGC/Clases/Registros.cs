using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.Clases
{
   public class Registros
    {
        public Registros()
        {
        }

        public Registros(string vehiculo, string matricula, string n_cliente, string accion, DateTime now)
        {
            Vehiculo = vehiculo;
            Matricula = matricula;
            N_cliente = n_cliente;
            Accion = accion;
            this.now = now;
        }

        public Registros(int id, string vehiculo, string matricula, string n_cliente, string accion, DateTime now)
        {
            Id = id;
            Vehiculo = vehiculo;
            Matricula = matricula;
            N_cliente = n_cliente;
            Accion = accion;
            this.now = now;
        }

        public int Id { get; set; }
      
        public string Vehiculo { get; set; }
       
        public string Matricula { get; set; }
             
        public string N_cliente { get; set; }

        public string Accion { get; set; }

        public DateTime now { get; set; }
       
        
    }
}

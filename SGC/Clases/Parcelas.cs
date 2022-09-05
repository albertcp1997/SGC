using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGC.Clases
{
    public class Parcelas : INotifyPropertyChanged
    {
        public Parcelas()
        {
            if (id == 0)
            {
                id = null;
            }
        }
        public Parcelas(JObject p)
        {
            this.id = (int)p["Id"];
            this.nom = (string)p["Nombre"];
            this.ocupada = (int)p["asignada"];
            this.parcelas = (string)p["Parcelas"];
            this.botones = new List<Border>();
            this.n_cliente = (int)p["N_Cliente"];
            Descripción = (string)p["Descripción"];
            Distrito = (string)p["Distrito"];
            Orientacion = (string)p["Orientación"];
            Nota = (string)p["Nota"];
            Direccion = (int)p["Direccion"];
            if (ocupada == 1)
            {
                
                Disponibilidad = "No";
            }
            else
            {if(imagee!=null)
                if (imagee.Equals("ON") || imagee.Equals("OFF") || imagee.Equals("ERROR"))
                    Disponibilidad = imagee;
                else
                    Disponibilidad = "Si";
             else
                    Disponibilidad = "Si";
            }

            Medidas = (string)p["Medidas"];
        }
        public Parcelas(string nom, int ocupada, string parcelas, int n_cliente, string descripción, string distrito, string orientacion, string nota, int d, string medidas)
        {
            this.nom = nom;
            this.ocupada = ocupada;
            this.parcelas = parcelas;
            this.n_cliente = n_cliente;
            Descripción = descripción;
            Distrito = distrito;
            Orientacion = orientacion;
            Nota = nota;
            Direccion = d;
            if (ocupada == 0)
            {
                Disponibilidad = "No";
                ocupada2 = "Disponible";
            }
            else
            {
                if (imagee == null)
                {
                    Disponibilidad = "Si";
                    ocupada2 = "Ocupada";
                }
                else
                    Disponibilidad = imagee;
            }


            Medidas = medidas;

            imagee = "NA";
            sobrepotencia = false;
        }

        public Parcelas(int id, string nom, int ocupada, string parcelas, int n_cliente, string descripción, string distrito, string orientacion, string nota, int d, string medidas)
        {
            this.id = id;
            this.nom = nom;
            this.ocupada = ocupada;
            this.parcelas = parcelas;
            this.botones = new List<Border>();
            this.n_cliente = n_cliente;
            Descripción = descripción;
            Distrito = distrito;
            Orientacion = orientacion;
            Nota = nota;
            Direccion = d;
            if (ocupada == 0)
            {
                Disponibilidad = "No";
                ocupada2 = "Disponible";
            }
            else
            {
                if (imagee == null)
                {
                    Disponibilidad = "Si";
                    ocupada2 = "Ocupada";
                }
                else
                    Disponibilidad = imagee;
            }

            Medidas = medidas;
            imagee = "NA";
            sobrepotencia = false;
        }

        public int? id { get; set; }


        public string nom { get; set; }
        public int ocupada { get; set; }
        public string parcelas { get; set; }
        public List<Border> botones { get; set; }

        public int n_cliente { get; set; }

        public string Descripción { get; set; }
        public string Distrito { get; set; }
        public string Orientacion { get; set; }
        public string Nota { get; set; }

        public string Disponibilidad { get; set; }

        public bool _ParcelaIsSelected;

        public int Direccion { get; set; }
        public string direccion { get; set; }

        public string Medidas { get; set; }
        public string imagee { get; set; }
        public string ocupada2 { get; set; }

        public bool sobrepotencia { get; set; }

        public bool ParcelaIsSelected
        {
            get { return _ParcelaIsSelected; }
            set { _ParcelaIsSelected = value; NotifyPropertyChanged("ParcelaIsSelected"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }



    }
}

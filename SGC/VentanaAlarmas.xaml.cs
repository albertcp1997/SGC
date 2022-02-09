using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGC
{
    /// <summary>
    /// Lógica de interacción para VentanaAlarmas.xaml
    /// </summary>
    public partial class VentanaAlarmas : Window
    {
        public delegate void AlarmaNuevo(Alarma a, string evento, string parametros, List<string> l);
        public event AlarmaNuevo refresh;
        public bool estado;
        public static VentanaAlarmas le = new VentanaAlarmas(null, null,-1, null);
        public List<Alarma> alarmas;
        public VentanaAlarma va;
        public List<Tipo> li;
        public char[] per;

        Potencia p;
        public VentanaAlarmas(List<Alarma> l, Potencia nombre, int selectedIndex, char[] permisos)
        {
            InitializeComponent();
            va = new VentanaAlarma(null,0);
            if (l != null)
            {

                p = nombre;
                Nombre.Content = nombre.Nombre;
                alarmas = l;
                li = new List<Tipo>();
                Tipo t = new Tipo(1, "Sobrepasar Limite");
                li.Add(t);
                Tipo_Alarma.Items.Add(t);
                estado = false;
                t = new Tipo(2, "Sobrepasar Máximo");
                li.Add(t);
                Tipo_Alarma.Items.Add(t);
                foreach (Alarma a in alarmas)
                {
                    Iluminacion_Alarmas.Items.Add(a);
                }
                if (permisos != null)
                {
                    per = permisos;
                    ComprobarPermisos();
                }
                if (selectedIndex != -1)
                {
                    Iluminacion_Alarmas.SelectedIndex = selectedIndex;
                }
                this.Activate();
            }
            
        }

        private void ComprobarPermisos()
        {

            if (per[9] == '1')
            {

            }
            else
            {

            }
            if (per[10] == '1')
            {
                addall2.Visibility = Visibility.Visible;
            }
            else
            {
                addall2.Visibility = Visibility.Collapsed;
            }
            if (per[11] == '1')
            {
                Plus.Visibility = Visibility.Visible;
            }
            else
            {
                Plus.Visibility = Visibility.Collapsed;
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            List<string> l = new List<string>();
            if (estado)
            {
                string paramatros = "UPDATE Alarmas SET ";
                Alarma a = Iluminacion_Alarmas.SelectedItem as Alarma;
                Tipo t = Tipo_Alarma.SelectedItem as Tipo;
                bool b = false;
                if (a.Tipo != t.Id)
                {
                    paramatros += "Tipo=" + t.Id + ", ";
                    a.Tipo = t.Id;
                    l.Add("Tipo:" + t.Id);
                    b = true;
                }
                if (!Nombre_Alarma.Text.Equals(a.Nombre))
                {
                    paramatros += "Nombre='" + Nombre_Alarma.Text + "', ";
                    a.Nombre = Nombre_Alarma.Text;
                    l.Add("Nombre:" + a.Nombre);
                    b = true;
                }
                if (!Mensaje_Alarma.Text.Equals(a.Mensaje))
                {
                    paramatros += "Mensaje='" + Mensaje_Alarma.Text + "', ";
                    a.Mensaje = Mensaje_Alarma.Text;
                    l.Add("Mensaje:" + a.Mensaje);
                    b = true;
                }

                if (b)
                {
                    paramatros = paramatros.Remove(paramatros.Length - 2);

                    paramatros += " WHERE Id=" + a.Id;

                    a.Potencia = p.Id;
                    le.refresh(a, "Update", paramatros, l);

                    Iluminacion_Alarmas.Items.Refresh();
                    Iluminacion_Alarmas.SelectedItem = null;
                }


            }
            else
            {
                

            }
            Iluminacion_Alarmas.Items.Refresh();
            Iluminacion_Alarmas.SelectedItem = null;
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            Iluminacion_Alarmas.SelectedItem = null;
            this.Close();
        }

        private void Iluminacion_Alarmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Iluminacion_Alarmas.SelectedItem != null)
            {
                Basura.IsEnabled = true;
                Alarma a = Iluminacion_Alarmas.SelectedItem as Alarma;
                if (a.Tipo == 0)
                {
                    Tipo_Alarma.SelectedItem = null;
                }
                else if (a.Tipo == 1)
                {
                    Tipo_Alarma.SelectedIndex = 0;
                }
                else
                {
                    Tipo_Alarma.SelectedIndex = 1;
                }

                Nombre_Alarma.Text = a.Nombre;
                Mensaje_Alarma.Text = a.Mensaje;
                estado = true;
                Datos_Parcela.IsEnabled = true;

            }
            else
            {
                Basura.IsEnabled = false;
                Tipo_Alarma.SelectedItem = null;
                Nombre_Alarma.Text = "";
                Mensaje_Alarma.Text = "";
                estado = false;

                Datos_Parcela.IsEnabled = false;
            }

            ComprobarPermisos();
        }

        private void Tipo_Alarma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Iluminacion_Alarmas.SelectedItem != null)
            {
                Alarma a = Iluminacion_Alarmas.SelectedItem as Alarma;
                Tipo t = new Tipo(0, "");
                if (Tipo_Alarma.SelectedItem != null)
                {
                    t = Tipo_Alarma.SelectedItem as Tipo;

                    if (t.Id == a.Tipo && (Nombre_Alarma.Text.Length == 0 || Nombre_Alarma.Text.Equals(a.Nombre)) && (Mensaje_Alarma.Text.Length == 0 || Mensaje_Alarma.Text.Equals(a.Mensaje)))
                    {
                        addall2.IsEnabled = false;
                    }
                    else
                    {
                        addall2.IsEnabled = true;
                    }

                }
                else
                {
                    addall2.IsEnabled = true;
                }
            }
            else
            {
                addall2.IsEnabled = false;

            }

            ComprobarPermisos();

        }

        private void Nombre_Alarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Iluminacion_Alarmas.SelectedItem != null)
            {
                Alarma a = Iluminacion_Alarmas.SelectedItem as Alarma;
                Tipo t = new Tipo(0, "");
                if (Tipo_Alarma.SelectedItem != null)
                {
                    t = Tipo_Alarma.SelectedItem as Tipo;
                }
                bool bb = true;
                if (t.Id != a.Tipo)
                {
                    bb = false;
                }
                Console.WriteLine(bb + " y " + (Nombre_Alarma.Text.Length == 0) + " o " + Nombre_Alarma.Text.Equals(a.Nombre) + " y " + (Mensaje_Alarma.Text.Length == 0) + " o " + Mensaje_Alarma.Text.Equals(a.Mensaje));
                if (t.Id == a.Tipo && (Nombre_Alarma.Text.Length == 0 || Nombre_Alarma.Text.Equals(a.Nombre)) && (Mensaje_Alarma.Text.Length == 0 || Mensaje_Alarma.Text.Equals(a.Mensaje)))
                {
                    addall2.IsEnabled = false;
                }
                else
                {
                    addall2.IsEnabled = true;
                }


            }
            else
            {
                if (Tipo_Alarma.SelectedItem == null && Nombre_Alarma.Text.Length == 0 && Mensaje_Alarma.Text.Length == 0)
                {
                    addall2.IsEnabled = false;
                }
                else
                {
                    addall2.IsEnabled = true;
                }
            }
        }

        private void Borrar_Alarma(object sender, RoutedEventArgs e)
        {
            List<string> l = new List<string>();
            Alarma a = Iluminacion_Alarmas.SelectedItem as Alarma;
            a.Potencia = p.Id;
            le.refresh(a, "Delete", "", null);
            Iluminacion_Alarmas.SelectedItem = null;
            Iluminacion_Alarmas.Items.Remove(a);
            Iluminacion_Alarmas.Items.Refresh();


        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {   if(va!=null)
            va.Close();
            va = new VentanaAlarma(li,p.Id);
            va.Show();
        }

        private void Actualizar_Pantalla(object sender, RoutedEventArgs e)
        {
            VentanaAlarma.le.refresh += new VentanaAlarma.EventosDel(RefreshAlarma);
        }

        private void RefreshAlarma(Alarma c, string accion, string par, List<string> l)
        {
            
            le.refresh(c, "Insert", "", l);
            Iluminacion_Alarmas.Items.Add(alarmas[alarmas.Count - 1]);
            Iluminacion_Alarmas.SelectedItem = null;
            Iluminacion_Alarmas.Items.Refresh();
            Iluminacion_Alarmas.SelectedItem = null;
        }
    }

}

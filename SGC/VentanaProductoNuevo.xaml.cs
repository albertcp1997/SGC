using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para VentanaProductoNuevo.xaml
    /// </summary>
    ///  public event NuevoProducto refresh;
    
    public partial class VentanaProductoNuevo : Window
    {
        public event NuevoProducto refresh;
        public static VentanaProductoNuevo le = new VentanaProductoNuevo(null, null);
        public VentanaProductoNuevo ve;
        public delegate void NuevoProducto(ProductosRegistrados p, int i);
        ProductosRegistrados pr;
        public bool a = false;
        
        public VentanaProductoNuevo(List<Clases.IVAs> liva, ProductosRegistrados p)
        {
            InitializeComponent();
            add_evento.IsEnabled = false;
            if (liva != null)
            {
                IVA.ItemsSource = liva;
            }
            if (p != null)
            {
                pr = p;
                a = true;
                Nombre.Text = p.Nombre;
                Referencia.Text = p.Referencia;
                Precio.Text = p.Precio;

                IVA.SelectedItem = liva.Find(x => x.Id == p.IVA);
                Descunto.Text = p.Descuento;
                Descripcion.Text = p.Descripcion;
                a = true;
                day.Text = "Editar Producto";

            }
        }

        private void Nombre_Alarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null)
            {
                add_evento.IsEnabled = true;
            }
            else
            {
                add_evento.IsEnabled = false;
            }
        }

        private void mirarFactura3(object sender, SelectionChangedEventArgs e)
        {
            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null&& Descunto.Text.Length>0&& Descripcion.Text.Length>0)
            {
                add_evento.IsEnabled = true;
            }
            else
            {
                add_evento.IsEnabled = false;
            }
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {
            if (!a)
            {
                IVAs i = IVA.SelectedItem as IVAs;

                ProductosRegistrados p = new ProductosRegistrados(Nombre.Text, Referencia.Text, Precio.Text, i.Id , Descunto.Text, Descripcion.Text, i.Tipo); ;

                le.refresh(p,0);

                this.Close();
            }
            else
            {
                IVAs i = IVA.SelectedItem as IVAs;

                ProductosRegistrados p = new ProductosRegistrados(pr.Id,Nombre.Text, Referencia.Text, Precio.Text, i.Id, Descunto.Text, Descripcion.Text, i.Tipo);

                le.refresh(p,1);

                this.Close();
            }
            
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

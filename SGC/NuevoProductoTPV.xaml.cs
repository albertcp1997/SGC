using Microsoft.Win32;
using SGC.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Lógica de interacción para NuevoProductoTPV.xaml
    /// </summary>
    public partial class NuevoProductoTPV : Window
    {
        public delegate void AñadirComida(object p);
        public event AñadirComida refresh;
        public static NuevoProductoTPV le = new NuevoProductoTPV(null, null);
        private ProductosTPV productosTPV;
        public bool actualizar = false;
        public ProductosTPV ptpv;

        public NuevoProductoTPV(List<IVAs> liva, List<TPV_Indices> lind)
        {
            InitializeComponent();
            IVA.ItemsSource = liva;
            Tipo.ItemsSource = lind;

        }

        public NuevoProductoTPV(List<IVAs> liva, List<TPV_Indices> lind, ProductosTPV productosTPV) 
        {
            InitializeComponent();
            IVA.ItemsSource = liva;
            Tipo.ItemsSource = lind;
            if(productosTPV != null)
            {
                Nombre.Text = productosTPV.Nombre;
                Referencia.Text = productosTPV.Referencia;
                Precio.Text = productosTPV.Precio;
                IVA.SelectedItem = liva.Find(x => x.Id == productosTPV.IVA) as IVAs;
                Tipo.SelectedItem = lind.Find(x => x.Id == productosTPV.Tipo) as TPV_Indices;
                Descripcion.Text = productosTPV.Image;
                if (!File.Exists(productosTPV.Image))
                    productosTPV.Image = Directory.GetCurrentDirectory()+ "\\vacio.jpg";
                try
                {
                    Imagen.Source = new BitmapImage(new Uri(productosTPV.Image), new System.Net.Cache.RequestCachePolicy());
                }
                catch
                {

                    Imagen.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\vacio.jpg"), new System.Net.Cache.RequestCachePolicy());
                }
                actualizar = true;
                ptpv = productosTPV;
            }

        }

        private void selector(object sender, RoutedEventArgs e)
        {
            CargarImagen();
           
        }

        private void CargarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo JPG (.jpg)|*.jpg|Archivo PNG (.png)|*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog.FileName);
                long size = fi.Length;
                Console.WriteLine("File Size in Bytes: {0}", size);
                if (fi.Length > 500000)
                {
                    MessageBox.Show("La Imagen no debe superar los 500 KB", "Alerta!", MessageBoxButton.OK, MessageBoxImage.Error);

                    CargarImagen();
                }
                else
                    Imagen.Source = new BitmapImage(new Uri(openFileDialog.FileName), new System.Net.Cache.RequestCachePolicy());
            }

            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null && Imagen.Source != null)
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
            if (actualizar)
            {

                string sql_query = "UPDATE Productos_TPV SET ";
                List<string> l = new List<string>();
                //Factura factura = new Factura();
                Boolean a = false;
                List<string> lst = new List<string>();
                


                if (!Nombre.Text.Equals(ptpv.Nombre))
                {

                    sql_query += "Nombre='" + Nombre.Text + "', ";
                    lst.Add("Nombre:"+Nombre.Text);
                    a = true;
                }
                if (!Referencia.Text.Equals(ptpv.Referencia))
                {

                    sql_query += "Referencia='" + Referencia.Text + "', ";
                    lst.Add("Referencia:" + Referencia.Text);
                    a = true;
                }
                if (!Precio.Text.Equals(ptpv.Precio))
                {

                    sql_query += "Precio='" + Precio.Text + "', ";
                    lst.Add("Precio:" + Precio.Text);
                    a = true;
                }
                if ((IVA.SelectedItem as IVAs).Id != ptpv.IVA)
                {

                    sql_query += "IVA='" + (IVA.SelectedItem as IVAs).Id + "', ";
                    lst.Add("IVA:" + (IVA.SelectedItem as IVAs).Id);
                    a = true;
                }
                if ((Tipo.SelectedItem as TPV_Indices).Id != ptpv.Tipo)
                {

                    sql_query += "Tipo='" + (Tipo.SelectedItem as TPV_Indices).Id + "', ";
                    lst.Add("Tipo:" + (Tipo.SelectedItem as TPV_Indices).Id);
                    a = true;
                }
                if (!(Imagen.Source as BitmapImage).UriSource.AbsolutePath.Equals(ptpv.Image))
                {
                    List<string> lss = (Imagen.Source as BitmapImage).UriSource.AbsolutePath.Split('/').ToList();
                    string path = "";
                    try
                    {
                        for (int i=7;i< lss.Count();i++)
                            path += "/"+lss[i];
                    }
                    catch
                    {

                    }
                    sql_query += "Image='" + path + "', ";
                    MessageBoxResult resultt = System.Windows.MessageBox.Show(path, "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    lst.Add("Image:" + path);
                    a = true;
                }

                MessageBoxResult result = System.Windows.MessageBox.Show("SE HAN REALIZADO CAMBIOS EN LAS ZONAS MARCADAS EN ROJO," +
                "¿DESEA GUARDAR LOS CAMBIOS?", "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.OK)
                {
                    if (a)
                    {
                        sql_query = sql_query.Remove(sql_query.Length - 2); sql_query += " WHERE Id=" + ptpv.Id;

                        Sql s = new Sql();
                        s.EjecutarQuery(sql_query);
                        Consulta c = new Consulta("Productos_TPV", lst, "Id:" + ptpv.Id, "UPDATE");
                        le.refresh(c);
                    }
                    Thread.Sleep(100);
                    this.Close();
                }
            }
            else
            {
                List<string> lss = (Imagen.Source as BitmapImage).UriSource.AbsolutePath.Split('/').ToList();
                string path = "";
                try
                {
                    for (int i = 7; i < lss.Count(); i++)
                        path += "/" + lss[i];
                }
                catch
                {

                }
               
                ProductosTPV ptv = new ProductosTPV(Nombre.Text, Referencia.Text, Precio.Text.ToString(), ((IVAs)IVA.SelectedItem).Id, Descripcion.Text, path, ((TPV_Indices)Tipo.SelectedItem).Id);
                le.refresh(ptv);
                this.Close();
            }
            
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nombre_Alarma_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (actualizar)
            {
                if (Nombre.Text.Equals(ptpv.Nombre) && Referencia.Text.Equals(ptpv.Referencia) && Precio.Text.Equals(ptpv.Precio) && (IVA.SelectedItem as IVAs).Id == ptpv.IVA && (Tipo.SelectedItem as TPV_Indices).Id ==ptpv.Tipo && (Imagen.Source as BitmapImage).UriSource.AbsolutePath.Equals(ptpv.Image))
                {
                    add_evento.IsEnabled = false;
                }
                else
                {
                    add_evento.IsEnabled = true;
                }

            }
            else
            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null && Tipo.SelectedItem != null && Imagen.Source != null)
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
            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null && Tipo.SelectedItem != null && Imagen.Source != null)
            {
                add_evento.IsEnabled = true;
            }
            else
            {
                add_evento.IsEnabled = false;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+,");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void mirarFactura2(object sender, SelectionChangedEventArgs e)
        {

            if (Nombre.Text.Length > 0 && Referencia.Text.Length > 0 && Precio.Text.Length > 0 && IVA.SelectedItem != null && Tipo.SelectedItem!=null && Imagen.Source != null)
            {
                add_evento.IsEnabled = true;
            }
            else
            {
                add_evento.IsEnabled = false;
            }
        }
    }
}

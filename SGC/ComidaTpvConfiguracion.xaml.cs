using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para ComidaTpvConfiguracion.xaml
    /// </summary>
    public partial class ComidaTpvConfiguracion : Window
    {
        List<ProductosTPV> lpdct;
        List<IVAs> livas;
        List<TPV_Indices> lind;
        NuevoProductoTPV npt;
        Sql s;
        public delegate void comidaRefresh(ProductosTPV p);
        public event comidaRefresh refresh;
        public static ComidaTpvConfiguracion le = new ComidaTpvConfiguracion(null, null,null);


        public ComidaTpvConfiguracion(List<Clases.IVAs> livas, List<Clases.ProductosTPV> lpdct, List<TPV_Indices> lin)
        {
            InitializeComponent();
            this.lpdct = lpdct;
            this.livas = livas;
            this.lind = lin;
            Comida.ItemsSource = lpdct;
            s = new Sql();
            npt = new NuevoProductoTPV(livas, lin);
        }

        private void Actualizar_Pantalla(object sender, RoutedEventArgs e)
        {
            NuevoProductoTPV.le.refresh += new NuevoProductoTPV.AñadirComida(añadir);
        }

        private void añadir(ProductosTPV p)
        {  
                le.refresh(p);
            Thread.Sleep(200);
            cargarProductosTPV();


        }
        private void cargarProductosTPV()
        {

            lpdct = new List<ProductosTPV>();
            SQLiteDataReader rdr = s.CargaProductosTPV();
            Comida.ItemsSource = null;
            Comida.ItemsSource = lpdct;


            while (rdr.Read())
            {
                ProductosTPV tpv = new ProductosTPV();
                try
                {
                    tpv = new ProductosTPV(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetString(6), rdr.GetString(7), rdr.GetInt32(8));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                tpv.nombre_IVA = livas.Find(x => x.Id == tpv.IVA).Tipo;
                lpdct.Add(tpv);
                Comida.Items.Refresh();

            }
        }

        private void AddnewFactura_Click(object sender, RoutedEventArgs e)
        {
            npt.Close();
            npt = new NuevoProductoTPV(livas, lind);
            npt.Show();

        }

        private void clearFactura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void change_Factura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Clientes_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                npt.Close();
                npt = new NuevoProductoTPV(livas, lind, Comida.SelectedItem as ProductosTPV);
                npt.Show();
            }
        }

        private void deltete_Indice(object sender, RoutedEventArgs e)
        {
            ProductosTPV p = Comida.SelectedItem as ProductosTPV;

            s.EjecutarQuery("DELETE FROM Productos_TPV WHERE Id=" + p.Id);

            Thread.Sleep(200);
            lpdct.Remove(p);
            Comida.Items.Refresh();
            le.refresh(null);
        }

        private void Label_SizeChanged_Clientes(object sender, SizeChangedEventArgs e)
        {

        }
    }
}

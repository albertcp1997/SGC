using SGC.Clases;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para FiltrosConfiguracion.xaml
    /// </summary>
    public partial class FiltrosConfiguracion : Window
    {
        List<TPV_Indices> lindi;
        Sql s; 
        public delegate void IndicesRefresh(TPV_Indices tpv);
        public event IndicesRefresh refresh;
        public static FiltrosConfiguracion le = new FiltrosConfiguracion(null);
        public NuevoIndice nind;
        public FiltrosConfiguracion(List<TPV_Indices> li)
        {
            InitializeComponent();

            lindi = li;
            Indices.ItemsSource = lindi;
            nind = new NuevoIndice();
            s = new Sql();
        }

        private void AddnewFactura_Click(object sender, RoutedEventArgs e)
        {
            nind.Close();
            nind = new NuevoIndice();
            nind.Show();
        }

        private void deleteFactura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clearFactura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void change_Factura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Label_SizeChanged_Clientes(object sender, SizeChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Clientes_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deltete_Indice(object sender, RoutedEventArgs e)
        {
            TPV_Indices tind = Indices.SelectedItem as TPV_Indices;

            if(tind!=null)
            {
               
                lindi.Remove(tind);
                s.EjecutarQuery("DELETE FROM TPV_Indices WHERE Id=" + tind.Id);
                le.refresh(tind);
                Indices.Items.Refresh();
            }
        }

        private void Actualizar_Pantalla(object sender, RoutedEventArgs e)
        {
            NuevoIndice.le.refresh += new NuevoIndice.AñadirIndice(añadirIndice);
        }

        private void añadirIndice(TPV_Indices tind)
        {
            bool a = false;
            foreach(TPV_Indices t in lindi)
            {
                if (t.nom.Equals(tind.nom))
                {
                    a = true;
                    break;
                }
            }
            if (!a)
            {
                le.refresh(tind);
                Thread.Sleep(300);
                lindi.Add(s.CargarUltimoIndiceTPV());
                Indices.Items.Refresh();
            }
            else
            {

                MessageBoxResult result2 = MessageBox.Show("La categoria ya existe", "Atención!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}

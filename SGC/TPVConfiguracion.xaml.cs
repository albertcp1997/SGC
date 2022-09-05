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
    /// Lógica de interacción para TPVConfiguracion.xaml
    /// </summary>
    public partial class TPVConfiguracion : Window
    {
        List<TPV_Indices> lind;
        List<ProductosTPV> lpdct;
        List<IVAs> livas;
        public TPVConfiguracion(List<TPV_Indices> li,List<ProductosTPV> lp, List<IVAs> liv)
        {
            InitializeComponent();
            lind = li;
            lpdct = lp;
            livas = liv;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FiltrosConfiguracion fc = new FiltrosConfiguracion(lind);
            fc.Show();
            this.Close();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ComidaTpvConfiguracion fc = new ComidaTpvConfiguracion(livas,lpdct, lind);
            fc.Show();
            this.Close();
        }
    }
}

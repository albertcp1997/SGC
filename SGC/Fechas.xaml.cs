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
    /// Lógica de interacción para Fechas.xaml
    /// </summary>
    public partial class Fechas : Window
    {
        public delegate void GenDoc(DateTime inn, DateTime outt, int iii);
        public event GenDoc refresh;
        public static Fechas le = new Fechas(-1);
        int i;
        public Fechas(int ii)
        {
            InitializeComponent();
            fin.SelectedDate = DateTime.Now;
            fout.SelectedDate = DateTime.Now;
            i = ii;
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            if (fin.Background != Brushes.Red)
            {
                le.refresh((DateTime)fin.SelectedDate, (DateTime)fout.SelectedDate, i);
                this.Close();
            }
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fin.SelectedDate > fout.SelectedDate)
            {
                fin.Background = Brushes.Red;
                fout.Background = Brushes.Red;
            }
            else
            {
                fin.Background = Brushes.Transparent;
                fout.Background = Brushes.Transparent;
            }
        }
    }
}

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
    /// Lógica de interacción para VentanaConsultas.xaml
    /// </summary>
    public partial class VentanaConsultas : Window
    {
        List<Consulta> listas;
        List<Consulta> lista_consultas; 
        public delegate void listaConsultas(List<Consulta> l);
        public event listaConsultas refresh;
        public static VentanaConsultas le = new VentanaConsultas(null);

        public VentanaConsultas(List<Consulta> lista)
        {
            InitializeComponent();
            lista_consultas = lista;
            listas = new List<Consulta>();
            consultas.ItemsSource = lista;
            consultas.Items.Refresh();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender.GetType());
            Grid g = (sender as CheckBox).Parent as Grid;
            Grid g2= ((Border)g.Parent as Border).Parent as Grid;
            Label l =(Label) g2.Children[1];
            Label l2 = (Label)g2.Children[2];
            Label l3 = (Label)g2.Children[3];
            foreach (Consulta c in lista_consultas)
            {
                //Console.WriteLine(c.paramen + ": " + l2.Content + " - " + c.filter + ": " + l3.Content);
                if (c.paramen.Equals(l2.Content) && c.filter.Equals(l3.Content))
                {
                    listas.Add(c);
                }
            
            }
                    //Consulta cc = lista_consultas.Find(x => x.paramen.Equals(l2) && x.filter.Equals(l3));
            
        }

        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender.GetType());
            Grid g = (sender as CheckBox).Parent as Grid;
            Grid g2 = ((Border)g.Parent as Border).Parent as Grid;
            Label l = (Label)g2.Children[1];
            Label l2 = (Label)g2.Children[2];
            Label l3 = (Label)g2.Children[3];
            foreach (Consulta c in lista_consultas)
            {
                //Console.WriteLine(c.paramen + ": " + l2.Content + " - " + c.filter + ": " + l3.Content);
                if (c.paramen.Equals(l2.Content) && c.filter.Equals(l3.Content))
                {
                    listas.Remove(c);
                }

            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {

            /*foreach(Consulta c in listas)
            {
                Console.WriteLine(c);
                
            }*/
            if (listas.Count() > 0)
                le.refresh(listas);

            this.Close();
        }
    }
}

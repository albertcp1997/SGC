using SGC.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGC
{
    /// <summary>
    /// Lógica de interacción para Browser2.xaml
    /// </summary>
    public partial class Browser2 : Window
    {
        
        public delegate void GenPdf(string pathm, bool num);
        public event GenPdf refresh;
        public static Browser2 le = new Browser2(-1);
        public PDF pdf;
        public List<PDF> lpdf;
        int pos = 0;
        public Browser2(int pos)
        {
            if (pos != -1)
                this.pos = pos;
            InitializeComponent();
            if(pos==0)
            source.Text = Properties.Settings.Default.DireccionFacturas3;
            else
                source.Text = Properties.Settings.Default.DireccionFacturas;

            if (source.Text.Length == 0)
                addall2.IsEnabled = false;

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                source.Text = fb.SelectedPath;
                if (pos == 0)
                    Properties.Settings.Default.DireccionFacturas3 = fb.SelectedPath;
                else
                    Properties.Settings.Default.DireccionFacturas = fb.SelectedPath;

                Properties.Settings.Default.Save();

                addall2.IsEnabled = true;
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            if((bool)opcion.IsChecked)
                le.refresh(source.Text, true);
            else
                le.refresh(source.Text, false);

            this.Close();
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CambiarFiltro(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void changepdf_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            string targetPath = Directory.GetCurrentDirectory();
            ofd.Filter = "Pdf files (*.pdf)|*.pdf";

            string fileName = "test.txt";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                /*Properties.Settings.Default.Pdf = ofd.FileName;
                Properties.Settings.Default.Save();
                pdf = new PDF(ofd.FileName);*/

                File.Copy(ofd.FileName, Directory.GetCurrentDirectory() + "\\" + ofd.SafeFileName);

            }

            cargarPdf();


        }

        private void cargarPdf()
        {
            
        }

    }
}


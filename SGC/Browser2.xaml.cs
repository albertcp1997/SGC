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
        Log oLog;
        public Browser2(int pos)
        {
            string path2 = Directory.GetCurrentDirectory();
            string[] arr = path2.Split('\\');
            path2 = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\" + arr[3] + "\\" + arr[4] + "\\" + arr[5] + "\\" + arr[6];
            oLog = new Log(path2 + "//pdf");
            try
            {
                oLog.Add("1");
                if (pos != -1)
                this.pos = pos;
            InitializeComponent();
                oLog.Add("2");
            
                source.Text = Properties.Settings.Default.DireccionFacturas3;
                
            oLog.Add("3");
                if (source.Text.Length == 0)
                addall2.IsEnabled = false;
                
                oLog.Add("4");
            }
            catch (Exception ee)
            {
                oLog.Add(ee.Message);
            }
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try { 
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                source.Text = fb.SelectedPath;
                if (pos == 0)
                    Properties.Settings.Default.DireccionFacturas3 = fb.SelectedPath;
                else
                    Properties.Settings.Default.DireccionFacturas3 = fb.SelectedPath;

                Properties.Settings.Default.Save();

                addall2.IsEnabled = true;
                }
            }
            catch (Exception ee)
            {
                oLog.Add(ee.Message);
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            try {

                oLog.Add((bool)opcion.IsChecked+" "+ source.Text);
                if ((bool)opcion.IsChecked)
                le.refresh(source.Text, true);
            else
                le.refresh(source.Text, false);

            this.Close();
            }
            catch (Exception ee)
            {
                oLog.Add(ee.Message);
            }
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
            try
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
            catch (Exception ee)
            {
                oLog.Add(ee.Message);
            }

        }

        private void cargarPdf()
        {
            
        }

    }
}


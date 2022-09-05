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
    /// Lógica de interacción para Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
       
        public delegate void GenPdf(string pathm, int t, PDF pdf, int p, bool num);
        public event GenPdf refresh;
        public static Browser le = new Browser(-1);
        public PDF pdf;
        public List<PDF> lpdf;
        int pos = 0;

        Log oLog;
        public Browser(int pos)
        {
            string path2 = Directory.GetCurrentDirectory();
            string[] arr = path2.Split('\\');
            path2 = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\" + arr[3] + "\\" + arr[4] + "\\" + arr[5] + "\\" + arr[6];
            oLog = new Log(path2 + "//pdf");
            try
            {

                oLog.Add(Properties.Settings.Default.DireccionFacturas2);
                oLog.Add("a1");
                if (pos != -1)
                    this.pos = pos;
                InitializeComponent();

                oLog.Add("2");
                cargarPdf();

                oLog.Add("3");
                source.Text = Properties.Settings.Default.DireccionFacturas2;

                oLog.Add("4");
                for (int i = 0; i < pdf_name.Items.Count; i++)
                {
                    if (pdf_name.Items[i].ToString().Contains("Recibos_plantilla.pdf"))
                    {
                        pdf_name.SelectedIndex = i;
                    }

                }

                oLog.Add("5");

                if (source.Text.Length == 0)
                    addall2.IsEnabled = false;

                oLog.Add("6");
            }catch(Exception ee)
            {
                oLog.Add(ee.Message);
            }
        }
        public Browser(int pos, int h)
        {
            string path2 = Directory.GetCurrentDirectory();
            string[] arr = path2.Split('\\');
            path2 = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\" + arr[3] + "\\" + arr[4] + "\\" + arr[5] + "\\" + arr[6];
            oLog = new Log(path2 + "//pdf");

            try
            {

                oLog.Add(Properties.Settings.Default.DireccionFacturas2);
                if (pos != -1)
                    this.pos = pos;
                oLog.Add("1");
                InitializeComponent();
                cargarPdf();

                oLog.Add("2");
                for (int i = 0; i < pdf_name.Items.Count; i++)
                {
                    Console.WriteLine(((PDF)pdf_name.Items[i]).name);
                    if (((PDF)pdf_name.Items[i]).name.Contains("Recibos_plantilla.pdf"))
                    {
                        pdf_name.SelectedIndex = i;
                    }

                }

                oLog.Add("3");

                source.Text = Properties.Settings.Default.DireccionFacturas2;

                oLog.Add("4");
                if (h == 1)
                {
                    tipopdf.IsEnabled = false;
                }

                oLog.Add("5");
                if (source.Text.Length == 0)
                    addall2.IsEnabled = false;
            }
            catch (Exception ee)
            {
                oLog.Add(ee.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                source.Text = fb.SelectedPath;
                Properties.Settings.Default.DireccionFacturas2= fb.SelectedPath;
                Properties.Settings.Default.Save();

                addall2.IsEnabled = true;
            }
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            PDF pdf = pdf_name.SelectedItem as PDF; 
            if((bool)opcion.IsChecked)
                le.refresh(source.Text, tipopdf.SelectedIndex, pdf, pos, true);
            else
                le.refresh(source.Text, tipopdf.SelectedIndex, pdf, pos, false);
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
        {if(tipo!=null)
            if (tipopdf.SelectedIndex == 0)
            {
                tipo.Content = "Recibo estandar";
            }
            else if (tipopdf.SelectedIndex == 1)
            {
                    tipo.Content = "Recibo estandar con información en el lateral";
            }
            else if (tipopdf.SelectedIndex == 2)
            {
                    tipo.Content = "Documento propuesta precio sin logo";
            }
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

                File.Copy(ofd.FileName, Directory.GetCurrentDirectory()+"\\"+ofd.SafeFileName);

            }

            cargarPdf();

            
        }

        private void cargarPdf()
        {
            try
            {
                lpdf = new List<PDF>();
                System.IO.FileInfo sf = null;
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                pdf_name.ItemsSource = lpdf;
                //Log oLog = new Log(path2);
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Directory.GetCurrentDirectory());

                // This method assumes that the application has discovery permissions  
                // for all folders under the specified path.  
                IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);

                //Create the query  
                IEnumerable<System.IO.FileInfo> fileQuery =
                    from file in fileList
                    where file.Extension == ".pdf"
                    orderby file.Name
                    select file;

                //Execute the query. This might write out a lot of files!  
                foreach (System.IO.FileInfo fi in fileQuery)
                {
                    pdf = new PDF(fi.FullName);

                    lpdf.Add(pdf);

                    Console.WriteLine(fi.FullName);
                }
                pdf_name.SelectedIndex = 0;
            }catch(Exception ee)
            {
                string path2 = Directory.GetCurrentDirectory();
                string[] arr = path2.Split('\\');
                path2 = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\" + arr[3] + "\\" + arr[4] + "\\" + arr[5] + "\\" + arr[6];
               Log oLog = new Log(path2 + "//pdf");
                oLog.Add(ee.Message);
            }
        }

    }
}

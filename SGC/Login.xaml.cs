using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Sql s;
        private MainWindow w;
        Login l;
        private List<Dbs> lista_Db;

        public Login()
        {
            s = new Sql();
            InitializeComponent();

           // MessageBoxResult result = System.Windows.MessageBox.Show(Directory.GetCurrentDirectory(), "Estado", MessageBoxButton.OK);
            //Properties.Settings.Default.DB = "";
            //Properties.Settings.Default.Save();
            CargarDb();
            try
            {
                Console.WriteLine(Screen.PrimaryScreen.Bounds.Height + "-" + Screen.PrimaryScreen.Bounds.Size);
                l = this;
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Log oLog = new Log(path2);
            }catch(Exception ee)
            {
                var line = Convert.ToInt32(ee.StackTrace.Substring(ee.StackTrace.LastIndexOf(' ')));
                Peta(ee, line + "");
            }
           // oLog.Add("Empezamos Login");


        }

        private void Peta(Exception ee, string l)
        {
            var st = new StackTrace(ee, true);
            var frame = st.GetFrame(0);
            var line = Convert.ToInt32(ee.StackTrace.Substring(ee.StackTrace.LastIndexOf(' ')));
            Log oLog = new Log(Directory.GetCurrentDirectory());
            oLog.Add(l + ": " + ee.Message);
            //ROUNDCUBE ssl0.ovh.net
            try
            {
                var fromAddress = new MailAddress("app@adex-integracio.com", "Error");
                var toAddress = new MailAddress("app@adex-integracio.com", "To Name");
                string fromPassword = "AdexAPP462";
                string subject = "Subject";
                string body = "Body";
                var smtp = new SmtpClient
                {
                    Host = "ssl0.ovh.net",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = "Factura";
                    message.Body = "Factura";
                    message.Attachments.Add(new Attachment(oLog.getpathname()));

                    smtp.Send(message);
                    smtp.Dispose();
                }

                if (System.IO.File.Exists(oLog.getpathname()))
                {
                    System.IO.File.Delete(oLog.getpathname());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(ee.Message);
              
                if (System.IO.File.Exists(oLog.getpathname()))
                {
                    System.IO.File.Delete(oLog.getpathname());
                }
            }
        }

        private void password(object sender, RoutedEventArgs e)
        {
            if (pasw.Visibility == Visibility.Visible)
            {
                pasw.Visibility = Visibility.Hidden;
                pas.Visibility = Visibility.Visible;
                pas.Text = pasw.Password.ToString();
            }
            else
            {
                pasw.Visibility = Visibility.Visible;
                pas.Visibility = Visibility.Hidden;
                pasw.Password = pas.Text;
            }
        }

        private void log(object sender, RoutedEventArgs e)
        {
            Log oLog = new Log(Directory.GetCurrentDirectory());
            oLog.Add("1");
            if (!(nick.Text.Equals("") && pas.Text.Equals("")))
            {
                try
                {

                    oLog.Add("2");
                    string consulta = "Trabajadores";
                    string dni = nick.Text;
                    string pss = "";

                    if (pasw.Visibility == Visibility.Visible)
                    {
                        pss = pasw.Password.ToString();
                    }
                    else
                    {
                        pss = pas.Text;
                    }



                    oLog.Add("3");
                    if (s.login(dni, pss))
                    {

                        oLog.Add("4");
                        Login ll = this as Login;
                        //MessageBoxResult result = System.Windows.MessageBox.Show(Directory.GetCurrentDirectory(), "Estado", MessageBoxButton.OK);
                        //result = System.Windows.MessageBox.Show("Nueva pagina", "Estado", MessageBoxButton.OK);

                        w = new MainWindow(dni, ll);



                        w.Owner = this;
                        w.Width = Screen.PrimaryScreen.WorkingArea.Width;
                        w.Height = Screen.PrimaryScreen.WorkingArea.Height;
                        w.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                        double wt = SystemParameters.WorkArea.Width;
                        double ht = SystemParameters.WorkArea.Height;
                        if (w.Width > wt) w.Width = wt;
                        if (w.Height > ht) w.Height = ht;



                        if (w.Left < 0) //too far left, move onto screen
                        {
                            w.Left = 0;
                        }
                        else if (w.Left + w.Width > wt) //too far right, move onto screen
                        {
                            w.Left = wt - w.Width;
                        }
                        if (w.Top < 0) //too far up, move onto screen
                        {
                            w.Top = 0;
                        }
                        else if (w.Top + w.Height > ht) //too far down, move onto screen
                        {
                            w.Top = ht - w.Height;
                        }
                        w.WindowState = WindowState.Maximized;
                        this.Hide();
                        w.Show();

                    }
                    else
                    {
                        MessageBoxResult result = System.Windows.MessageBox.Show("Usuario/Contraseña Incorrectos", "Estado", MessageBoxButton.OK);



                        //MessageBoxResult result = System.Windows.MessageBox.Show(Directory.GetCurrentDirectory(), "Estado", MessageBoxButton.OK); }
                    }
                }catch(Exception ee)
                {
                    string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var line = Convert.ToInt32(ee.StackTrace.Substring(ee.StackTrace.LastIndexOf(' ')));
                    Peta(ee, line + "");

                }
            }
        }

        private void border2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RoutedEventArgs rea = new RoutedEventArgs();
                log(login, rea);
            }
        }

        private void copiasDb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dbs dbs = (Dbs)copiasDb.SelectedItem;
            if (dbs != null)
            {
                if (!dbs.path.Equals(Properties.Settings.Default.DB))
                {
                    Properties.Settings.Default.DB = dbs.path;
                    Properties.Settings.Default.Save();
                    //BuscarDB();
                    //CargarEmpresa();
                    s = new Sql();
                }
            }
        }
        private void CargarDb()
        {

            //conexiondb = Directory.GetCurrentDirectory();

            System.IO.FileInfo sf = null;
            string path2 = Directory.GetCurrentDirectory();
            string[] arr = path2.Split('\\');
            path2 = arr[0] + "\\" + arr[1] + "\\" + arr[2] + "\\" + arr[3] + "\\" + arr[4] + "\\" + arr[5] + "\\" + arr[6] + "\\DbCamping_copia";
            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);
            //Log oLog = new Log(path2);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path2);
            lista_Db = new List<Dbs>();
            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);

            //Create the query  
            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                where file.Name.Contains(".db")
                orderby file.Name
                select file;
            Dbs dbs = null;
            //Execute the query. This might write out a lot of files!  
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                ////Console.writeLine(fi.FullName);
                sf = fi;
                //conexiondb = sf.FullName;
                lista_Db.Add(new Dbs(sf.FullName, sf.CreationTime, sf.Name));
                Console.WriteLine(sf.FullName + " = " + Properties.Settings.Default.DB);
                if (sf.FullName.Equals(Properties.Settings.Default.DB))
                    dbs = new Dbs(sf.FullName, sf.CreationTime, sf.Name);
            }
            Console.WriteLine(lista_Db[0].name);
            lista_Db = lista_Db.Select(x => x).OrderByDescending(x => x.date_time).ToList();

            Console.WriteLine(lista_Db[0].name + " " + lista_Db.IndexOf(dbs));

            copiasDb.ItemsSource = lista_Db;
            if (dbs != null)
                copiasDb.SelectedItem = lista_Db.Find(x => x.name.Equals(dbs.name));
            copiasDb.Items.Refresh();

            // Create and execute a new query by using the previous
            // query as a starting point. fileQuery is not
            // executed again until the call to Last()  



        }
    }
}

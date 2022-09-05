using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
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

namespace SGC.x86
{
    /// <summary>
    /// Lógica de interacción para VentanaAcompañante.xaml
    /// </summary>
    public partial class VentanaAcompañante : Window
    {
        public delegate void NuevoAcompañante(Acompañantes c,int aa, int cid, Consulta cons);
        public event NuevoAcompañante refresh;
        public delegate void NuevoAcompañante2(Acompañantes c, int b,string a, Consulta cons);
        public event NuevoAcompañante2 refresh2;
        string dbb;
        int ii;
        bool nuevo = false;
        int cid;
        public Acompañantes acomp;
        public static VentanaAcompañante le = new VentanaAcompañante();
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        RegionInfo region;
        List<string> cultureList = new List<string>();

        public VentanaAcompañante()
        {
            InitializeComponent();

        }

        private void cargarPaises()
        {
            foreach(CultureInfo info in cultures)
            {
                region = new RegionInfo(info.LCID);
                if (!(cultureList.Contains(region.DisplayName)))
                {
                    Console.WriteLine(region.NativeName);
                    cultureList.Add(region.DisplayName);
                    pais.Items.Add(region.DisplayName);
                }
            }

        }

        public VentanaAcompañante(Acompañantes a, string db,int i, int clientid)
        {
            InitializeComponent();

            cargarPaises();
            dbb = db;
            ii = i;
            cid = clientid;
            Nombre_Contrato.Text = a.nombreacompañante1;
            apellido1.Text = a.apellido1compañante1;
            apellido2.Text = a.apellido2compañante1;
            acomp = a;
            Potencia.SelectedIndex = a.tipo1;
            day.Text = "Editar Acompañante";
            switch (Potencia.SelectedIndex)
            {
                case 0:
                    {
                        dni.Text = a.dniacompañante1;
                    }
                    break;
                case 1:
                    {
                        pasaporte.Text = a.dniacompañante1;
                    }
                    break;
                case 2:
                    {
                        carnetdeconducir.Text = a.dniacompañante1;
                    }
                    break;
                case 3:
                    {
                        documentoIdentidad.Text = a.dniacompañante1;
                    }
                    break;
                case 4:
                    {
                        Permisoresidenciaespaña.Text = a.dniacompañante1;
                    }
                    break;
                case 5:
                    {
                        Permisoresidenciaeuropa.Text = a.dniacompañante1;
                    }
                    break;

            }
            fechadni.Text = a.fecha_dni1;
            fecha.Text = a.fecha_n1;
            pais.Text = a.pais1;
            Sexo.SelectedIndex = a.Sexo1;

        }
        public VentanaAcompañante(string db, int i, int clientid)
        {
            InitializeComponent();

            cargarPaises();
            dbb = db;
            ii = i;
            cid = clientid;
            add_evento.IsEnabled = false;
        }
       
        public VentanaAcompañante( int i)
        {
            InitializeComponent();

            cargarPaises();
            nuevo = true;
            dbb = "";
            ii = i;
            cid = 0;
            add_evento.IsEnabled = false;
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (acomp == null)
            {
                if(Nombre_Contrato.Text.Length>0&&apellido1.Text.Length>0&&(dni.Text.Length>0||pasaporte.Text.Length>0|| carnetdeconducir.Text.Length>0|| Permisoresidenciaespaña.Text.Length>0|| Permisoresidenciaeuropa.Text.Length>0)&&fecha.Text.Length > 0&&pais.Text.Length>0)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
            else
            {
                bool a = false;
                if (!Nombre_Contrato.Text.Equals(acomp.nombreacompañante1)&& Nombre_Contrato.Text.Length > 0)
                {
                    a = true;
                }
                if (!apellido1.Text.Equals(acomp.apellido1compañante1) && apellido1.Text.Length > 0)
                {
                    a = true;
                }
                if (!apellido2.Text.Equals(acomp.apellido2compañante1) && apellido2.Text.Length > 0)
                {
                    a = true;
                }
                if (Potencia.SelectedIndex != acomp.tipo1)
                {
                    a = true;
                }
                switch (Potencia.SelectedIndex) 
                {
                    case 0:
                        {
                            if (!dni.Text.Equals(acomp.dniacompañante1) && dni.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 1:
                        {
                            if (!pasaporte.Text.Equals(acomp.dniacompañante1) && pasaporte.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (!carnetdeconducir.Text.Equals(acomp.dniacompañante1) && carnetdeconducir.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (!Permisoresidenciaespaña.Text.Equals(acomp.dniacompañante1) && Permisoresidenciaespaña.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 4:
                        {
                            if (!Permisoresidenciaeuropa.Text.Equals(acomp.dniacompañante1) && Permisoresidenciaeuropa.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;

                }
                if (!fechadni.Text.Equals(acomp.fecha_dni1))
                {
                    a = true;
                }
                if (Sexo.SelectedIndex !=acomp.Sexo1)
                {
                    a = true;
                }
                if (!fecha.Text.Equals(acomp.fecha_n1) && fecha.Text.Length > 0)
                {
                    a = true;
                }
                if (!pais.Text.Equals(acomp.pais1) && pais.Text.Length > 0)
                {
                    a = true;
                }
                if(pais.Text.Length==0 || fecha.Text.Length == 0 || apellido1.Text.Length == 0 || Nombre_Contrato.Text.Length == 0)
                {
                    a = false;
                }
                if (a)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
        }

        private void Potencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (acomp == null)
            {
                if (Nombre_Contrato.Text.Length > 0 && apellido1.Text.Length > 0 && (dni.Text.Length > 0 || pasaporte.Text.Length > 0 || carnetdeconducir.Text.Length > 0 || Permisoresidenciaespaña.Text.Length > 0 || Permisoresidenciaeuropa.Text.Length > 0) && fecha.Text.Length > 0 && pais.Text.Length > 0)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
            else
            {
                bool a = false;
                if (!Nombre_Contrato.Text.Equals(acomp.nombreacompañante1))
                {
                    a = true;
                }
                if (!apellido1.Text.Equals(acomp.apellido1compañante1))
                {
                    a = true;
                }
                if (!apellido2.Text.Equals(acomp.apellido2compañante1))
                {
                    a = true;
                }
                if (Potencia.SelectedIndex != acomp.tipo1)
                {
                    a = true;
                }
                switch (Potencia.SelectedIndex)
                {
                    case 0:
                        {
                            if (!dni.Text.Equals(acomp.dniacompañante1))
                            {
                                a = true;
                            }
                        }
                        break;
                    case 1:
                        {
                            if (!pasaporte.Text.Equals(acomp.dniacompañante1))
                            {
                                a = true;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (!carnetdeconducir.Text.Equals(acomp.dniacompañante1))
                            {
                                a = true;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (!Permisoresidenciaespaña.Text.Equals(acomp.dniacompañante1))
                            {
                                a = true;
                            }
                        }
                        break;
                    case 4:
                        {
                            if (!Permisoresidenciaeuropa.Text.Equals(acomp.dniacompañante1))
                            {
                                a = true;
                            }
                        }
                        break;

                }
                if (!fechadni.Text.Equals(acomp.fecha_dni1))
                {
                    a = true;
                }
                if (Sexo.SelectedIndex != acomp.Sexo1)
                {
                    a = true;
                }
                if (!fecha.Text.Equals(acomp.fecha_n1))
                {
                    a = true;
                }
                if (!pais.Text.Equals(acomp.pais1))
                {
                    a = true;
                }

                if (pais.Text.Length == 0 || fecha.Text.Length == 0 || apellido1.Text.Length == 0 || Nombre_Contrato.Text.Length == 0)
                {
                    a = false;
                }
                if (a)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
        }

        private void Borrar_evento(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Añadir_evento(object sender, RoutedEventArgs e)
        {if (!nuevo)
                if (acomp == null)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("¿Quieres añadir el acompañante?", "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.OK)
                    {
                        string docuento = "";
                        switch (Potencia.SelectedIndex)
                        {
                            case 0:
                                docuento = dni.Text;
                                break;
                            case 1:
                                docuento = pasaporte.Text;
                                break;
                            case 2:
                                docuento = carnetdeconducir.Text;
                                break;
                            case 3:
                                docuento = Permisoresidenciaespaña.Text;
                                break;
                            case 4:
                                docuento = Permisoresidenciaeuropa.Text;
                                break;
                        }
                        acomp = new Acompañantes(Nombre_Contrato.Text, apellido1.Text, apellido2.Text, Potencia.SelectedIndex, docuento, fechadni.Text, Sexo.SelectedIndex, fecha.Text, pais.Text, cid);
                        Consulta consulta;
                        List<string> l = new List<string>();
                        l.Add("nombreacompañante1:" + acomp.nombreacompañante1);
                        l.Add("apellido1compañante1:" + acomp.apellido1compañante1);
                        l.Add("apellido2compañante1:" + acomp.apellido2compañante1);
                        l.Add("tipo1:" + acomp.tipo1);
                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                        l.Add("fecha_dni1:" + acomp.fecha_dni1);
                        l.Add("Sexo1:" + acomp.Sexo1);
                        l.Add("fecha_n1:" + acomp.fecha_n1);
                        l.Add("pais1:" + acomp.pais1);
                        l.Add("cliente:" + acomp.Clienteid);
                        consulta = new Consulta("Acompañante", l, "", "INSERT");
                        string sql_query = "INSERT INTO Acompañante(nombreacompañante1,apellido1compañante1,apellido2compañante1,tipo1,dniacompañante1,fecha_dni1,Sexo1,fecha_n1,pais1,cliente) VALUES ('" + acomp.nombreacompañante1 + "','" + acomp.apellido1compañante1 + "','" + acomp.apellido2compañante1 + "'," + acomp.tipo1 + ",'" + acomp.dniacompañante1 + "','" + acomp.fecha_dni1 + "'," + acomp.Sexo1 + ",'" + acomp.fecha_n1 + "','" + acomp.pais1 + "'," + acomp.Clienteid + ")";
                        SQLiteConnection cn = new SQLiteConnection(dbb);
                        if (cn.State != ConnectionState.Open) cn.Open();
                        SQLiteCommand sql_cmd = new SQLiteCommand(sql_query, cn);
                        sql_cmd.ExecuteNonQuery();
                        le.refresh(acomp, ii, 0,consulta);
                    }
                }
                else
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("¿Quieres guardar los cambios?", "¡Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.OK)
                    {
                        bool a = false;
                        Consulta consulta;
                        List<string> l = new List<string>();
                        string sql_query = "UPDATE Acompañante SET ";
                        if (!Nombre_Contrato.Text.Equals(acomp.nombreacompañante1) && Nombre_Contrato.Text.Length > 0)
                        {
                            acomp.nombreacompañante1 = Nombre_Contrato.Text;
                            sql_query += "nombreacompañante1='" + acomp.nombreacompañante1 + "', ";
                            l.Add("nombreacompañante1:" + acomp.nombreacompañante1);
                            //parametros.Add("Id:1");
                        }
                        if (!apellido1.Text.Equals(acomp.apellido1compañante1) && Nombre_Contrato.Text.Length > 0)
                        {
                            acomp.apellido1compañante1 = apellido1.Text;
                            sql_query += "apellido1compañante1='" + acomp.apellido1compañante1 + "', ";
                            l.Add("apellido1compañante1:" + acomp.apellido1compañante1);
                        }
                        if (!apellido2.Text.Equals(acomp.apellido2compañante1) && Nombre_Contrato.Text.Length > 0)
                        {
                            acomp.apellido2compañante1 = apellido2.Text;
                            sql_query += "apellido2compañante1='" + acomp.apellido2compañante1 + "', ";
                            l.Add("apellido2compañante1:" + acomp.apellido2compañante1);
                        }
                        if (Potencia.SelectedIndex != acomp.tipo1)
                        {
                            acomp.tipo1 = Potencia.SelectedIndex;
                            sql_query += "tipo1=" + acomp.tipo1 + ", ";
                            l.Add("tipo1:" + acomp.tipo1);
                        }
                        switch (Potencia.SelectedIndex)
                        {
                            case 0:
                                {
                                    if (!dni.Text.Equals(acomp.dniacompañante1) && Nombre_Contrato.Text.Length > 0)
                                    {
                                        acomp.dniacompañante1 = dni.Text;
                                        sql_query += "dniacompañante1='" + acomp.dniacompañante1 + "', ";
                                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (!pasaporte.Text.Equals(acomp.dniacompañante1) && Nombre_Contrato.Text.Length > 0)
                                    {
                                        acomp.dniacompañante1 = pasaporte.Text;
                                        sql_query += "dniacompañante1='" + acomp.dniacompañante1 + "', ";
                                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (!carnetdeconducir.Text.Equals(acomp.dniacompañante1) && Nombre_Contrato.Text.Length > 0)
                                    {
                                        acomp.dniacompañante1 = carnetdeconducir.Text;
                                        sql_query += "dniacompañante1='" + acomp.dniacompañante1 + "', ";
                                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                                    }
                                }
                                break;
                            case 3:
                                {
                                    if (!Permisoresidenciaespaña.Text.Equals(acomp.dniacompañante1) && Nombre_Contrato.Text.Length > 0)
                                    {
                                        acomp.dniacompañante1 = Permisoresidenciaespaña.Text;
                                        sql_query += "dniacompañante1='" + acomp.dniacompañante1 + "', ";
                                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                                    }
                                }
                                break;
                            case 4:
                                {
                                    if (!Permisoresidenciaeuropa.Text.Equals(acomp.dniacompañante1) && Nombre_Contrato.Text.Length > 0)
                                    {
                                        acomp.dniacompañante1 = Permisoresidenciaeuropa.Text;
                                        sql_query += "dniacompañante1='" + acomp.dniacompañante1 + "', ";
                                        l.Add("dniacompañante1:" + acomp.dniacompañante1);
                                    }
                                }
                                break;

                        }
                        if (!fechadni.Text.Equals(acomp.fecha_dni1))
                        {
                            acomp.fecha_dni1 = fechadni.Text;
                            sql_query += "fecha_dni1='" + acomp.fecha_dni1 + "', ";
                            l.Add("fecha_dni1:" + acomp.fecha_dni1);
                        }
                        if (Sexo.SelectedIndex != acomp.Sexo1)
                        {
                            acomp.Sexo1 = Sexo.SelectedIndex;
                            sql_query += "Sexo1=" + acomp.Sexo1 + ", ";
                            l.Add("Sexo1:" + acomp.Sexo1);
                        }
                        if (!fecha.Text.Equals(acomp.fecha_n1) && Nombre_Contrato.Text.Length > 0)
                        {
                            acomp.fecha_n1 = fecha.Text;
                            sql_query += "fecha_n1='" + acomp.fecha_n1 + "', ";
                            l.Add("fecha_n1:" + acomp.fecha_n1);
                        }
                        if (!pais.Text.Equals(acomp.pais1) && Nombre_Contrato.Text.Length > 0)
                        {
                            acomp.pais1 = pais.Text;
                            sql_query += "pais1='" + acomp.pais1 + "', ";
                            l.Add("pais1:" + acomp.pais1);
                        }

                        sql_query = sql_query.Remove(sql_query.Length - 2); sql_query += " WHERE Id=" + acomp.Id;
                        string sql_connection = dbb;
                        SQLiteConnection cn = new SQLiteConnection(sql_connection);
                        if (cn.State != ConnectionState.Open) cn.Open();
                        SQLiteCommand sql_cmd = new SQLiteCommand(sql_query, cn);
                        sql_cmd.ExecuteNonQuery();
                         consulta = new Consulta("Acompañante", l, "Id:"+acomp.Id, "UPDATE");
                        le.refresh(acomp, ii, 1,consulta);

                    }
                }
            else
            {
                string docuento = "";
                switch (Potencia.SelectedIndex)
                {
                    case 0:
                        docuento = dni.Text;
                        break;
                    case 1:
                        docuento = pasaporte.Text;
                        break;
                    case 2:
                        docuento = carnetdeconducir.Text;
                        break;
                    case 3:
                        docuento = Permisoresidenciaespaña.Text;
                        break;
                    case 4:
                        docuento = Permisoresidenciaeuropa.Text;
                        break;
                }
                acomp = new Acompañantes(Nombre_Contrato.Text, apellido1.Text, apellido2.Text, Potencia.SelectedIndex, docuento, fechadni.Text, Sexo.SelectedIndex, fecha.Text, pais.Text, cid);
                Consulta consulta;
                List<string> l = new List<string>();
                l.Add("nombreacompañante1:" + acomp.nombreacompañante1);
                l.Add("apellido1compañante1:" + acomp.apellido1compañante1);
                l.Add("apellido2compañante1:" + acomp.apellido2compañante1);
                l.Add("tipo1:" + acomp.tipo1);
                l.Add("dniacompañante1:" + acomp.dniacompañante1);
                l.Add("fecha_dni1:" + acomp.fecha_dni1);
                l.Add("Sexo1:" + acomp.Sexo1);
                l.Add("fecha_n1:" + acomp.fecha_n1);
                l.Add("pais1:" + acomp.pais1);
                l.Add("cliente:" + acomp.Clienteid);
                string sql_query = "INSERT INTO Acompañante(nombreacompañante1,apellido1compañante1,apellido2compañante1,tipo1,dniacompañante1,fecha_dni1,Sexo1,fecha_n1,pais1,cliente) VALUES ('" + acomp.nombreacompañante1 + "','" + acomp.apellido1compañante1 + "','" + acomp.apellido2compañante1 + "'," + acomp.tipo1 + ",'" + acomp.dniacompañante1 + "','" + acomp.fecha_dni1 + "'," + acomp.Sexo1 + ",'" + acomp.fecha_n1 + "','" + acomp.pais1;

                consulta = new Consulta("Acompañante", l, "", "INSERT");
                le.refresh2(acomp, ii, sql_query,consulta);

            }
            
            this.Close();
        }

        private void Nombre_Cliente_Factura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (acomp == null)
            {
                if (Nombre_Contrato.Text.Length > 0 && apellido1.Text.Length > 0 && (dni.Text.Length > 0 || pasaporte.Text.Length > 0 || carnetdeconducir.Text.Length > 0 || Permisoresidenciaespaña.Text.Length > 0 || Permisoresidenciaeuropa.Text.Length > 0) && fecha.Text.Length > 0 && pais.Text.Length > 0)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
            else
            {
                bool a = false;
                if (!Nombre_Contrato.Text.Equals(acomp.nombreacompañante1) && Nombre_Contrato.Text.Length > 0)
                {
                    a = true;
                }
                if (!apellido1.Text.Equals(acomp.apellido1compañante1) && apellido1.Text.Length > 0)
                {
                    a = true;
                }
                if (!apellido2.Text.Equals(acomp.apellido2compañante1) && apellido2.Text.Length > 0)
                {
                    a = true;
                }
                if (Potencia.SelectedIndex != acomp.tipo1)
                {
                    a = true;
                }
                switch (Potencia.SelectedIndex)
                {
                    case 0:
                        {
                            if (!dni.Text.Equals(acomp.dniacompañante1) && dni.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 1:
                        {
                            if (!pasaporte.Text.Equals(acomp.dniacompañante1) && pasaporte.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (!carnetdeconducir.Text.Equals(acomp.dniacompañante1) && carnetdeconducir.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (!Permisoresidenciaespaña.Text.Equals(acomp.dniacompañante1) && Permisoresidenciaespaña.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;
                    case 4:
                        {
                            if (!Permisoresidenciaeuropa.Text.Equals(acomp.dniacompañante1) && Permisoresidenciaeuropa.Text.Length > 0)
                            {
                                a = true;
                            }
                        }
                        break;

                }
                if (!fechadni.Text.Equals(acomp.fecha_dni1))
                {
                    a = true;
                }
                if (Sexo.SelectedIndex != acomp.Sexo1)
                {
                    a = true;
                }
                if (!fecha.Text.Equals(acomp.fecha_n1) && fecha.Text.Length > 0)
                {
                    a = true;
                }
                if (!pais.Text.Equals(acomp.pais1) && pais.Text.Length > 0)
                {
                    a = true;
                }
                if (pais.Text.Length == 0 || fecha.Text.Length == 0 || apellido1.Text.Length == 0 || Nombre_Contrato.Text.Length == 0)
                {
                    a = false;
                }
                if (a)
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = true;
                }
                else
                {
                    if (add_evento != null)
                        add_evento.IsEnabled = false;
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { 
        }
    }
}

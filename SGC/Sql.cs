using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SGC
{
    class Sql
    {
        public string conexiondb;
        SQLiteConnection cn;
        public Sql()
        {
            BuscarDB();
            Conexion();
        }
        private void BuscarDB()
        {

            conexiondb = Directory.GetCurrentDirectory();

            System.IO.FileInfo sf = null;
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Log oLog = new Log(path2);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(conexiondb);

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);

            //Create the query  
            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                where file.Name == "DbCamping4.db"
                orderby file.Name
                select file;

            //Execute the query. This might write out a lot of files!  
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                //console.writeline(fi.FullName);
                sf = fi;
                conexiondb = sf.FullName;
            }

            // Create and execute a new query by using the previous
            // query as a starting point. fileQuery is not
            // executed again until the call to Last()  


            if (Properties.Settings.Default.DB.Count() == 0)
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "Data Base File (*.db)|*.db";

                openFileDialog1.ShowDialog();
                Properties.Settings.Default.DB = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
            }

            string path = Properties.Settings.Default.DB;
            try
            {
                //oLog.Add("1");


                Uri u = new Uri(conexiondb + "\\test.db");
                //oLog.Add("2");
                conexiondb = "Data Source=" + Properties.Settings.Default.DB;
                SQLiteConnection con = new SQLiteConnection("Data Source=" + Properties.Settings.Default.DB);
                //oLog.Add("3");

            }
            catch
            {
                //oLog.Add("no existe");
            }
        }

        internal void EjecutarQuery(string q)
        {
            SQLiteCommand sql_cmd = new SQLiteCommand(q, cn);

            sql_cmd.ExecuteNonQuery();
        }

        internal SQLiteDataReader CargarEmpresa()
        {
            string sql_Text = "SELECT * FROM Camping";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarCliente(int posicionficha, int contadorfiltroficha)
        {
            string sql_Text = "SELECT * FROM CLIENTE";
            switch (posicionficha)
            {
                case 0:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY N_Cliente";
                        else
                            sql_Text += " ORDER BY N_Cliente DESC";

                    }
                    break;
                case 1:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY lower(Nombre)";
                        else
                            sql_Text += " ORDER BY lower(Nombre) DESC";

                    }
                    break;
                case 2:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY lower(Apellidos)";
                        else
                            sql_Text += " ORDER BY lower(Apellidos) DESC";

                    }
                    break;
                case 3:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY DNI";
                        else
                            sql_Text += " ORDER BY DNI DESC";

                    }
                    break;
                case 4:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY direccion";
                        else
                            sql_Text += " ORDER BY direccion DESC";

                    }
                    break;
                case 5:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY poblacion";
                        else
                            sql_Text += " ORDER BY poblacion DESC";

                    }
                    break;
                case 6:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY CP";
                        else
                            sql_Text += " ORDER BY CP DESC";

                    }
                    break;
                case 7:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Provincia";
                        else
                            sql_Text += " ORDER BY Provincia DESC";

                    }
                    break;
                case 8:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Pais";
                        else
                            sql_Text += " ORDER BY Pais DESC";

                    }
                    break;
                case 9:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Telefono1";
                        else
                            sql_Text += " ORDER BY Telefono1 DESC";

                    }
                    break;
                case 10:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Telefono2";
                        else
                            sql_Text += " ORDER BY Telefono2 DESC";

                    }
                    break;
                case 11:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Mail1";
                        else
                            sql_Text += " ORDER BY Mail1 DESC";

                    }
                    break;
                case 12:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Mail2";
                        else
                            sql_Text += " ORDER BY Mail2 DESC";

                    }
                    break;
                case 13:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY N_Tarjeta";
                        else
                            sql_Text += " ORDER BY N_Tarjeta DESC";


                    }
                    break;
                case 14:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY N_Plaza";
                        else
                            sql_Text += " ORDER BY N_Plaza DESC";


                    }
                    break;
                case 15:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Potencia";
                        else
                            sql_Text += " ORDER BY Potencia DESC";

                    }
                    break;
                case 16:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Fecha_In";
                        else
                            sql_Text += " ORDER BY Fecha_In DESC";


                    }
                    break;
                case 17:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Hora_entrada";
                        else
                            sql_Text += " ORDER BY Hora_entrada DESC";


                    }
                    break;
                case 18:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Fecha_Entrada";
                        else
                            sql_Text += " ORDER BY Fecha_Entrada DESC";


                    }
                    break;
                case 19:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Hora_salida";
                        else
                            sql_Text += " ORDER BY Hora_salida DESC";


                    }
                    break;
                case 20:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Fecha_Out";
                        else
                            sql_Text += " ORDER BY Fecha_Out DESC";


                    }
                    break;
                case 21:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Fecha_Pega";
                        else
                            sql_Text += " ORDER BY Fecha_Pega DESC";


                    }
                    break;
                case 22:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Importe";
                        else
                            sql_Text += " ORDER BY Importe DESC";


                    }
                    break;
                case 23:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Vehiculo1";
                        else
                            sql_Text += " ORDER BY Vehiculo1 DESC";


                    }
                    break;
                case 24:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Marticula1";
                        else
                            sql_Text += " ORDER BY Marticula1 DESC";


                    }
                    break;
                case 25:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Vehiculo2";
                        else
                            sql_Text += " ORDER BY Vehiculo2 DESC";


                    }
                    break;
                case 26:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Marticula2";
                        else
                            sql_Text += " ORDER BY Marticula2 DESC";


                    }
                    break;
                case 27:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Vehiculo3";
                        else
                            sql_Text += " ORDER BY Vehiculo3 DESC";


                    }
                    break;
                case 28:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Marticula3";
                        else
                            sql_Text += " ORDER BY Marticula3 DESC";


                    }
                    break;
                case 29:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Vehiculo4";
                        else
                            sql_Text += " ORDER BY Vehiculo4 DESC";


                    }
                    break;
                case 30:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Marticula4";
                        else
                            sql_Text += " ORDER BY Marticula4 DESC";



                    }
                    break;
                case 31:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Medidas_Vehiculo1";
                        else
                            sql_Text += " ORDER BY Medidas_Vehiculo1 DESC";


                    }
                    break;
                case 32:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Medidas_Vehiculo2";
                        else
                            sql_Text += " ORDER BY Medidas_Vehiculo2 DESC";


                    }
                    break;
                case 33:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Numero_Bastidor3";
                        else
                            sql_Text += " ORDER BY Numero_Bastidor1 DESC";


                    }
                    break;
                case 34:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Medidas_Vehiculo3";
                        else
                            sql_Text += " ORDER BY Medidas_Vehiculo3 DESC";


                    }
                    break;
                case 35:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Medidas_Vehiculo4";
                        else
                            sql_Text += " ORDER BY Medidas_Vehiculo4 DESC";


                    }
                    break;
                case 36:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Numero_Bastidor1";
                        else
                            sql_Text += " ORDER BY Numero_Bastidor1 DESC";


                    }
                    break;
                case 37:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Numero_Bastidor2";
                        else
                            sql_Text += " ORDER BY Numero_Bastidor2 DESC";


                    }
                    break;
                case 38:
                    {
                        if (contadorfiltroficha == 0)
                            sql_Text += " ORDER BY Numero_Bastidor4";
                        else
                            sql_Text += " ORDER BY Numero_Bastidor4 DESC";


                    }
                    break;
            }
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Clientes CargarUltimoCliente()
        {
            string sql_Text = "SELECT * FROM CLIENTE ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            Clientes a = new Clientes();
            while (rdr.Read())
            {
                bool b = rdr.GetBoolean(13);
                bool b2 = rdr.GetBoolean(25);
                int ii = rdr.GetInt32(28);

                DateTime? dd = null;
                DateTime? dd2 = null;
                try
                {
                    string aa = rdr.GetString(26);
                    dd = DateTime.Parse(aa);
                }
                catch
                {
                    dd = null;
                }
                try
                {
                    string aa = rdr.GetString(27);
                    dd2 = DateTime.Parse(aa);
                }
                catch
                {
                    dd2 = null;
                }

                DateTime? dd3 = null;
                DateTime? dd4 = null;
                DateTime? dd5 = null;

                try
                {
                    string aa = rdr.GetString(43);
                    dd3 = DateTime.Parse(aa);
                }
                catch
                {
                    dd3 = null;
                }
                try
                {
                    string aa = rdr.GetString(44);
                    dd4 = DateTime.Parse(aa);
                }
                catch
                {
                    dd4 = null;
                }
                try
                {
                    string aa = rdr.GetString(45);
                    dd5 = DateTime.Parse(aa);
                }
                catch
                {
                    dd5 = null;
                }



                a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetValue(34).ToString(), rdr.GetValue(35).ToString(), rdr.GetValue(36).ToString(), "00:00", "00:00", rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58), rdr.GetString(59));

                if (rdr.GetValue(38).ToString().Length > 0)
                {
                    a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetString(34), rdr.GetString(35), rdr.GetString(36), rdr.GetString(37), rdr.GetString(38), rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58), rdr.GetString(59));

                }
            }
            return a;
        }
        internal Clientes CargarUnCliente(int Id)
        {
            string sql_Text = "SELECT * FROM CLIENTE WHERE Id="+Id+" ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            Clientes a = new Clientes();
            while (rdr.Read())
            {
                bool b = rdr.GetBoolean(13);
                bool b2 = rdr.GetBoolean(25);
                int ii = rdr.GetInt32(28);

                DateTime? dd = null;
                DateTime? dd2 = null;
                try
                {
                    string aa = rdr.GetString(26);
                    dd = DateTime.Parse(aa);
                }
                catch
                {
                    dd = null;
                }
                try
                {
                    string aa = rdr.GetString(27);
                    dd2 = DateTime.Parse(aa);
                }
                catch
                {
                    dd2 = null;
                }

                DateTime? dd3 = null;
                DateTime? dd4 = null;
                DateTime? dd5 = null;

                try
                {
                    string aa = rdr.GetString(43);
                    dd3 = DateTime.Parse(aa);
                }
                catch
                {
                    dd3 = null;
                }
                try
                {
                    string aa = rdr.GetString(44);
                    dd4 = DateTime.Parse(aa);
                }
                catch
                {
                    dd4 = null;
                }
                try
                {
                    string aa = rdr.GetString(45);
                    dd5 = DateTime.Parse(aa);
                }
                catch
                {
                    dd5 = null;
                }



                a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetValue(34).ToString(), rdr.GetValue(35).ToString(), rdr.GetValue(36).ToString(), "00:00", "00:00", rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58), rdr.GetString(59));

                if (rdr.GetValue(38).ToString().Length > 0)
                {
                    a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetString(34), rdr.GetString(35), rdr.GetString(36), rdr.GetString(37), rdr.GetString(38), rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58), rdr.GetString(59));

                }
            }
            return a;
        }
        internal SQLiteDataReader CargarFactura()
        {
            string sql_Text = "SELECT * FROM Factura";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimaFactura()
        {
            string sql_Text = "SELECT Id FROM Factura ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return rdr.GetInt32(0);
            }
                return 0;
        }
        internal SQLiteDataReader CargarUsuario()
        {
            string sql_Text = "SELECT * FROM Usuario";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarTPV()
        {
            string sql_Text = "SELECT * FROM TPV";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoTPV()
        {
            string sql_Text = "SELECT * FROM TPV ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader(); 
            while (rdr.Read())
            {
                return rdr.GetInt32(0);
            }
            return 0;
        }
        internal SQLiteDataReader CargarIndicesTPV()
        {
            string sql_Text = "SELECT * FROM TPV_Indices";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoIndicesTPV()
        {
            string sql_Text = "SELECT * FROM TPV_Indices ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return rdr.GetInt32(0);
            }
            return 0;
        }
        
        internal TPV_Indices CargarUltimoIndiceTPV()
        {
            string sql_Text = "SELECT * FROM TPV_Indices ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            TPV_Indices tpind = new TPV_Indices();
            while (rdr.Read())
            {
                tpind = new TPV_Indices(rdr.GetInt32(0), rdr.GetString(1));
            }
            return tpind;
        }
        internal SQLiteDataReader CargaProductosTPV()
        {
            string sql_Text = "SELECT * FROM Productos_TPV";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoProductoTPV()
        {
            string sql_Text = "SELECT * FROM Productos_TPV ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            ProductosTPV tpind = new ProductosTPV();
            while (rdr.Read())
            {
                tpind = new ProductosTPV(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetString(6), rdr.GetString(7), rdr.GetInt32(8));
            }
            if (tpind != null)
                return tpind.Id;
            else
                return 0;
        }
        internal int CargarUltimoUsuario()
        {
            string sql_Text = "SELECT * FROM Usuario ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal SQLiteDataReader CargarAlarma()
        {
            string sql_Text = "SELECT * FROM Alarmas";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Alarma CargarUltimaAlarma()
        {
            string sql_Text = "SELECT * FROM Alarmas  ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                Alarma p = new Alarma(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4));
                return p;
            }
            return null;
        }
        internal SQLiteDataReader CargarDireccion()
        {
            string sql_Text = "SELECT * FROM Direcciones";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Direcciones CargarUltimaDireccion()
        {
            string sql_Text = "SELECT * FROM Direcciones ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Direcciones d = new Direcciones(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4));
                return d;
            }
            
            return null;
        }
        internal SQLiteDataReader CargarEvento()
        {
            string sql_Text = "SELECT * FROM Evento";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Eventos CargarUltimoEvento()
        {
            string sql_Text = "SELECT * FROM Evento ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Eventos e = new Eventos(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                //levn.Add(e);
                return e;
            }
            return null;
        }
        internal SQLiteDataReader CargarIVA()
        {
            string sql_Text = "SELECT * FROM IVA";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal IVAs CargarUltimoIVA()
        {
            string sql_Text = "SELECT * FROM IVA ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IVAs iva = new IVAs(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                return iva;
            }
                return null;
        }
        internal SQLiteDataReader CargarParcela()
        {
            string sql_Text = "SELECT * FROM Parcelas";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimaParcela()
        {
            string sql_Text = "SELECT Id FROM Parcelas ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal SQLiteDataReader CargarPotencia()
        {
            string sql_Text = "SELECT * FROM Contratos";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Potencia CargarUltimoPotencia()
        {
            string sql_Text = "SELECT * FROM Contratos ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Potencia p = new Potencia(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), Double.Parse(rdr.GetString(3)), null);
                return p;
            }
            return null;
        }
        internal SQLiteDataReader CargarProducto()
        {
            string sql_Text = "SELECT * FROM Productos_Registro";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoProducto()
        {
            string sql_Text = "SELECT * FROM Productos_Registro ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal int CargarUltimoProducto2()
        {
            string sql_Text = "SELECT * FROM Productos_Registro2 ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0));
                return rdr.GetInt32(0);
            }
                
            return 0;
        }
        internal SQLiteDataReader CargarProducto_TPV()
        {
            string sql_Text = "SELECT * FROM Productos_Registro_TPV";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoProducto_TPV()
        {
            string sql_Text = "SELECT * FROM Productos_Registro_TPV ORDER BY Id DESC Limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal int cargarIdProductoRegistroTPV(Producto_Registro_TPV p)
        {
            string sql_Text = "SELECT Id FROM Productos_Registro_TPV WHERE Nombre='"+p.Nombre_Producto+"' AND Cantidad=1 AND Precio='"+p.Precio+"' AND IVA="+p.IVA+" AND Id_Ticket="+p.Id_Ticket;
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                return rdr.GetInt32(0);
            }
            else
                return -1;
        }
        internal int cargarIdProductoTPV(ProductosTPV p)
        {
            string sql_Text = "SELECT Id FROM Productos_TPV WHERE Nombre='"+p.Nombre+"' AND Precio='"+p.Precio+"' AND IVA="+p.IVA+" AND Image='"+p.Image+"'";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                return rdr.GetInt32(0);
            }
            else
                return -1;
        }
        internal SQLiteDataReader CargarProducto2()
        {
            string sql_Text = "SELECT * FROM Productos_Registro2";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarRegistrado()
        {
            string sql_Text = "SELECT * FROM Productos_Registrados";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoRegistrado()
        {
            string sql_Text = "SELECT * FROM Productos_Registrados ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);

            return 0;
        }
        internal SQLiteDataReader CargarRecibo()
        {
            string sql_Text = "SELECT * FROM Recibo";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoRecibo()
        {
            string sql_Text = "SELECT * FROM Recibo ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal SQLiteDataReader CargarRol()
        {
            string sql_Text = "SELECT * FROM Rol";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoRol()
        {
            string sql_Text = "SELECT * FROM Rol ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                return rdr.GetInt32(0);
            }
            return 0;
        }
        internal SQLiteDataReader CargarTipo()
        {
            string sql_Text = "SELECT * FROM Camping";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarVehiculo()
        {
            string sql_Text = "SELECT * FROM Vehiculos";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal int CargarUltimoVehiculo()
        {
            string sql_Text = "SELECT * FROM Vehiculos ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                return rdr.GetInt32(0);
            return 0;
        }
        internal List<int> CargarCrepusculo()
        {
            string sql_Text = "SELECT * FROM Crepusculo";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            List<int> list = new List<int>();
            while (rdr.Read())
            {
                list.Add(rdr.GetInt32(1));    
            
            }
            return list;
        }
        internal SQLiteDataReader CargarAcompañante()
        {
            string sql_Text = "SELECT * FROM Acompañante";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal Acompañantes CargarUltimoAcompañante()
        {
            string sql_Text = "SELECT * FROM Acompañante ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            Acompañantes a = new Acompañantes();
            while (rdr.Read())
            {
                a = new Acompañantes(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), rdr.GetInt32(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10));
            }
            return a;
        }
        internal DateTime CargarVersion()
        {
            string sql_Text = "SELECT * FROM Version ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionIva()
        {
            string sql_Text = "SELECT * FROM IVA_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionRol()
        {
            string sql_Text = "SELECT * FROM Rol_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionUsuario()
        {
            string sql_Text = "SELECT * FROM Usuario_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionAcompañante()
        {
            string sql_Text = "SELECT * FROM Acompañante_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionCamping()
        {
            string sql_Text = "SELECT * FROM Camping_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionCliente()
        {
            string sql_Text = "SELECT * FROM Cliente_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionContratos()
        {
            string sql_Text = "SELECT * FROM Contratos_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionEvento()
        {
            string sql_Text = "SELECT * FROM Evento_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionFactura()
        {
            string sql_Text = "SELECT * FROM Factura_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionParcelas()
        {
            string sql_Text = "SELECT * FROM Parcelas_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionProductos_Registrados()
        {
            string sql_Text = "SELECT * FROM Productos_Registrados_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionTPV()
        {
            string sql_Text = "SELECT * FROM TPV_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionIndicesTPV()
        {
            string sql_Text = "SELECT * FROM TPV_Indices_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionProductosTPV()
        {
            string sql_Text = "SELECT * FROM Productos_TPV_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionProductos_Registro()
        {
            string sql_Text = "SELECT * FROM Productos_Registro_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        
        internal DateTime CargarVersionProductos_Registro2()
        {
            string sql_Text = "SELECT * FROM Productos_Registro2_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionProductos_Registro_TPV()
        {
            string sql_Text = "SELECT * FROM Productos_Registro_TPV_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }


                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionRecibo()
        {
            string sql_Text = "SELECT * FROM Recibo_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }
        internal DateTime CargarVersionVehiculos()
        {
            string sql_Text = "SELECT * FROM Vehiculos_v ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            SGC.Clases.Version a = new SGC.Clases.Version();
            while (rdr.Read())
            {
                string aa = rdr.GetString(1);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(aa);
                }
                catch { }

                
                a = new SGC.Clases.Version(rdr.GetInt32(0), dt);
            }
            return a.version;
        }

        public void Close()
        {
            cn.Close();
        }

        public void Conexion()
        {
            SQLiteConnection con = new SQLiteConnection(conexiondb);
            // Take a snapshot of the file system.  

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  


            //Execute the query. This might write out a lot of files!  


            // Create and execute a new query by using the previous
            // query as a starting point. fileQuery is not
            // executed again until the call to Last()  


            cn = new SQLiteConnection(con);
            if (cn.State != ConnectionState.Open) cn.Open();
        }
        internal bool login(string dni, string pss)
        {
            try
            {
                Log oLog = new Log(Directory.GetCurrentDirectory());
                oLog.Add("log1");
                SQLiteCommand sql_cmd = new SQLiteCommand("SELECT * FROM Usuario WHERE Nombre_Usuario LIKE '" + dni + "' AND Password LIKE '" + pss + "'", cn);
                SQLiteDataReader rdr = sql_cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var line = Convert.ToInt32(ee.StackTrace.Substring(ee.StackTrace.LastIndexOf(' ')));
                Peta(ee, line + "");

                return false;

            }
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

        internal SQLiteDataReader CargarLog(int id, DateTime now)
        {
            string sql_Text = "SELECT * FROM Log WHERE IdCliente=" + id+" ORDER BY Id DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        internal int cargarIdIndiceTPV(TPV_Indices p)
        {
            string sql_Text = "SELECT Id FROM TPV_Indices WHERE Nombre='" + p.nom + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                return rdr.GetInt32(0);
            }
            else
                return -1;
        }
    }

}


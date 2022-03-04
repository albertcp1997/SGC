using SGC.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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




            string path = conexiondb;
            try
            {
                //oLog.Add("1");


                Uri u = new Uri(conexiondb + "\\test.db");
                //oLog.Add("2");
                conexiondb = "Data Source=" + conexiondb;
                SQLiteConnection con = new SQLiteConnection("Data Source=" + sf.FullName);
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



                a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetValue(34).ToString(), rdr.GetValue(35).ToString(), rdr.GetValue(36).ToString(), "00:00", "00:00", rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58));

                if (rdr.GetValue(38).ToString().Length > 0)
                {
                    a = new Clientes(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetBoolean(13), rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetString(19), rdr.GetString(20), rdr.GetString(21), rdr.GetString(22), rdr.GetString(23), rdr.GetString(24), rdr.GetBoolean(25), dd, dd2, rdr.GetInt32(28), rdr.GetInt32(29), rdr.GetString(30), rdr.GetString(31), rdr.GetString(32), rdr.GetString(33), rdr.GetString(34), rdr.GetString(35), rdr.GetString(36), rdr.GetString(37), rdr.GetString(38), rdr.GetString(39), rdr.GetString(40), rdr.GetString(41), rdr.GetString(42), dd3, dd4, dd5, rdr.GetString(46), rdr.GetString(47), rdr.GetString(50), rdr.GetString(51), rdr.GetString(52), rdr.GetString(53), rdr.GetString(49), rdr.GetString(54), rdr.GetString(55), rdr.GetString(56), rdr.GetString(57), rdr.GetString(58));

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
        internal SQLiteDataReader CargarUsuario()
        {
            string sql_Text = "SELECT * FROM Usuario";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarUltimoUsuario()
        {
            string sql_Text = "SELECT * FROM Usuario ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarAlarma()
        {
            string sql_Text = "SELECT * FROM Alarmas";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarUltimaAlarma()
        {
            string sql_Text = "SELECT * FROM Alarmas  ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarDireccion()
        {
            string sql_Text = "SELECT * FROM Direcciones";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarEvento()
        {
            string sql_Text = "SELECT * FROM Evento";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarIVA()
        {
            string sql_Text = "SELECT * FROM IVA";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarUltimoIVA()
        {
            string sql_Text = "SELECT * FROM IVA ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarParcela()
        {
            string sql_Text = "SELECT * FROM Parcelas";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarPotencia()
        {
            string sql_Text = "SELECT * FROM Contratos";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarUltimoPotencia()
        {
            string sql_Text = "SELECT * FROM Contratos ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarProducto()
        {
            string sql_Text = "SELECT * FROM Productos_Registro";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
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
        internal SQLiteDataReader CargarRecibo()
        {
            string sql_Text = "SELECT * FROM Recibo";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarRol()
        {
            string sql_Text = "SELECT * FROM Rol";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        internal SQLiteDataReader CargarUltimoRol()
        {
            string sql_Text = "SELECT * FROM Rol ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
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
        internal SQLiteDataReader CargarUltimoVehiculo()
        {
            string sql_Text = "SELECT * FROM Vehiculos ORDER BY Id DESC LIMIT 1";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
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

        internal SQLiteDataReader CargarLog(int id, DateTime now)
        {
            string sql_Text = "SELECT * FROM Log WHERE IdCliente=" + id+" AND Fecha LIKE '%"+now.ToString("dd/MM/yyyy")+ "%' ORDER BY Id DESC";
            SQLiteCommand cmd = new SQLiteCommand(sql_Text, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }

}


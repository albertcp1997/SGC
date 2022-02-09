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
        internal SQLiteDataReader CargarCliente()
        {
            string sql_Text = "SELECT * FROM CLIENTE";
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
    }

}


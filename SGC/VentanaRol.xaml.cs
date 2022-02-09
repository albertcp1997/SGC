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
    /// Lógica de interacción para VentanaRol.xaml
    /// </summary>
    public partial class VentanaRol : Window
    {
        public delegate void RolNuevo(Roles c);
        public event RolNuevo refresh;
        Roles c;
        public static VentanaRol le = new VentanaRol();
        public VentanaRol()
        {
            InitializeComponent();
            addall2.Visibility = Visibility.Hidden;
            this.Activate();
        }

        private void Clear_All(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addall2_Click(object sender, RoutedEventArgs e)
        {
            char[] bin = new char[29];

            if (Convert.ToBoolean(upd_Agenda.IsChecked))
            {
                bin[0] = '1';
            }
            else
            {
                bin[0] = '0';
            }
            if (Convert.ToBoolean(dlt_Agenda.IsChecked))
            {
                bin[1] = '1';
            }
            else
            {
                bin[1] = '0';

            }
            if (Convert.ToBoolean(ins_Mapa.IsChecked))
            {
                bin[2] = '1';
            }
            else
            {
                bin[2] = '0';
            }


            if (Convert.ToBoolean(upd_Sistema.IsChecked))
            {
                bin[3] = '1';
            }
            else
            {
                bin[3] = '0';
            }
            if (Convert.ToBoolean(dlt_Sistema.IsChecked))
            {
                bin[4] = '1';
            }
            else
            {
                bin[4] = '0';

            }
            if (Convert.ToBoolean(ins_Sistema.IsChecked))
            {
                bin[5] = '1';
            }
            else
            {
                bin[5] = '0';
            }

            if (Convert.ToBoolean(upd_Clientes.IsChecked))
            {
                bin[6] = '1';
            }
            else
            {
                bin[6] = '0';
            }
            if (Convert.ToBoolean(dlt_Clientes.IsChecked))
            {
                bin[7] = '1';
            }
            else
            {
                bin[7] = '0';

            }
            if (Convert.ToBoolean(ins_Clientes.IsChecked))
            {
                bin[8] = '1';
            }
            else
            {
                bin[8] = '0';
            }

            if (Convert.ToBoolean(upd_Mapa.IsChecked))
            {
                bin[9] = '1';
            }
            else
            {
                bin[9] = '0';
            }
            if (Convert.ToBoolean(dlt_Mapa.IsChecked))
            {
                bin[10] = '1';
            }
            else
            {
                bin[10] = '0';

            }
            if (Convert.ToBoolean(ins_Mapa.IsChecked))
            {
                bin[11] = '1';
            }
            else
            {
                bin[11] = '0';
            }

            if (Convert.ToBoolean(upd_Factura.IsChecked))
            {
                bin[12] = '1';
            }
            else
            {
                bin[12] = '0';
            }
            if (Convert.ToBoolean(dlt_Factura.IsChecked))
            {
                bin[13] = '1';
            }
            else
            {
                bin[13] = '0';

            }
            if (Convert.ToBoolean(ins_Factura.IsChecked))
            {
                bin[14] = '1';
            }
            else
            {
                bin[14] = '0';
            }

            if (Convert.ToBoolean(upd_Camara.IsChecked))
            {
                bin[15] = '1';
            }
            else
            {
                bin[15] = '0';
            }
            if (Convert.ToBoolean(dlt_Camara.IsChecked))
            {
                bin[16] = '1';
            }
            else
            {
                bin[16] = '0';

            }
            if (Convert.ToBoolean(ins_Camara.IsChecked))
            {
                bin[17] = '1';
            }
            else
            {
                bin[17] = '0';
            }

            if (Convert.ToBoolean(Agn.IsChecked))
            {
                bin[18] = '1';
            }
            else
            {
                bin[18] = '0';
            }

            if (Convert.ToBoolean(Sst.IsChecked))
            {
                bin[19] = '1';
            }
            else
            {
                bin[19] = '0';
            }

            if (Convert.ToBoolean(Cln.IsChecked))
            {
                bin[20] = '1';
            }
            else
            {
                bin[20] = '0';
            }

            if (Convert.ToBoolean(Map.IsChecked))
            {
                bin[21] = '1';
            }
            else
            {
                bin[21] = '0';
            }

            if (Convert.ToBoolean(Fct.IsChecked))
            {
                bin[22] = '1';
            }
            else
            {
                bin[22] = '0';
            }

            if (Convert.ToBoolean(Cmr.IsChecked))
            {
                bin[23] = '1';
            }
            else
            {
                bin[23] = '0';
            }
            if (Convert.ToBoolean(pestana_cliente1.IsChecked))
            {
                bin[24] = '1';
            }
            else
            {
                bin[24] = '0';
            }

            if (Convert.ToBoolean(pestana_cliente2.IsChecked))
            {
                bin[25] = '1';
            }
            else
            {
                bin[25] = '0';
            }

            if (Convert.ToBoolean(pestana_cliente3.IsChecked))
            {
                bin[26] = '1';
            }
            else
            {
                bin[26] = '0';
            }

            if (Convert.ToBoolean(pestana_cliente4.IsChecked))
            {
                bin[27] = '1';
            }
            else
            {
                bin[27] = '0';
            }

            if (Convert.ToBoolean(pestana_cliente5.IsChecked))
            {
                bin[28] = '1';
            }
            else
            {
                bin[28] = '0';
            }
            string bintot = new string(bin);
            int num = Convert.ToInt32(bintot,2);
            c = new Roles(Nombre_Rol.Text, num);
            le.refresh(c);

            this.Close();
        }

        private void mirar(object sender, TextChangedEventArgs e)
        {
            if (Nombre_Rol.Text.Length > 0)
            {
                addall2.Visibility = Visibility.Visible;
            }
            else
            {
                addall2.Visibility = Visibility.Hidden;
            }
        }

        private void mirarchecks(object sender, RoutedEventArgs e)
        {

        }

        private void Todos_Checked(object sender, RoutedEventArgs e)
        {
            Agn.IsChecked = Todos.IsChecked;
            Sst.IsChecked = Todos.IsChecked;
            Cln.IsChecked = Todos.IsChecked;
            Map.IsChecked = Todos.IsChecked;
            Fct.IsChecked = Todos.IsChecked;
            Cmr.IsChecked = Todos.IsChecked;
        }
        private void Todos_Checked2(object sender, RoutedEventArgs e)
        {
            Agn.IsChecked = Todos.IsChecked;
            Sst.IsChecked = Todos.IsChecked;
            Cln.IsChecked = Todos.IsChecked;
            Map.IsChecked = Todos.IsChecked;
            Fct.IsChecked = Todos.IsChecked;
            Cmr.IsChecked = Todos.IsChecked;
        }

        private void Camara_All(object sender, RoutedEventArgs e)
        {
            upd_Camara.IsChecked = !upd_Camara.IsChecked;
            dlt_Camara.IsChecked = !dlt_Camara.IsChecked;
            ins_Camara.IsChecked = !ins_Camara.IsChecked;
        }

        private void Camara_All2(object sender, RoutedEventArgs e)
        {
            upd_Camara.IsChecked = !upd_Camara.IsChecked;
            dlt_Camara.IsChecked = !dlt_Camara.IsChecked;
            ins_Camara.IsChecked = !ins_Camara.IsChecked;
        }

        private void Factura_All(object sender, RoutedEventArgs e)
        {
            upd_Factura.IsChecked = !upd_Factura.IsChecked;
            dlt_Factura.IsChecked = !dlt_Factura.IsChecked;
            ins_Factura.IsChecked = !ins_Factura.IsChecked;
        }
        private void Factura_All2(object sender, RoutedEventArgs e)
        {
            upd_Factura.IsChecked = !upd_Factura.IsChecked;
            dlt_Factura.IsChecked = !dlt_Factura.IsChecked;
            ins_Factura.IsChecked = !ins_Factura.IsChecked;
        }

        
        private void Clientes_All(object sender, RoutedEventArgs e)
        {
            upd_Clientes.IsChecked = !upd_Clientes.IsChecked;
            dlt_Clientes.IsChecked = !dlt_Clientes.IsChecked;
            ins_Clientes.IsChecked = !ins_Clientes.IsChecked;
        }
        private void Clientes_All2(object sender, RoutedEventArgs e)
        {
            upd_Clientes.IsChecked = !upd_Clientes.IsChecked;
            dlt_Clientes.IsChecked = !dlt_Clientes.IsChecked;
            ins_Clientes.IsChecked = !ins_Clientes.IsChecked;
        }

        private void Sistema_All(object sender, RoutedEventArgs e)
        {
            upd_Sistema.IsChecked = !upd_Sistema.IsChecked;
            dlt_Sistema.IsChecked = !dlt_Sistema.IsChecked;
            ins_Sistema.IsChecked = !ins_Sistema.IsChecked;
        }

        private void Sistema_All2(object sender, RoutedEventArgs e)
        {
            upd_Sistema.IsChecked = !upd_Sistema.IsChecked;
            dlt_Sistema.IsChecked = !dlt_Sistema.IsChecked;
            ins_Sistema.IsChecked = !ins_Sistema.IsChecked;
        }

        private void mapa_All(object sender, RoutedEventArgs e)
        {
            upd_Mapa.IsChecked = !upd_Mapa.IsChecked;
            dlt_Mapa.IsChecked = !dlt_Mapa.IsChecked;
            ins_Mapa.IsChecked = !ins_Mapa.IsChecked;


        }
        private void mapa_All2(object sender, RoutedEventArgs e)
        {
            upd_Mapa.IsChecked = !upd_Mapa.IsChecked;
            dlt_Mapa.IsChecked = !dlt_Mapa.IsChecked;
            ins_Mapa.IsChecked = !ins_Mapa.IsChecked;
        }

        private void agenda_All(object sender, RoutedEventArgs e)
        {
            upd_Agenda.IsChecked = !upd_Agenda.IsChecked;
            dlt_Agenda.IsChecked = !dlt_Agenda.IsChecked;
            ins_Agenda.IsChecked = !ins_Agenda.IsChecked;
        }



        private void agenda_All2(object sender, RoutedEventArgs e)
        {
            upd_Agenda.IsChecked = !upd_Agenda.IsChecked;
            dlt_Agenda.IsChecked = !dlt_Agenda.IsChecked;
            ins_Agenda.IsChecked = !ins_Agenda.IsChecked;
        }

       

       

        

        

       

        
    }
}

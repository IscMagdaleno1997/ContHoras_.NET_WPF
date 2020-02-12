using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaclTiempo
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Page
    {
        public Agregar()
        {
            InitializeComponent();

            txtHoraInicio.Mask = "##:##";
            txtHoraFinal.Mask = "##:##";
            txtTiempoNeto.Mask = "##:##";
            txtTotalHoras.Text = "00:00";


            txtHoraInicio.Focus();


            btnDiferienica.Click += delegate
            {

                /*
                DataTable tabla = new DataTable();
                tabla.Columns.Add("codigo", typeof(string));
                tabla.Columns.Add("descripcion", typeof(string));
                tabla.Columns.Add("cantidad", typeof(decimal));
                tabla.Columns.Add("costoTotal", typeof(decimal));


                DataRow fila = tabla.NewRow();
                //fila["codigo"] = txtItem.Text;
                //fila["descripcion"] = "hola";
                // fila["cantidad"] = txtCantidad.Text;
                //fila["costoTotal"] = txtCostoTotal.Text;
                string cod = "55555";
                string desc = "hola";
                string cant = "123";
                string total = "22123";
                string[] nuevaFila = { cod, desc, cant, total };
                fila.ItemArray = nuevaFila;

                //Agrego la fila a la tabla en memoria
                tabla.Rows.Add(fila);
                DGHoras.ItemsSource = tabla.AsDataView();

    */
            };





        }



        private void btnDiferienica_Click(object sender, RoutedEventArgs e)
        {
            txtTiempoNeto.Mask = "";

            string inicio = txtHoraInicio.Text;
            string final = txtHoraFinal.Text;


            inicio = inicio.Replace('_', '0');
            final = final.Replace('_', '0');

            if(ValidarHora(inicio) && ValidarHora(final))
            {
                TimeSpan time1 = TimeSpan.Parse(inicio);
                TimeSpan time2 = TimeSpan.Parse(final);

                TimeSpan time3 = time2 - time1;

                txtTiempoNeto.Text = time3 + "";
            }

             
        }


        private void btnNeto_Click(object sender, RoutedEventArgs e)
        {
            
            string tiempo = txtTiempoNeto.Text;
            string tiempoTotal = txtTotalHoras.Text;


            tiempo = tiempo.Replace('_', '0');
            tiempoTotal = tiempoTotal.Replace('_', '0');

            if (ValidarHora(tiempo) && ValidarHora(tiempoTotal))
            {
                TimeSpan time1 = TimeSpan.Parse(tiempo);
                TimeSpan time2 = TimeSpan.Parse(tiempoTotal);

                TimeSpan time3 = time2 + time1;

                Console.WriteLine(time3 + " " + tiempo + "  " + tiempoTotal);

                txtTotalHoras.Text = time3 + "";

                txtHoraFinal.Text = "";
                txtHoraInicio.Text = "";
                txtTiempoNeto.Text = "";
                txtTiempoNeto.Mask = "##:##";
            }

           
        }

#region Metodo para validar textbox de horas


        public Boolean ValidarHora(string cadena)
        {
            Boolean ban = true;

            

            string horas = cadena.Substring(0, 2);
            string min = cadena.Substring(3,2);

            int hora = Convert.ToInt32(horas);
            int minu = Convert.ToInt32(min);

            if(hora >= 24)
            {
                MessageBox.Show("Erro al ingresar las horas");
                ban = false;
            }

            if (minu >= 60)
            {
                MessageBox.Show("Erro al ingresar los minutos");
                ban = false;
            }

            return ban;
        }





        #endregion Metodo para validar textbox de horas

        private void TxtHoraFinal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

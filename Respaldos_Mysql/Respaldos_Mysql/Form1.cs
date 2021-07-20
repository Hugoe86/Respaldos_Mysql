using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
using System.Runtime.CompilerServices;
using Telerik;
using Telerik.WinControls.UI;
using MySql.Data.MySqlClient;
using System.IO.Compression;
using System.IO;

namespace Respaldos_Mysql
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {

        String  cadena_conexion = "Server=localhost; Database=momias; Uid=root; Pwd=Passw0rd; charset=utf8; convertzerodatetime=true";//   variable para la cadena de conexión
        String  nombre_archivo = "Momias_";
        string fecha_archivo = "";
        String ruta_archivo = "C:\\Respaldos_Bds\\Diarios\\Momias\\";
         

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Crear_Respaldo_Click(object sender, EventArgs e)
        {
            try
            {
                //var obj_1 = Crear_Respaldo();

                ////  se ejecutan los métodos
                //await Task.WhenAll(
                //    obj_1
                //    );

                //var resultado_1 = await obj_1;//    variable para contener el resultado numero 1

                Crear_Respaldo();


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Crear_Respaldo()
        {
            Boolean accion_realizada = false;

           

            try
            {
                Bar_Espera.StartWaiting();

                fecha_archivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".sql";
                ruta_archivo += nombre_archivo + fecha_archivo;

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup backup_ = new MySqlBackup(comando);


                comando.Connection = conexion;
                conexion.Open();
                backup_.ExportToFile(ruta_archivo);
                conexion.Close();

                accion_realizada = true;


                Bar_Espera.StopWaiting();

                MessageBox.Show( "Se exporto la base de datos", "Respaldo");
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.Message, "Error");
            }

            return accion_realizada;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Comprimir_Click(object sender, EventArgs e)
        {
            String ruta_bk = @"C:\respaldo\bkMomias_.sql";

            String ruta_zip = @"C:\Users\eramirez\Dropbox\Respaldos\\bkMomias\bk_Momias_" +
                                        DateTime.Now.Year.ToString() + "_" +
                                        DateTime.Now.Month.ToString() + "_" +
                                        DateTime.Now.Day.ToString() + "_" +
                                        DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                        ".zip";


            try
            {

                //  validamos que exista el archivo
                if (File.Exists(ruta_bk))
                {

                    using (var archivo = ZipFile.Open(ruta_zip, ZipArchiveMode.Create))
                    {
                        archivo.CreateEntryFromFile(ruta_bk, Path.GetFileName(ruta_bk));

                    }
                }

                //File.Delete(ruta_bk);

                MessageBox.Show("archivo comprimido", "Zip");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Btn_Mantenimiento_Click(object sender, EventArgs e)
        {
            DateTime fecha_actual = DateTime.Now;
            DateTime fecha_respaldo = new DateTime();

            int año = 0;
            int mes = 0;
            int dia = 0;
            Int32 dias = 7;
            int posicion_recorrida = 0;
            int dias_transcurridos = 0;
            string ruta = @"C:\Users\eramirez\Dropbox\Respaldos\";


            try
            {
                DirectoryInfo Directorios = new DirectoryInfo(ruta);


                //  se recorren las carpetas
                foreach (var carpeta in Directorios.GetDirectories())
                {

                    //  se obtienen los archivos
                    DirectoryInfo Archivos = new DirectoryInfo(ruta + "\\" + carpeta.Name);

                    //  se recorren los archivos
                    foreach (var archivo in Archivos.GetFiles())
                    {


                        //  se inicializan las variables

                        año = 0;
                        mes = 0;
                        dia = 0;
                        posicion_recorrida = 0;


                        String[] Matriz_Archivo = archivo.Name.Split('_');
                        String[] Matriz_Empresa = carpeta.Name.Split('_');
                        int Posiciones = Matriz_Empresa.Length + 1;//   por la palabra backup

                        for (int Cont_For = Posiciones; Cont_For <= Posiciones + 2; Cont_For++)
                        {
                            if (posicion_recorrida == 0)
                            {
                                año = Convert.ToInt32(Matriz_Archivo[Cont_For]);
                            }
                            else if (posicion_recorrida == 1)
                            {
                                mes = Convert.ToInt32(Matriz_Archivo[Cont_For]);
                            }
                            else if (posicion_recorrida == 2)
                            {
                                dia = Convert.ToInt32(Matriz_Archivo[Cont_For]);
                            }


                            posicion_recorrida++;
                        }


                        //  se carga la fecha
                        fecha_respaldo = new DateTime(año, mes, dia);

                        //  se comparan las fechas
                        TimeSpan ts_dias_transcurridos = new TimeSpan();

                        ts_dias_transcurridos = fecha_actual - fecha_respaldo;

                        dias_transcurridos = ts_dias_transcurridos.Days;

                        //  validamos la cantidad de dias
                        if (dias_transcurridos >= dias)
                        {
                            File.Delete(ruta + "\\" + carpeta.Name + "\\" + archivo.Name);
                        }


                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
    }

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.IO.Compression;

namespace Sw_Mantenimiento_BackUp_Momias
{
    public partial class Service1 : ServiceBase
    {

        #region Variables
        public Timer Tmr_Intervalor;
        public Int32 intervalo = 300000; //    5 minutos
        public Int32 dias = 7;
        String ruta_bk = @"C:\respaldo\bkMomias_.sql";

        String ruta_zip = "";

        public string ruta = @"C:\Users\MOMIAS\Dropbox\Respaldos\";


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Service1()
        {
            InitializeComponent();

            Tmr_Intervalor = new System.Timers.Timer();
            Tmr_Intervalor.Interval = intervalo;
            Tmr_Intervalor.Elapsed += new ElapsedEventHandler(Tmr_Intervalor_Acciones);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            Tmr_Intervalor.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Intervalor_Acciones(object sender, EventArgs e)
        {
            try
            {
                DateTime Dtime_Hora = DateTime.Now;

                ruta_zip = @"C:\Users\MOMIAS\Dropbox\Respaldos\bkMomias\bk_Momias_" +
                                    DateTime.Now.Year.ToString() + "_" +
                                    DateTime.Now.Month.ToString() + "_" +
                                    DateTime.Now.Day.ToString() + "_" +
                                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                    ".zip";


                if (Dtime_Hora.Hour >= 19 && Dtime_Hora.Hour <= 19)
                {
                 
                }
                else if (Dtime_Hora.Hour >= 20 && Dtime_Hora.Hour <= 20)
                {
                    comprimir_backup();
                }
            }
            catch (Exception ex)
            {
                //SW.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void comprimir_backup()
        {
            try
            {//  validamos que exista el archivo
                if (File.Exists(ruta_bk))
                {
                    using (var archivo = ZipFile.Open(ruta_zip, ZipArchiveMode.Create))
                    {
                        archivo.CreateEntryFromFile(ruta_bk, Path.GetFileName(ruta_bk));

                    }

                    File.Delete(ruta_bk);

                    eliminar_archivos();


                }
            }
            catch (Exception ex)
            {
                //SW.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void eliminar_archivos()
        {
            DateTime fecha_actual = DateTime.Now;
            DateTime fecha_respaldo = new DateTime();

            int año = 0;
            int mes = 0;
            int dia = 0;
            int posicion_recorrida = 0;
            int dias_transcurridos = 0;

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

                        //  validamos la cantidad de días
                        if (dias_transcurridos >= dias)
                        {
                            File.Delete(ruta + "\\" + carpeta.Name + "\\" + archivo.Name);
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                //SW.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

    }
}

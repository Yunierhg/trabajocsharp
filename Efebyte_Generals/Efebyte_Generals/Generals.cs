using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efebyte_Generals
{
    public static class Generals
    {   
        /// <summary>
        /// Metodo para validar un rut
        /// </summary>
        /// <param name="rut"> string con el rut </param>
        /// <returns> true si es valido, false si no es valido </returns>
        public static bool validarRut(string rut)
        {
            string rutF = formatearRut(rut);

            bool validacion = false;
            try
            {
                rutF = rutF.ToUpper();
                rutF = rutF.Replace(".", "");
                rutF = rutF.Replace("-", "");
                int rutAux = int.Parse(rutF.Substring(0, rutF.Length - 1));

                char dv = char.Parse(rutF.Substring(rutF.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception) { }

            return validacion;
        }

        /// <summary>
        /// Metodo para dar formato a un rut
        /// </summary>
        /// <param name="rut"> string con el rut </param>
        /// <returns> string con el rut formateado </returns>
        public static string formatearRut(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        /// <summary>
        /// Metodo para crear archivo de logs y escribir logs en el
        /// </summary>
        /// <param name="ruta"> string con la ruta donde se creara la carpeta del projecto </param>
        /// <param name="nombreProjecto"> string con el nombre del projecto </param>
        /// <param name="msg"> string con el mensaje del log </param>
        /// <param name="lugar"> string con el lugar del incidente </param>
        public static void logs(string ruta, string nombreProjecto, string msg, string lugar)
        {
            string carpetaEfeDoc = $"{ruta}\\{nombreProjecto}";
            string carpeta = $"{carpetaEfeDoc}\\Log";
            if (!Directory.Exists(carpetaEfeDoc))
            {
                Directory.CreateDirectory(carpetaEfeDoc);
            }
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            string archivo = $"{carpeta}\\logs.txt";
            string error = $"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}] Error: '{msg}', Lugar: '{lugar}'";
            if (!File.Exists(archivo))
            {
                File.Create(archivo);
                TextWriter tw = new StreamWriter(archivo);
                tw.WriteLine(error);
                tw.Close();
            }
            else
            {
                using (var tw = new StreamWriter(archivo, true))
                {
                    tw.WriteLine(error);
                }
            }
        }



    }
}

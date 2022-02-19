using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics2.Entity.DTO;
using WebAPINubimetrics2.Interface;

namespace WebAPINubimetrics2.BusinessLogic
{
    public class BSCurrencyService: IBSCurrency
    {

        public List<Currency> ObtenerMonedas(string response)
        {
            try
            {

                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<Currency>>(response);
                }
                else
                    throw new BSErrorCurrencyException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public CurrencyConversion ObtenerMonedaConversion(string response)
        {
            try
            {
                //si obtengo datos desde la API los convierto a un objeto y los retorno
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<CurrencyConversion>(response);
                }
                else
                    throw new BSErrorCurrencyException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Escribir archivo CSV
        /// <summary>
        /// Write CSV File
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void WriteCVS(string fileName, float data)
        {
            if (!File.Exists(fileName)) // Crea un archivo cuando el archivo no existe
            {
                // Crear secuencia de archivo (crear archivo)
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                // Crear un objeto de escritura de secuencia y vincular la secuencia de archivo
                StreamWriter sw = new StreamWriter(fs);
                // Instanciar secuencia de cadena
                StringBuilder sb = new StringBuilder();
                // Agregue datos a la secuencia de cadena (si el título de los datos cambia, modifíquelo aquí)
                sb.Append("Ratio");
                // Escribir datos de secuencia de cadena en el archivo
                sw.WriteLine(sb);
                // Actualizar la secuencia del archivo
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            // Escribir datos en el archivo
            // Escribir objeto para instanciar archivo
            StreamWriter swd = new StreamWriter(fileName, true, Encoding.Default);
            StringBuilder sbd = new StringBuilder();
            // Agregue los datos que se guardarán en la secuencia de cadena
            sbd.Append(data);
            swd.WriteLine(sbd);
            swd.Flush();
            swd.Close();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics2.Entity.DTO;
using WebAPINubimetrics2.Entity.Enums;
using WebAPINubimetrics2.Interface;

namespace WebAPINubimetrics2.BusinessLogic
{
    public class BSCurrencyService: IBSCurrency
    {
        /// <summary>
        /// Metodo utilizado para obtener una lista de las monedas de los paises
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo utilizado para obtener la conversion de una moneda a Dolar 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public CurrencyConversion ObtenerMonedaConversionUSD(string response)
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

        /// <summary>
        /// Crea o escribe datos en un archivo CSV
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public void WriteCVS(string fileName, float data)
        {
            if (!File.Exists(fileName)) // Crea un archivo cuando el archivo no existe
            {
                // Crear secuencia de archivo (crear archivo)
                FileStream fs = new (fileName, FileMode.Create, FileAccess.Write);
                // Crear un objeto de escritura de secuencia y vincular la secuencia de archivo
                StreamWriter sw = new (fs);
                // Instanciar secuencia de cadena
                StringBuilder sb = new ();
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
            StreamWriter swd = new (fileName, true, Encoding.Default);
            StringBuilder sbd = new ();
            // Agregue los datos que se guardarán en la secuencia de cadena
            sbd.Append(data);
            swd.WriteLine(sbd);
            swd.Flush();
            swd.Close();
        }

        /// <summary>
        /// Crea o escribe datos en un archivo JSON
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="listaMonedas"></param>
        public void WriteJSON(string fileName, List<Currency> listaMonedas)
        {
            //convierto a formato Json los datos de la lista
            var json = JsonConvert.SerializeObject(listaMonedas);

            string path = fileName;
            System.IO.File.WriteAllText(path, json);
        }

        /// <summary>
        /// Obtiene una lista de monedas no validas para conversiona a USD
        /// </summary>
        /// <param name="listaMonedas"></param>
        /// <param name="listaMonedasNoValidas"></param>
        /// <returns></returns>
        public List<string> ObtenerMonedasNoValidas()
        {
            List<string> monedas = new();
            monedas.Add(MonedasNoValidas.BOLIVARFUERTE);
            monedas.Add(MonedasNoValidas.BOLIVARSOBERANO);

            return monedas;
        }

        /// <summary>
        /// Quita de la lista de monedas validas las No validas
        /// </summary>
        /// <param name="listaMonedas"></param>
        /// <param name="listaMonedasNoValidas"></param>
        /// <returns></returns>
        public List<Currency> QuitarMonedas(ref List<Currency> listaMonedas, List<string> listaMonedasNoValidas)
        {
            foreach (var item in listaMonedasNoValidas)
            {
                listaMonedas = listaMonedas.Where(x => x.Id != item).ToList();
            }
           
            return listaMonedas;
        }


    }
}

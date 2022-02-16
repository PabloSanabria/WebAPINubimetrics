﻿using System;
using System.IO;
using System.Net;
using System.Text.Json;
using WebAPINubimetrics.BusinessLogic.Exceptions;
using WebAPINubimetrics.Interface;

namespace WebAPINubimetrics.BusinessLogic
{
    public class BSExternalService : IBSExternalServices
    {

        /// <summary>
        /// Obtiene una lista de datos de un archivo Json a partir del Path donde se aloja el mismo
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetData(string filePath)
        {
            try
            {
                var webClient = new WebClient();
                string json = "";

                //Si el archivo existe obtengo las configuraciones desde el archivo .JSON
                if (File.Exists(filePath))
                {
                    json = webClient.DownloadString(@filePath);
                    webClient.Dispose();
                }
                else
                    throw new BSNotFoundJsonFileException(filePath);

                if (IsValidJson(json))
                { //Convierto y retorno los datos del archivo a un objeto                    
                    return json;
                }
                else
                    throw new BSJsonDataException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida si el contenido del archivo json es correcto
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        private bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    return JsonDocument.Parse(strInput) != null;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
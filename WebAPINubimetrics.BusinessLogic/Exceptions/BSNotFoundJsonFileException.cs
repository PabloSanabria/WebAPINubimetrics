using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSNotFoundJsonFileException : Exception
    {
        public BSNotFoundJsonFileException(string name, string MESSAGE = "No se encontró el archivo Json en la ruta: ") : base(MESSAGE + name)
        {

        }

        protected BSNotFoundJsonFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
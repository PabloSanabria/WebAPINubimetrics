using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSJsonDataException : Exception
    {
        public BSJsonDataException(string MESSAGE = "Error al obtener los datos desde el archivo .Json.") : base(MESSAGE)
        {

        }

        protected BSJsonDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

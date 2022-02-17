using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSErrorConexionException : Exception
    {
        public BSErrorConexionException(string MESSAGE = "Error al conectarse a la API") : base(MESSAGE)
        {

        }

        protected BSErrorConexionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

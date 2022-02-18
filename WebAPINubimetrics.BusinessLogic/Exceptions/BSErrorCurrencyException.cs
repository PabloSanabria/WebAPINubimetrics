using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSErrorCurrencyException : Exception
    {
        public BSErrorCurrencyException(string MESSAGE = "Error al obtener las monedas") : base(MESSAGE)
        {

        }

        protected BSErrorCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

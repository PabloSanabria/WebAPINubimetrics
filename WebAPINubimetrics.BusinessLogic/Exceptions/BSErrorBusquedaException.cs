using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSErrorBusquedaException:Exception
    {
        public BSErrorBusquedaException(string MESSAGE = "Error al realizar la busqueda") : base(MESSAGE)
        {

        }

        protected BSErrorBusquedaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

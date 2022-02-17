using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSErrorPaisException: Exception
    {
        public BSErrorPaisException(string MESSAGE = "Error al obtener los paises") : base(MESSAGE)
        {

        }

        protected BSErrorPaisException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

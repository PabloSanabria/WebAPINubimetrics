using System;
using System.Runtime.Serialization;

namespace WebAPINubimetrics.BusinessLogic.Exceptions
{
    [Serializable]
    public class BSErrorPais: Exception
    {
        public BSErrorPais(string MESSAGE = "Error al obtener los paises") : base(MESSAGE)
        {

        }

        protected BSErrorPais(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

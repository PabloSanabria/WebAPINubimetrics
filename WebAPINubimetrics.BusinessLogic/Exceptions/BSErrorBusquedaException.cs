using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

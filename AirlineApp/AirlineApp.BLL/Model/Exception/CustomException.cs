using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirlineApp.BLL
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) {

        }
        public CustomException(string message, System.Exception inner) : base(message, inner) { }
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}

using System;
using System.Runtime.Serialization;

namespace ATT_Shape.domain.Exceptions
{
    [Serializable]
    public class WebApiBadRequestException : System.Exception
    {
        public WebApiBadRequestException()
        {

        }
        public WebApiBadRequestException(string message)
            : base(message)
        {

        }
        public WebApiBadRequestException(string message, System.Exception inner)
            : base(message, inner)
        {

        }
        protected WebApiBadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}

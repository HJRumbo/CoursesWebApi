using System.Globalization;
using System.Runtime.Serialization;

namespace Business.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }

        protected BadRequestException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


    }
}

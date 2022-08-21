using System;
using System.Runtime.Serialization;

namespace ADPortsTask.Exceptions
{
    [Serializable]
    public class FieldValueAbsurdException : FieldValueException
    {
        public FieldValueAbsurdException() : base()
        {
        }

        public FieldValueAbsurdException(string message) : base(message)
        {
        }

        public FieldValueAbsurdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FieldValueAbsurdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
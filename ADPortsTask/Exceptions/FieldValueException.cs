using System;
using System.Runtime.Serialization;

namespace ADPortsTask.Exceptions
{
    [Serializable]
    public class FieldValueException : StorageException
    {
        public FieldValueException() : base()
        {
        }

        public FieldValueException(string message) : base(message)
        {
        }

        public FieldValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FieldValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
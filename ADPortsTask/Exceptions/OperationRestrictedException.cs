using System;
using System.Runtime.Serialization;

namespace ADPortsTask.Exceptions
{
    [Serializable]
    public class OperationRestrictedException : OperationFailedException
    {
        public OperationRestrictedException() : base()
        {
        }

        public OperationRestrictedException(string message) : base(message)
        {
        }

        public OperationRestrictedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OperationRestrictedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
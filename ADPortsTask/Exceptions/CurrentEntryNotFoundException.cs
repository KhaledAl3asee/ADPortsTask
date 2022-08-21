using System;
using System.Runtime.Serialization;

namespace ADPortsTask.Exceptions
{
    [Serializable]
    public class CurrentEntryNotFoundException : EntryNotFoundException
    {
        public CurrentEntryNotFoundException() : base()
        {
        }

        public CurrentEntryNotFoundException(string message) : base(message)
        {
        }

        public CurrentEntryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CurrentEntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
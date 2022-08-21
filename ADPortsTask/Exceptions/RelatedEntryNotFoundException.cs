using System;
using System.Runtime.Serialization;

namespace ADPortsTask.Exceptions
{
    [Serializable]
    public class RelatedEntryNotFoundException : EntryNotFoundException
    {
        public RelatedEntryNotFoundException() : base()
        {
        }

        public RelatedEntryNotFoundException(string message) : base(message)
        {
        }

        public RelatedEntryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RelatedEntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
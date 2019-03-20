using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public class SerializationException : Exception
    {
        public string SerializationValue { get; }
        public string SerializationPosition { get; }

        public SerializationException(string message,
            string serializationValue = null,
            string serializationPosition = null) : base(message)
        {
            SerializationValue = serializationValue;
            SerializationPosition = serializationPosition;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    [Serializable]
    public sealed class SequenceException : Exception
    {
        public SequenceException() { }
        public SequenceException(string message) : base(message) { }
        public SequenceException(string message, Exception inner) { }
    }
}

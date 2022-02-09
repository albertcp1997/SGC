using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.KNXLib.Exceptions
{
    internal class ConnectionErrorException : Exception
    {
        public ConnectionErrorException(KnxConnectionConfiguration configuration)
            : base(string.Format("ConnectionErrorException: Error connecting to {0}:{1}", configuration.Host, configuration.Port))
        {
        }

        public ConnectionErrorException(KnxConnectionConfiguration configuration, Exception innerException)
            : base(string.Format("ConnectionErrorException: Error connecting to {0}:{1}", configuration.Host, configuration.Port), innerException)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}

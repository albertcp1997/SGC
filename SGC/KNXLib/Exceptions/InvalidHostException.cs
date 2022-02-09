using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.KNXLib.Exceptions
{
    public class InvalidHostException : Exception
    {
        private readonly string _host;

        /// <summary>
        /// Initializes a new instance of the InvalidHostException class
        /// </summary>
        /// <param name="host"></param>
        public InvalidHostException(string host)
        {
            _host = host;
        }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>
        /// A string representation of the current exception.
        /// </returns>
        public override string ToString()
        {
            return string.Format("InvalidHostException: Host {0} is invalid.", _host);
        }
    }
}

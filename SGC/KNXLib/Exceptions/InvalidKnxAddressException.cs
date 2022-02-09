using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGC.KNXLib.Exceptions
{
    public class InvalidKnxAddressException : Exception
    {
        private readonly string _address;

        /// <summary>
        /// Initializes a new instance of the InvalidKnxAddressException class.
        /// </summary>
        /// <param name="address"></param>
        public InvalidKnxAddressException(string address)
        {
            _address = address;
        }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>
        /// A string representation of the current exception.
        /// </returns>
        public override string ToString()
        {
            return string.Format("InvalidKnxAddressException: Address {0} is invalid.", _address);
        }
    }
}

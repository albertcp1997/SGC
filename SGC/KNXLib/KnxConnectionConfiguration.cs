﻿using SGC.KNXLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SGC.KNXLib
{
    internal class KnxConnectionConfiguration
    {
        public KnxConnectionConfiguration(string host, int port)
        {
            Host = host;
            Port = port;

            IpAddress = null;
            try
            {
                IpAddress = IPAddress.Parse(host);
            }
            catch
            {
                try
                {
                    IpAddress = Dns.GetHostEntry(host).AddressList[0];
                }
                catch (Exception)
                {
                    throw new InvalidHostException(host);
                }
            }

            if (IpAddress == null)
                throw new InvalidHostException(host);

            EndPoint = new IPEndPoint(IpAddress, port);
        }

        public string Host { get; private set; }

        public int Port { get; private set; }

        public IPAddress IpAddress { get; private set; }

        public IPEndPoint EndPoint { get; private set; }
    }
}

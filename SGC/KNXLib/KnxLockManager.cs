﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SGC.KNXLib
{
    internal class KnxLockManager
    {
        private readonly SemaphoreSlim _sendLock = new SemaphoreSlim(0);
        private readonly object _connectedLock = new object();
        private bool _isConnected;

        internal int IntervalMs { get; set; } = 200;

        public int LockCount
        {
            get { return _sendLock.CurrentCount; }
        }

        public void LockConnection()
        {
            lock (_connectedLock)
            {
                if (!_isConnected)
                    return;

                SendLock();
                _isConnected = false;
            }
        }

        public void UnlockConnection()
        {
            lock (_connectedLock)
            {
                if (_isConnected)
                    return;

                _isConnected = true;
                SendUnlock();
            }
        }

        public void PerformLockedOperation(Action action)
        {
            // TODO: Shouldn't this check if we are connected?

            try
            {
                SendLock();
                action();
            }
            finally
            {
                SendUnlockPause();
            }
        }

        private void SendLock()
        {
            _sendLock.Wait();
        }

        private void SendUnlock()
        {
            _sendLock.Release();
        }

        private void SendUnlockPause()
        {
            if (IntervalMs == 0)
            {
                _sendLock.Release();
                return;
            }

            var t = new Thread(SendUnlockPauseThread) { IsBackground = true };
            t.Start();
        }

        private void SendUnlockPauseThread()
        {
            Thread.Sleep(IntervalMs);
            _sendLock.Release();
        }
    }
}

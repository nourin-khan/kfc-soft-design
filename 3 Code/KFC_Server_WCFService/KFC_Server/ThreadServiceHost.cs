using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Data;

namespace KFC_Server
{
    class ThreadServiceHost<TService, TContract>
    {
        #region attributes
        const int SleepTime = 100;
        private ServiceHost _serviceHost = null;
        private Thread _thread;
        private string _serviceAddress;
        private string _endpointAddress;
        private bool _running;
        private Binding _binding;
        #endregion

        public ThreadServiceHost(string serviceAddress, string endpointAddress, Binding binding)
        {
            _binding = binding;
            _serviceAddress = serviceAddress;
            _endpointAddress = endpointAddress;

            _thread = new Thread(new ThreadStart(ThreadMethod));
            _thread.Start();
        }

        public void ThreadMethod()
        {
            try
            {
                _running = true;

                // start the host
                _serviceHost = new ServiceHost(typeof(TService), new Uri(_serviceAddress));
                _serviceHost.AddServiceEndpoint(typeof(TContract), _binding, _endpointAddress);
                _serviceHost.Open();

                while (_running)
                {
                    Thread.Sleep(SleepTime);
                }

                _serviceHost.Close();
            }
            catch
            {
            	if (_serviceHost != null)
            	{
                    _serviceHost.Close();
            	}
            }
        }

        /**
         * request the end of the thread method
         */
        public void Stop()
        {
            lock (this)
            {
                _running = false;
            }
        }
    }
}

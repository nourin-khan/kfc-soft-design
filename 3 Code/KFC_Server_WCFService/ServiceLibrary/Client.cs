using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLibrary
{
    public enum ClientType { Table, Kitchen, Cashier}

    public class Client
    {
        private ClientType clientType;

        public ClientType ClientType
        {
            get { return clientType; }
            set { clientType = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}

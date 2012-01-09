using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DTO
{
    //[DataContract]
    public enum ClientType 
    { 
        //[DataMember]
        Table,
        //[DataMember]
        Kitchen,
        //[DataMember]
        Cashier
    }

    [DataContract]
    public class ClientDTO
    {
        private ClientType clientType;

        [DataMember]
        public ClientType ClientType
        {
            get { return clientType; }
            set { clientType = value; }
        }

        private string id;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}

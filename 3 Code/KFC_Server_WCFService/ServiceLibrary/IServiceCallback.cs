using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceLibrary
{
    // for duplex service
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay=true, Name="NewOrderInCallback")]
        void NewOrder();

        [OperationContract(IsOneWay = true, Name = "ConfirmOrderInCallback")]
        void ConfirmOrder();

        [OperationContract(IsOneWay = true, Name = "PaymentInCallback")]
        void Payment();
    }
}


using OM.ModelDANSTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Oldfactory
{
    [ServiceContract]
    public interface IOldfactoryService
    {
        [OperationContract]
        Tank GetTank(string name);

        [OperationContract]
        string CreateTank(Tank tank);

        [OperationContract]
        List<Tank> GetAllTanks();
    }
    
}

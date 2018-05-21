using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OM.dbDANSTE;
using OM.InterfaceDANSTE;
using OM.ModelDANSTE;

namespace Oldfactory
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class OldFactoryService : IOldfactoryService
    {
        private readonly ITankRepository _tankRepository;

        public OldFactoryService()
        {
            _tankRepository = new TankRepository();
        }

        public string CreateTank(Tank tank)
        {
            return _tankRepository.Add(tank);
        }

        public Tank GetTank(string name)
        {
            return _tankRepository.FindByName(name);
        }

        public List<Tank> GetAllTanks( )
        {
            return _tankRepository.GetAll();
        }
    }
}

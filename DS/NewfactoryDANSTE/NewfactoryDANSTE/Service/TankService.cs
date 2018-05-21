using OM.dbDANSTE;
using OM.InterfaceDANSTE;
using OM.ModelDANSTE;
using System;
using System.Collections.Generic;

namespace NewfactoryDANSTE.Services
{
    public class TankService
    {

        private ITankRepository _tankRepository;
        public TankService()
        {
            this._tankRepository = new TankRepository();
        }

        public List<Tank> GetAll()
        {
            return _tankRepository.GetAll();
        }

        public string Add(Tank book)
        {
            return _tankRepository.Add(book);
        }

        internal Tank Get(int id)
        {
            return _tankRepository.Get(id);
        }

        internal void Put(int id, Tank value)
        {
            _tankRepository.Put(id,value);
        }

        internal void Delete(int id)
        {
            _tankRepository.Delete(id);
        }
    }
}

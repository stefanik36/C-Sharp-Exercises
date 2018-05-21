using NewfactoryDANSTE.Services;
using OM.ModelDANSTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NewfactoryDANSTE.Controllers
{
    public class TankController : ApiController
    {
        private TankService _tankService;

        public TankController()
        {
            _tankService = new TankService();
        }

        // GET api/tank
        public List<Tank> Get()
        {
           // return new List<Tank>() { new Tank() { Id = 1, Power = 2, Shield = 3, ModelName = "model02" } };
            return _tankService.GetAll();
        }

        // GET api/tank/5
        public Tank Get(int id)
        {
            return _tankService.Get(id);
        }

        // POST api/tank
        public string Post([FromBody]Tank value)
        {
            return _tankService.Add(value);
        }

        // PUT api/tank/5
        public void Put(int id, [FromBody]Tank value)
        {
            _tankService.Put(id, value);
        }

        // DELETE api/tank/5
        public void Delete(int id)
        {
            _tankService.Delete(id);
        }
    }
}

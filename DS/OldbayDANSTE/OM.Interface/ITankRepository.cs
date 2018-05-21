using OM.ModelDANSTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.InterfaceDANSTE
{
    public interface ITankRepository
    {
        string Add(Tank tank);
        Tank FindByName(string name);

        List<Tank> GetAll();
        Tank Get(int id);
        bool Delete(int id);
        bool Put(int id, Tank value);
    }
}

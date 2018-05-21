using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyDANSTE.OldfactoryRefDANSTE;
namespace ArmyDANSTE
{
    class Program
    {
        static void Main(string[] args)
        {

            OldfactoryServiceClient client = new OldfactoryServiceClient();


            Tank tank = new Tank() { Power = 1, Shield = 2, ModelName = "model01" };


            Console.WriteLine("created: " + client.CreateTank(tank));

            Tank dbTank = client.GetTank("model01");


            Console.WriteLine("tank from db: ");
            Console.WriteLine("\tid: " + dbTank.Id);
            Console.WriteLine("\tpower: " + dbTank.Power);
            Console.WriteLine("\tshield: " + dbTank.Shield);
            Console.WriteLine("\tmodelName: " + dbTank.ModelName);


            Console.ReadKey();

        }
    }
}

using LiteDB;
using OM.dbDANSTE.Model;
using OM.InterfaceDANSTE;
using OM.ModelDANSTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.dbDANSTE
{
    public class TankRepository : ITankRepository
    {
        private readonly string _tankConnection = DBConnections.TankConnection;
        public string Add(Tank tank)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var dbObject = InverseMap(tank);
                var repository = db.GetCollection<TankDB>("tanks");
                if (repository.FindById(tank.Id) != null)
                    repository.Update(dbObject);
                else
                {
                    if (repository.Find(Query.EQ("ModelName", tank.ModelName)) != null)
                    {
                        repository.Insert(dbObject);
                    }
                }
                return dbObject.ModelName;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<TankDB>("tanks");
                return repository.Delete(id);
            }
        }

        public Tank FindByName(string name)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<TankDB>("tanks");
                var tank = repository.FindOne(Query.EQ("ModelName", name));

                if (tank != null)
                {
                    return Map(tank);
                }

                return null;
            }
        }

        public Tank Get(int id)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<TankDB>("tanks");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Tank> GetAll()
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<TankDB>("tanks");
                var result = repository.FindAll();

                Console.WriteLine(result.Count());

                return result.Select(m => Map(m)).ToList();
            }
        }

        public bool Put(int id, Tank value)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var dbObject = InverseMap(value);
                
                var repository = db.GetCollection<TankDB>("tanks");
                var result = repository.FindById(id);
                if (result != null)
                {
                    dbObject.Id = id;
                    return repository.Update(dbObject);
                }
                return false;

            }
        }


        private TankDB InverseMap(Tank value)
        {
            if (value == null)
                return null;
            return new TankDB()
            {
                Id = value.Id,
                Power = value.Power,
                Shield = value.Shield,
                ModelName = value.ModelName
            };
        }

        private Tank Map(TankDB db)
        {
            if (db == null)
                return null;
            return new Tank()
            {
                Id = db.Id,
                Power = db.Power,
                Shield = db.Shield,
                ModelName = db.ModelName
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Interface;
using DataAccess.Interface;
using System.Data.SqlClient;

namespace Services.Implementation
{
    public class Service<Entity> : IService<Entity>
    {
        private IDataProvider<Entity> dataProvider;

        public Service(IDataProvider<Entity> dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public Entity Add(Entity entity)
        {
                dataProvider.Repository.Add(entity);
                dataProvider.Save();
                return entity;
        }

        public IQueryable<Entity> Filter(Func<Entity, bool> query)
        {
            return dataProvider.Repository.Filter(query);
        }

        public IQueryable<Entity> Get()
        {
            return dataProvider.Repository.All;
        }

        public Entity Get(Guid id)
        {
            return dataProvider.Repository.All.First();
        }

        public void Remove(Entity entity)
        {
            dataProvider.Repository.Remove(entity);
            dataProvider.Save();
        }

        public void Update(Entity entity)
        {
            dataProvider.Repository.Update(entity);
            dataProvider.Save();
        }
    }
}

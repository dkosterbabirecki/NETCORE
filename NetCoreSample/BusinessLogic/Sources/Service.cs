using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interface;
using DataAccess.Interface;

namespace BusinessLogic.Sources
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
            dataProvider.repository.Add(entity);
            dataProvider.Save();
            return entity;
        }

        public IQueryable<Entity> Filter(Func<Entity, bool> query)
        {
            return dataProvider.repository.Filter(query);
        }

        public IEnumerable<Entity> Get()
        {
            return dataProvider.repository.All;
        }

        public Entity Get(Guid id)
        {
            return dataProvider.repository.All.First();
        }

        public void Remove(Entity entity)
        {
            dataProvider.repository.Remove(entity);
            dataProvider.Save();
        }

        public void Update(Entity entity)
        {
            dataProvider.repository.Update(entity);
            dataProvider.Save();
        }
    }
}

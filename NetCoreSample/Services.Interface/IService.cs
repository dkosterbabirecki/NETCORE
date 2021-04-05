using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services.Interface
{
    public interface IService<Entity>
    {
        Entity Add(Entity entity);
        void Remove(Entity entity);
        void Update(Entity entity);
        IQueryable<Entity> Get();
        Entity Get(Guid id);
        IQueryable<Entity> Filter(Func<Entity, bool> query);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace DataAccess
{
    public interface IRepository<Entity> 
    {
        void Add(Entity element);
        void Remove(Entity element);
        void Update(Entity element);
        Entity First(Func<Entity, bool> where);
        IQueryable<Entity> Filter(Func<Entity, bool> query, Func<Entity,bool> sort = null);
        IEnumerable<Entity> All { get; }
    }
}

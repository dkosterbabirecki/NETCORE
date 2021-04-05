using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace DataAccess.Interface
{
    public interface IRepository<Entity> 
    {
        void Add(Entity element);
        void Remove(Entity element);
        void Update(Entity element);
        Entity First(Func<Entity, bool> where);
        IQueryable<Entity> Filter(Func<Entity, bool> query);
        IQueryable<Entity> All { get; }
    }
}

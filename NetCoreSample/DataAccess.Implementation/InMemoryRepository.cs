using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Interface;

namespace DataAccess.Implementation
{
    public class InMemoryRepository<Entity> : IRepository<Entity>
    {
        private List<Entity> elements;

        public InMemoryRepository()
        {
            elements = new List<Entity>();
        }

        public void Add(Entity element)
        {
            elements.Add(element);
        }

        public IEnumerable<Entity> All => elements;

        public IQueryable<Entity> Filter(Func<Entity, bool> query)
        {
            return elements.Where(query).AsQueryable();
        }

        public Entity First(Func<Entity, bool> where)
        {
            return elements.First(where);
        }

        public void Remove(Entity element)
        {
            elements.Remove(element);
        }

        public void Update(Entity element)
        {
            elements.Remove(element);
            elements.Add(element);
        }
    }
}

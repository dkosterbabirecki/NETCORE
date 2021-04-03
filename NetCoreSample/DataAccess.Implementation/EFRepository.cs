using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interface;


namespace DataAccess.Implementation
{
    public class EFRepository<Entity> : IRepository<Entity> where Entity: class
    {
        private DbContext context;
        DbSet<Entity> records;

        public EFRepository(DbContext context)
        {
            this.context = context;
            records = context.Set<Entity>();
        }
        public IEnumerable<Entity> All => records;

        public void Add(Entity element)
        {
            records.Add(element);
        }

        public IQueryable<Entity> Filter(Func<Entity, bool> query)
        {
            return records.Where(query).AsQueryable();
        }

        public Entity First(Func<Entity, bool> where)
        {
            return records.First(where);
        }

        public void Remove(Entity element)
        {
            records.Remove(element);
        }

        public void Update(Entity element)
        {
            records.Update(element);
        }
    }
}

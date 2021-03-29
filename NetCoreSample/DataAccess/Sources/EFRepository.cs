﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
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

        public IQueryable<Entity> Filter(Func<Entity, bool> query, Func<Entity, bool> sort = null)
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
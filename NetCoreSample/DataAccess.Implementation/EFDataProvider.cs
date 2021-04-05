using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class EFDataProvider<Entity> : IDataProvider<Entity> where Entity : class
    {
        public IRepository<Entity> Repository => repository;
        private DbContext context;
        private IRepository<Entity> repository;
        public EFDataProvider(DbContext context, IRepository<Entity> repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

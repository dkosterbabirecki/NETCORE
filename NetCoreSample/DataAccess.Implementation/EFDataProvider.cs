using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class EFDataProvider<Entity> : IDataProvider<Entity> where Entity : class
    {
        public IRepository<Entity> repository => new EFRepository<Entity>(context);
        private DbContext context;

        public EFDataProvider(DbContext context)
        {
            this.context = context;
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

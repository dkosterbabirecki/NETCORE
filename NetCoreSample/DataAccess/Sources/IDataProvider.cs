using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataProvider<Entity> : IDisposable
    {
        IRepository<Entity> repository { get; }
        void Save();
    }
}

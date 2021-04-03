using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IDataProvider<Entity> : IDisposable
    {
        IRepository<Entity> repository { get; }
        void Save();
    }
}

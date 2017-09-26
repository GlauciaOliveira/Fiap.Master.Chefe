using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public interface IUnitOfWork<T> where T : class
    {
        void Save(T model);
        void Update(T model);
        void Delete(T model);
        IEnumerable<T> GetAll();
        T GetById(object id);
    }
}

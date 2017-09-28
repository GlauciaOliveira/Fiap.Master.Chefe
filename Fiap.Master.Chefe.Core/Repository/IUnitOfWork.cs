using Fiap.Master.Chefe.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}

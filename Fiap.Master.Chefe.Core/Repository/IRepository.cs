using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public interface IRepository<T>
    {
        void Incluir(T entity);
        void Remover(int id);
        void Atualizar(T entity);
        ICollection<T> Listar();
        T Buscar(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public interface IRepository<T> 
    {
        ICollection<T> Listar();
        T ListarPorId(int id);
        void Incluir(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
        void ExcluirPorId(int id);
    }
}

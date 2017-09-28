using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
   public class ReceitaIngredientesRepository : IRepository<Model.ReceitaIngredientes>, IDisposable
    {
        private MasterChefeContext _context = null;

        public ReceitaIngredientesRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(ReceitaIngredientes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(ReceitaIngredientes entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ReceitaIngredientes entity)
        {
            _context.ReceitaIngredientes.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<ReceitaIngredientes> Listar()
        {
            var result = _context.ReceitaIngredientes.ToArray();
            return result;
        }

        public ReceitaIngredientes ListarPorId(int id)
        {
            var result = _context.ReceitaIngredientes.Find(id);
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (null != _context)
                    _context.Dispose();

                _context = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
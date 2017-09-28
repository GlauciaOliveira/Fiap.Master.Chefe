using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class IngredientesRepository : IRepository<Model.Ingredientes>, IDisposable
    {
        private MasterChefeContext _context = null;

        public IngredientesRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Ingredientes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Ingredientes entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Ingredientes entity)
        {
            _context.Ingrediente.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Ingredientes> Listar()
        {
            var result = _context.Ingrediente.ToList();
            return result;
        }

        public Ingredientes ListarPorId(int id)
        {
            var result = _context.Ingrediente.Find(id);
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

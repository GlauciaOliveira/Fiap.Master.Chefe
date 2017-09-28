using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class CategoriasRepository : IRepository<Model.Categorias>, IDisposable
    {
        private MasterChefeContext _context = null;

        public CategoriasRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Categorias entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Categorias entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Categorias entity)
        {
            _context.Categoria.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Categorias> Listar()
        {
            var result = _context.Categoria.ToList();
            return result;
        }

        public Categorias ListarPorId(int id)
        {
            var result = _context.Categoria.Find(id);
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
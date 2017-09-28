using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class ComentariosRepository : IRepository<Model.Comentarios>, IDisposable
    {
        private MasterChefeContext _context = null;

        public ComentariosRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Comentarios entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Comentarios entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Comentarios entity)
        {
            _context.Comentario.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Comentarios> Listar()
        {
            var result = _context.Comentario.ToList();
            return result;
        }

        public Comentarios ListarPorId(int id)
        {
            var result = _context.Comentario.Find(id);
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
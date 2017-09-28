using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class UsuariosRepository : IRepository<Model.Usuarios>, IDisposable
    {
        private MasterChefeContext _context = null;

        public UsuariosRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Usuarios entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Usuarios entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Usuarios entity)
        {
            _context.Usuario.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Usuarios> Listar()
        {
            var result = _context.Usuario.ToList();
            return result;
        }

        public Usuarios ListarPorId(int id)
        {
            var result = _context.Usuario.Find(id);
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
using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class ReceitasRepository:IRepository<Model.Receitas>, IDisposable
    {
        private MasterChefeContext _context = null;

        public ReceitasRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Receitas entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Receitas entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Receitas entity)
        {
            _context.Receita.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Receitas> Listar()
        {
            var result = _context.Receita.ToList();
            return result;
        }

        public Receitas ListarPorId(int id)
        {
            var result = _context.Receita.Find(id);
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
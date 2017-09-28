using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class ReceitaPontuacaoRepository : IRepository<Model.ReceitaPontuacao>, IDisposable
    {
        private MasterChefeContext _context = null;

        public ReceitaPontuacaoRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(ReceitaPontuacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(ReceitaPontuacao entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ReceitaPontuacao entity)
        {
            _context.ReceitaPontuacao.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<ReceitaPontuacao> Listar()
        {
            var result = _context.ReceitaPontuacao.ToList();
            return result;
        }

        public ReceitaPontuacao ListarPorId(int id)
        {
            var result = _context.ReceitaPontuacao.Find(id);
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
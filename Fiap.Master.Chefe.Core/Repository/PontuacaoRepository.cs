using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class PontuacaoRepository : IRepository<Model.Pontuacao>, IDisposable
    {
        private MasterChefeContext _context = null;

        public PontuacaoRepository(MasterChefeContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Pontuacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Pontuacao entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pontuacao entity)
        {
            _context.Pontuacao.Add(entity);
            _context.SaveChanges();
        }

        public ICollection<Pontuacao> Listar()
        {
            var result = _context.Pontuacao.ToList();
            return result;
        }

        public Pontuacao ListarPorId(int id)
        {
            var result = _context.Pontuacao.Find(id);
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
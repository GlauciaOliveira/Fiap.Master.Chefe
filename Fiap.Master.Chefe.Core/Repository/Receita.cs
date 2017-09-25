using System;
using System.Collections.Generic;
using System.Text;
using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class Receita :IRepository<Model.Receita>, IDisposable
    {
        public MasterChefeContext db = null;

        public Receita(MasterChefeContext context)
        {
            db = context;
        }

        public void Atualizar(Model.Receita entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Model.Receita Buscar(int id)
        {
            var result = db.Receita.Find(id);
            return result;
        }

        public void Incluir(Model.Receita entity)
        {
            db.Receita.Add(entity);
            db.SaveChanges();
        }

        public ICollection<Model.Receita> Listar()
        {
            var result = db.Receita.ToList();
            return result;
        }

        public void Remover(int id)
        {
            var entity = db.Receita.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (null != db)
                    db.Dispose();

                db = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

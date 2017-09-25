using System;
using System.Collections.Generic;
using System.Text;
using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class Ingrediente: IRepository<Model.Ingrediente>, IDisposable
    {
        public MasterChefeContext db = null;

        public Ingrediente(MasterChefeContext context)
        {
            db = context;
        }

        public void Incluir(Model.Ingrediente entity)
        {
            db.Ingrediente.Add(entity);
            db.SaveChanges();
        }

        public void Remover(int id)
        {
            var entity = db.Ingrediente.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Atualizar(Model.Ingrediente entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public ICollection<Model.Ingrediente> Listar()
        {
            var result = db.Ingrediente.ToList();
            return result;
        }

        public Model.Ingrediente Buscar(int id)
        {
            var result = db.Ingrediente.Find(id);
            return result;
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

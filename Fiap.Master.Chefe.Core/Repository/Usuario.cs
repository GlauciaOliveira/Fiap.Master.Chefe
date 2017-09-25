using System;
using System.Collections.Generic;
using System.Text;
using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class Usuario : IRepository<Model.Usuario>, IDisposable
    {
        public MasterChefeContext db = null;

        public Usuario(MasterChefeContext context)
        {
            db = context;
        }

        public void Atualizar(Model.Usuario entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Model.Usuario Buscar(int id)
        {
            var result = db.Usuario.Find(id);
            return result;
        }

        public void Incluir(Model.Usuario entity)
        {
            db.Usuario.Add(entity);
            db.SaveChanges();
        }

        public ICollection<Model.Usuario> Listar()
        {
            var result = db.Usuario.ToList();
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

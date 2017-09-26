using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class BaseContext<T> : MasterChefeContext where T : class
    {
        public DbSet<T> DbSet
        {
            get;
            set;
        }

        public virtual int Save(T model)
        {
            this.DbSet.Add(model);
            return this.SaveChanges();
        }

        public virtual int Update(T model)
        {
            var entry = this.Entry(model);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.Entry(model).State = EntityState.Modified;
            return this.SaveChanges();
        }

        public virtual void Delete(T model)
        {
            var entry = this.Entry(model);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(model);

            this.Entry(model).State = EntityState.Deleted;
            this.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }


    }

    public class IngredientesRepository : BaseContext<Model.Ingrediente>, IUnitOfWork<Model.Ingrediente>
    {
        void IUnitOfWork<Model.Ingrediente>.Save(Model.Ingrediente model)
        {
            //throw new NotImplementedException();
        }

        void IUnitOfWork<Model.Ingrediente>.Update(Model.Ingrediente model)
        {
            //throw new NotImplementedException();
        }
    }

    public class ReceitasRepository : BaseContext<Model.Receita>, IUnitOfWork<Model.Receita>
    {
        void IUnitOfWork<Model.Receita>.Save(Model.Receita model)
        {
            //throw new NotImplementedException();
        }

        void IUnitOfWork<Model.Receita>.Update(Model.Receita model)
        {
            //throw new NotImplementedException();
        }
    }
}

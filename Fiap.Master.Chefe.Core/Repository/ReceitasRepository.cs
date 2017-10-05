using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Fiap.Master.Chefe.Core.Repository
{
    public class ReceitasRepository : IRepository<Model.Receitas>, IDisposable
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

        public Receitas IncluirComposto(Receitas entity, List<IngredientesModelView> listIngredientes)
        {
            _context.Receita.Add(entity);
            _context.SaveChanges();

            //foreach (var item in listIngredientes)
            //{
            //    _context.ReceitaIngredientes.Add(
            //        new ReceitaIngredientes()
            //        {
            //            ReceitasId = entity.ReceitasId,
            //            IngredientesId = item.IngredientesId,
            //            Quantidade = item.Quantidade,
            //            Unidade = item.Unidade
            //        }
            //    );
            //    _context.SaveChanges();
            //}

            return entity;
        }

        public ICollection<Receitas> Listar()
        {
            var result = _context.Receita.ToList();
            return result;
        }

        public ICollection<ReceitasModelView> ListarReceitasModel()
        {
            var result = _context.Receita
                .Include(d => d.ReceitaIngredientes)
                //.Include(u => u.Usuario)
                //.Include(u => u.Comentarios)
                //.Include(r => r.ReceitaPontuacao)
                .Select(x => new ReceitasModelView()
                {
                    ReceitasId = x.ReceitasId,
                    Titulo = x.Titulo,
                    DataCadastro = x.DataCadastro,
                    Categoria = x.Categoria,
                    ModoPreparo = x.ModoPreparo,
                    Usuario = x.Usuario,
                    Comentarios = x.Comentarios,
                    PontuacaoMedia = Math.Round(x.ReceitaPontuacao.Average(p => p.Nota))
                }
                )
                .ToList();

            if (result != null)
            {
                List<IngredientesModelView> listaIngredientes = new List<IngredientesModelView>();

                foreach (var item in result)
                {
                    //Relaciona Ingredientes
                    var ingredienteRelacionado = _context.ReceitaIngredientes
                                                         .Join(_context.Ingrediente,
                                                                i => i.IngredientesId, 
                                                                x => x.IngredientesId,
                                                                (i, x)=>  new { Ingredientes = i}).Select(s => s.Ingredientes)
                                                         .Where(x => x.ReceitasId == item.ReceitasId)
                                                         .Select(x => new IngredientesModelView()
                                                             {
                                                                 Quantidade = x.Quantidade,
                                                                 IngredientesId = x.IngredientesId,
                                                                 Unidade = x.Unidade,
                                                                 NomeIngrediente = x.Ingrediente.Nome
                                                             }
                                                         )
                                                         .ToList();
                    item.IngredientesModelView = ingredienteRelacionado;
                }
            }
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
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

        public void AtualizarReceitaModel(ReceitasModelView entity)
        {
            List<ReceitaIngredientes> lista = new List<ReceitaIngredientes>();
            int receitaId = entity.ReceitasId;

            foreach (var item in entity.IngredientesModelView)
            {
                lista.Add(new ReceitaIngredientes()
                {
                    ReceitasId = receitaId,
                    IngredientesId = item.IngredientesId,
                    Unidade = item.Unidade,
                    Quantidade = item.Quantidade
                });
            }

            var receita = new Receitas()
            {
                ReceitasId = entity.ReceitasId,
                CategoriasId = entity.Categoria.CategoriasId,
                DataCadastro = entity.DataCadastro,
                ModoPreparo = entity.ModoPreparo,
                Titulo = entity.Titulo,
                UsuariosId = entity.Usuario.UsuariosId
            };

            _context.Entry(receita).State = EntityState.Modified;

            var allRegisters = _context.ReceitaIngredientes.Where(x => x.ReceitasId == entity.ReceitasId).ToList();       

            _context.ReceitaIngredientes.RemoveRange(allRegisters);
            _context.SaveChanges();

            _context.ReceitaIngredientes.AddRangeAsync(lista);
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

        public void IncluirReceitasModel(ReceitasModelView entity)
        {
            List<ReceitaIngredientes> lista = new List<ReceitaIngredientes>();
            int receitaId = entity.ReceitasId;

            foreach (var item in entity.IngredientesModelView)
            {
                lista.Add(new ReceitaIngredientes()
                {
                    ReceitasId = receitaId,
                    IngredientesId = item.IngredientesId,
                    Unidade = item.Unidade,
                    Quantidade = item.Quantidade
                });                
            }

            var receita = new Receitas()
            {
                CategoriasId = entity.Categoria.CategoriasId,
                DataCadastro = entity.DataCadastro,
                ModoPreparo = entity.ModoPreparo,
                Titulo = entity.Titulo,
                UsuariosId = entity.Usuario.UsuariosId,
                ReceitaIngredientes = lista
            };

            _context.Receita.Add(receita);
            _context.SaveChanges();
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
                .Include(u => u.Usuario)
                .Include(r => r.ReceitaPontuacao)
                .Select(x => new ReceitasModelView()
                {
                    ReceitasId = x.ReceitasId,
                    Titulo = x.Titulo,
                    DataCadastro = x.DataCadastro,
                    Categoria = x.Categoria,
                    ModoPreparo = x.ModoPreparo,
                    Usuario = x.Usuario,
                    PontuacaoMedia = Math.Round(x.ReceitaPontuacao.Average(p => p.Nota))
                }
                )
                .ToList();

            if (result != null)
            {
                List<IngredientesModelView> listaIngredientes = new List<IngredientesModelView>();

                foreach (var item in result)
                {
                    //Relaciona Comentários

                    var comentarios = _context.Comentario.Where(c => c.ReceitasId == item.ReceitasId).ToList();
                    item.Comentarios = comentarios;

                    //Relaciona Ingredientes
                    var ingredienteRelacionado = _context.ReceitaIngredientes
                                                         .Join(_context.Ingrediente,
                                                                i => i.IngredientesId,
                                                                x => x.IngredientesId,
                                                                (i, x) => new { Ingredientes = i }).Select(s => s.Ingredientes)
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

        public ReceitasModelView ListarReceitaModelPorId(int id)
        {

            var result = _context.Receita
                .Include(d => d.ReceitaIngredientes)
                .Include(u => u.Usuario)
                .Include(r => r.ReceitaPontuacao)
                .Select(x => new ReceitasModelView()
                {
                    ReceitasId = x.ReceitasId,
                    Titulo = x.Titulo,
                    DataCadastro = x.DataCadastro,
                    Categoria = x.Categoria,
                    ModoPreparo = x.ModoPreparo,
                    Usuario = x.Usuario//,
                    //PontuacaoMedia = Math.Round(x.ReceitaPontuacao.Average(p => p.Nota))
                }
                )
                .Where(x => x.ReceitasId == id)
                .SingleOrDefault();

            if (result != null)
            {
                List<IngredientesModelView> listaIngredientes = new List<IngredientesModelView>();


                //Relaciona Comentários

                var comentarios = _context.Comentario.Where(c => c.ReceitasId == result.ReceitasId).ToList();
                result.Comentarios = comentarios;

                //Relaciona Ingredientes
                var ingredienteRelacionado = _context.ReceitaIngredientes
                                                     .Join(_context.Ingrediente,
                                                            i => i.IngredientesId,
                                                            x => x.IngredientesId,
                                                            (i, x) => new { Ingredientes = i }).Select(s => s.Ingredientes)
                                                     .Where(x => x.ReceitasId == result.ReceitasId)
                                                     .Select(x => new IngredientesModelView()
                                                     {
                                                         Quantidade = x.Quantidade,
                                                         IngredientesId = x.IngredientesId,
                                                         Unidade = x.Unidade,
                                                         NomeIngrediente = x.Ingrediente.Nome
                                                     }
                                                     )
                                                     .ToList();
                result.IngredientesModelView = ingredienteRelacionado;

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
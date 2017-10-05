using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Master.Chefe.Core.Repository;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Receitas")]
    public class ReceitasController : Controller
    {
        ReceitasRepository _contexto = new ReceitasRepository(new MasterChefeContext());

        // GET: api/Receitas
        [HttpGet]
        public IActionResult Get()
        {
            var result = _contexto.ListarReceitasModel();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _contexto.ListarReceitaModelPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Receitas
        [HttpPost]
        public IActionResult Post([FromBody]ReceitasModelView entity)
        {
            try
            {
                _contexto.IncluirReceitasModel(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ReceitasModelView entity)
        {
            try
            {
                _contexto.AtualizarReceitaModel(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entidade = _contexto.ListarPorId(id);
                _contexto.Excluir(entidade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

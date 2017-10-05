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
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        UsuariosRepository _contexto = new UsuariosRepository(new MasterChefeContext());
        // GET: api/Usuarios
        [HttpGet]
        public IActionResult Get()
        {
            var result = _contexto.Listar();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Autentication(string user, string senha)
        {
            var result = _contexto.Autorization(user, senha);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _contexto.ListarPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        // POST: api/Usuarios
        [HttpPost]
        public IActionResult Post([FromBody]Usuarios entity)
        {
            try
            {
                _contexto.Incluir(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Usuarios entity)
        {
            try
            {
                _contexto.Atualizar(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
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

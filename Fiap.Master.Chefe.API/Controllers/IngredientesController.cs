using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiap.Master.Chefe.Core.Model;
using Fiap.Master.Chefe.Core.Repository;

namespace Fiap.Master.Chefe.API.Controllers
{
    [Produces("application/json")]
    //[Route("api/Ingredientes")]
    [Route("api/[controller]")]
    public class IngredientesController : Controller
    {
        //private readonly MasterChefeContext _context;
        readonly IRepository<Core.Model.Ingrediente> _repository = null;

        public IngredientesController(Core.Repository.IRepository<Core.Model.Ingrediente> repository)
        {
            _repository = repository;
            //_context = context;
        }

        // GET: api/Ingredientes
        [HttpGet]
        public IEnumerable<Core.Model.Ingrediente> GetIngrediente()
        {
            return _repository.Listar(); //_context.Ingrediente;
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public IActionResult GetIngrediente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingrediente = _repository.Buscar(id); 

            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        // PUT: api/Ingredientes/5
        [HttpPut("{id}")]
        public IActionResult PutIngrediente([FromRoute] int id, [FromBody] Core.Model.Ingrediente ingrediente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingrediente.IngredienteId)
            {
                return BadRequest();
            }
            
            try
            {
                _repository.Atualizar(ingrediente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Ingredientes
        [HttpPost]
        public IActionResult PostIngrediente([FromBody] Core.Model.Ingrediente ingrediente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Incluir(ingrediente);

            return CreatedAtAction("GetIngrediente", new { id = ingrediente.IngredienteId }, ingrediente);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIngrediente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Remover(id);

            return Ok();
        }
    }
}
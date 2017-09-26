using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Master.Chefe.Core.Repository;

namespace Fiap.Master.Chefe.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Ingredientes")]
    public class IngredientesController : Controller
    {
        IUnitOfWork<Core.Model.Ingrediente> _unitOfWorkIngredientes { get; set; }

        public IngredientesController()
        {
            this._unitOfWorkIngredientes = new IngredientesRepository();
        }

        // GET: api/Ingredientes
        [HttpGet]
        public IEnumerable<Core.Model.Ingrediente> Get()
        {
            var result = _unitOfWorkIngredientes.GetAll();
            return result;
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ingredientes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ingredientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

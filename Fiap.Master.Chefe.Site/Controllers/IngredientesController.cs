using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Fiap.Master.Chefe.Core.Model;
using System.Text;

namespace Fiap.Master.Chefe.Site.Controllers
{
    [Produces("application/json")]
    [Route("api/Ingredientes")]
    public class IngredientesController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string apiUrl = "http://localhost:8110/api/Ingredientes";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View();

        }
        // GET: api/Ingredientes
        //[HttpGet]
        //public async Task<ActionResult> Index()
        //{
        //    string apiUrl = "http://localhost:8110/api/Ingredientes";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(apiUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync(apiUrl);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await response.Content.ReadAsStringAsync();
        //            var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

        //        }


        //    }
        //    return View();

        //}



        // GET: api/Ingredientes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            string apiUrl = "http://localhost:8110/api/Ingredientes";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View();

        }


        // POST: api/Ingredientes
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Ingredientes entity)
        {
            string apiUrl = "http://localhost:8110/api/Ingredienstes";

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(entity.ToString(), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(apiUrl, content);
                
                return View(result);
            }
        }

        // PUT: api/Ingredientes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Ingredientes entity)
        {
            string apiUrl = "http://localhost:8110/api/Ingredienstes";

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(entity.ToString(), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(apiUrl, content);

                return View(result);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(int id)
        {
            string apiUrl = "http://localhost:8110/api/Ingredientes";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View();
        }

    }
}

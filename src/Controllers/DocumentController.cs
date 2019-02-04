using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace todoProject.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class DocumentController : Controller
    {
        public static List<Document> Documents = new List<Document>{
            new Document{Title = "Getting things done", Number = 123},
            new Document{Title = "Flawless consulting", Number = 321} };


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize]
        // GET: api/Document
        [HttpGet]
        public IEnumerable<Document> Get()
        {
            return Documents;
        }

        // GET: api/Document/5
        [HttpGet("{id}", Name = "Get")]
        public Document Get(int id)
        {
            return Documents.FirstOrDefault(d => d.Number == id);
        }
        
        // POST: api/Document
        [HttpPost]
        public void Post([FromBody]Document document)
        {
            if (document == null)
            {
                throw new Exception();
            }

            Documents.Add(document);
        }
        
        // PUT: api/Document/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var document = Documents.First(d => d.Number == id);
            Documents.Remove(document);
        }
    }

        

    public class Document
    {
        public string Title;
        public int Number;
    }
}

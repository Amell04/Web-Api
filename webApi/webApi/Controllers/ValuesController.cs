using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApi.Models;

namespace webApi.Controllers
{
    public class ValuesController : ApiController
    {
        Modelo db = new Modelo();
        // GET api/values
        public IEnumerable<Docentes> Get()

        {
            //return Json(new { valores = db.Docentes.ToArray() });
           return db.Docentes.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Docentes Get(int id)//busqueda
        {
            return db.Docentes.FirstOrDefault(e=>e.Iddocente==id);
        }
        
         // POST api/values //insercion 
        public HttpResponseMessage Post([FromBody]Docentes value)
        {
            try
            {
                db.Docentes.Add(value);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,1);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,0);

            }
            
        }
         
         
        // POST api/values //insercion 
        //public void Post([FromBody]Docentes value)
        //{
        //    db.Docentes.Add(value);
        //    db.SaveChanges();
        //}



        // Acutualizar o ModificarPUT api/values/5
        public void Put(int id, [FromBody]Docentes value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            db.Docentes.Remove(db.Docentes.FirstOrDefault(e=> e.Iddocente==id));
            db.SaveChanges();
        }
    }
}

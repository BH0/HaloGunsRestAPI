using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

using HaloGuns.Models; 

namespace HaloGuns.Controllers
{
    public class GunController : ApiController
    { 
        // GET: api/Gun 
        public ArrayList Get()
        {
            GunPersistence gunPersistence = new GunPersistence();
            return gunPersistence.getGuns(); 
        } 

        // GET: api/Gun/1
        public Gun Get(long ID)
        {
            GunPersistence gunPersistence = new GunPersistence();
            Gun gun = gunPersistence.getGun(ID); 
            return gun;
        } 

        // POST: api/Gun
        public HttpResponseMessage Post([FromBody]Gun newGun)
        {
            GunPersistence gunPersistence = new GunPersistence();
            long ID;
            ID = gunPersistence.saveGun(newGun);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("gun/{0}", ID)); 
            return response; 
        }

        // PUT: api/Gun/5 
        public HttpResponseMessage Put(long ID, [FromBody]Gun gunToBeUpdated)
        {
            GunPersistence gunPersistence = new GunPersistence();
            HttpResponseMessage response;
            bool recordExisted = false;
            recordExisted = gunPersistence.updateGun(ID, gunToBeUpdated);
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        // DELETE: api/Gun/5
        public HttpResponseMessage Delete(long ID)
        {
            GunPersistence gunPeristence = new GunPersistence();
            bool recordExisted = false;
            recordExisted = gunPeristence.deleteGun(ID);
            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
    }
}

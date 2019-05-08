using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiCall.Models;

namespace WebApiCall.Controllers
{
    [EnableCors("*", "*", "*")]
    public class studentController : ApiController
    {
        //create an object of database
        dbModel db = new dbModel();

        ///api/student/
        public List<infoMaster> GetInfos()
        {
            return db.infoMasters.ToList();
        }

        ///api/student/1
        [ResponseType(typeof(infoMaster))]
        public IHttpActionResult GetInfos(int id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            else
            {
                var data = db.infoMasters.Find(id);
                if(data == null)
                {
                    //return NotFound();
                    return BadRequest("your id is not a found!");

                }

                return Ok(data);
            }
        }

        [ResponseType(typeof(string))]
        public IHttpActionResult PostInfos(infoMaster info)
        {
            try
            {
                db.infoMasters.Add(info);
                db.SaveChanges();
                return Ok("Your data is inserted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

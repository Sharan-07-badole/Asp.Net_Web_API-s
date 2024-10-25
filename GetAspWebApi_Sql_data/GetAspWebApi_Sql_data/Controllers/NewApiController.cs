using GetAspWebApi_Sql_data.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetAspWebApi_Sql_data.Controllers
{
    // creating the asp.net web api using database first approach in mvc 
    public class NewApiController : ApiController
    {
        // first created db and cdone with entity framework so, we get databsedb context as db and student as table
        // creating db obj to use data from that database
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();

        //This is must while getting data from we have to write httpget in below format
        [System.Web.Http.HttpGet]

        // IHttpActionResult we must have to mention as return type of the method 
        public IHttpActionResult Index()
        {
            // creating list datatype variable obj which returns list of student  
            List<Student> obj = db.Students.ToList();

            // So as we know api returns data not view so to return data from db to set in api we have to use Ok method
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetbyId(int id)
        {
            var obj = db.Students.Where(model => model.Id==id).FirstOrDefault();
            return Ok(obj);
        }
        
    }
}

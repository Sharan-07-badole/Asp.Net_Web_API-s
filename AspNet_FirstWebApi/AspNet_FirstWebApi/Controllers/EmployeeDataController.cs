using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNet_FirstWebApi.Controllers
{
    public class EmployeeDataController : ApiController
    {
        string[] myemployees = { "Ram", "Sham", "Jay" };

        // It's optional either if we not declare this automatically controller treats as get method
        // we have to use route template as api/EmployeeData
        [HttpGet]
        public string[] GetEmployees()
        {
            return myemployees;
        }
        // We must pass parameter name as id, as shown in app start page web api config class contains
        // even though if we can't write here httpget it will treat as get itself..
        // this method return data in xml by default ( we can also get this data in json we see that while consuming this api)
        // we have to use route template as api/EmployeeData/1 (any id acc to us)
        
		public string GetEmployeeByIndex(int id)
        {
            return myemployees[id];
        }

    }
}

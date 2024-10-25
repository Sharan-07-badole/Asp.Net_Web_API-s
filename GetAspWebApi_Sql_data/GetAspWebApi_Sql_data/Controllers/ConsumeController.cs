using GetAspWebApi_Sql_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GetAspWebApi_Sql_data.Controllers
{
    // Here we created new controller where we are going to consume the data from web api
    public class ConsumeController : Controller
    {
        // GET: Consume
        // create object of class httpclient so by using that boject we can getch the data from web api 
        // which we already build in the NewApiCOntroller and we just consuming the web api data in MVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            // create obj for list of students where we are putting the list of students details in this variable
            List<Student> list = new List<Student>();

            // First we have to go to the base address of the web api
            client.BaseAddress = new Uri("https://localhost:44374/api/NewApi");

            // Now putting the data into var variable by passing the controller name in getasync method
            var response = client.GetAsync("NewApi");

            // we have to wait if we use async method
            response.Wait();

            // testing the data 
            var test = response.Result;

            // appling the success condition for testing
            if (test.IsSuccessStatusCode)
            {
				// now put that tested data to convert  into list
				var display = test.Content.ReadAsAsync<List<Student>>();
                display.Wait();
                // now put that converted data put list variable after waiting 
                list = display.Result;
            }
            // pass the data to the view
            return View(list);
            // now create the view to show the list of data into table format by selecting list and
            // also select db context and table 
        }
    }
}
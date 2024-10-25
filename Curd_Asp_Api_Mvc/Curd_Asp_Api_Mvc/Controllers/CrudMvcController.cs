using Curd_Asp_Api_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Curd_Asp_Api_Mvc.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            // creating object for storing the list of data 
            List<Employee> emp_list = new List<Employee>();
            
            // hitting for base address
            client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");

            // passing controller name which we get some response
            var response = client.GetAsync("CrudApi");

            // wait for some time
            response.Wait();

            // storing that response in test variable
            var test = response.Result;

            // checks that test has get data or not 
            if (test.IsSuccessStatusCode)
            {
                // reading that test variable data in to list of employee list and store in display variable 
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();

                // now put that data into list of employee list which we already created the obj for that at beginning
                emp_list = display.Result;
            }
            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Create(Employee emp)
		{
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");

			// passing controller name with e data which comes from post create method
			// and we are using postmethod which we get some response
			var response = client.PostAsJsonAsync<Employee>("CrudApi", emp);

			// wait for some time
			response.Wait();

			// storing that response in test variable
			var test = response.Result;

			// checks that test has get data or not 
			if (test.IsSuccessStatusCode)
			{
				// directly add the data into post web api 
				return RedirectToAction("Index");
			}
			return View("Create");
		}
		

		public ActionResult Details(int id)
		{
			Employee e = null;
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");
			var response = client.GetAsync("CrudApi?id="+id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<Employee>();
				display.Wait();
				e = display.Result;
			}
			return View(e);
		}

		public ActionResult Edit(int id)
		{
			Employee e = null;
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");
			var response = client.GetAsync("CrudApi?id=" + id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<Employee>();
				display.Wait();
				e = display.Result;
			}
			return View(e);
		}

		[HttpPost]
		public ActionResult Edit(Employee e)
		{ 
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");
			var response = client.PutAsJsonAsync<Employee>("CrudApi", e);
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View("Edit");
		}

		public ActionResult Delete(int id)
		{
			Employee e = null;
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");
			var response = client.GetAsync("CrudApi?id=" + id.ToString());
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				var display = test.Content.ReadAsAsync<Employee>();
				display.Wait();
				e = display.Result;
			}
			return View(e);
		}

		// This line shows that the confirmeddelete page is work when we click on delete button in delete view
		[HttpPost,ActionName("Delete") ]

		// We are passing the id to take this id and change in delete web api
		public ActionResult ConfirmedDelete(int id)
		{
			client.BaseAddress = new Uri("https://localhost:44332/api/CrudApi");
			var response = client.DeleteAsync("CrudApi/"+ id.ToString() );
			response.Wait();
			var test = response.Result;

			if (test.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View("Delete");
		}
	}

}
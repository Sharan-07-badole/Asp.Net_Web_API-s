using Curd_Asp_Api_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Curd_Asp_Api_Mvc.Controllers
{
    public class CrudApiController : ApiController
    {
		Crud_Api_Mvc_DbEntities db = new Crud_Api_Mvc_DbEntities();

		[System.Web.Http.HttpGet]
		public IHttpActionResult Index()
		{
			List<Employee> emp_list = db.Employees.ToList();
			return Ok(emp_list);
		}

		[System.Web.Http.HttpPost]
		public IHttpActionResult EmpInsert(Employee emp)
		{
			db.Employees.Add(emp);
			db.SaveChanges();
			return Ok();
		}

		[System.Web.Http.HttpGet]
		public IHttpActionResult ShowEmpById(int Id)
		{
			var row = db.Employees.Where(model => model.Id == Id).FirstOrDefault();
			return Ok(row);
		}

		[System.Web.Http.HttpPut]
		public IHttpActionResult EmpUpdate(Employee e)
		{
			db.Entry(e).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();

			// We can write the below code instead of this above one line code
			
			//var emp = db.Employees.Where(model => model.Id == e.Id).FirstOrDefault();
			//if (emp != null)
			//{
			//	emp.Id = e.Id;
			//	emp.Name = e.Name;
			//	emp.Gender = e.Gender;
			//	emp.Age = e.Age;
			//	emp.Designation = e.Designation;
			//	emp.Salary = e.Salary;
			//	db.SaveChanges();
			//}
			//else
			//{
			//	return NotFound();
			//}
			return Ok();
		}

		[System.Web.Http.HttpDelete]
		public IHttpActionResult DeleteEmpById(int Id)
		{
			var row = db.Employees.Where(model => model.Id == Id).FirstOrDefault();
			db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return Ok();
		}
	}
}

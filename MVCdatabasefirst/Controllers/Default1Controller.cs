using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCdatabasefirst.Models;

namespace MVCdatabasefirst.Controllers
{
	public class Default1Controller : Controller
	{
		// GET: Default1
		public ActionResult Index()
		{
			using (var l = new EmployeeDBEntities())
			{
				IList<EmployeeDetails> employees = l.EmployeeDetails.ToList();
				return View(employees);
			}
		}
	}
}
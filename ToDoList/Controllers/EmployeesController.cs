using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
  public class EmployeesController : Controller
  {
    [HttpGet("/employees")]
    public ActionResult Index()
    {
      List<Employee> allEmployees = Employee.GetAll();
      return View(allEmployees);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}
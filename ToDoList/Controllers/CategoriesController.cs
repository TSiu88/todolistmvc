using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName, string description)
    {
      Category newCategory = new Category(categoryName, description);
      newCategory.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = Item.FindForCategory(id);
      model.Add("category", selectedCategory);
      model.Add("items", categoryItems);
      return View(model);
    }

    // This one creates new Items within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create(int categoryId, string itemTitle, string itemDescription, DateTime due)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item(itemTitle, itemDescription, due, categoryId);
      newItem.Save();    // New code
      List<Item> categoryItems = Item.FindForCategory(categoryId);
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
  }
}
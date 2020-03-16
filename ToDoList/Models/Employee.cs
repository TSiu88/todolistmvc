using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public enum Developer
  {
    FrontEnd,
    BackEnd,
    FullStack
  }
  public class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Developer Developer { get; set; }

    public Employee(string name, Developer developer)
    {
      Name = name;
      Developer = developer;
    }

    public Employee(int employeeId, string name, Developer developer)
    {
      Id = employeeId;
      Name = name;
      Developer = developer;
    }

    public static List<Employee> GetAll()
    {
      List<Employee> allEmployees = new List<Employee> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM employees;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int employeeId = rdr.GetInt32(0);
        string employeeName = rdr.GetString(1);
        Developer developer = (Developer)rdr.GetInt32(2);
        Employee newEmployee = new Employee(employeeId, employeeName, developer);

        allEmployees.Add(newEmployee);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allEmployees;
    }

    public List<Item> GetItems()
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * from items WHERE item.ID = employees_items.itemID AND @thisId = items_employees.employeeID;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = Id;
      cmd.Parameters.Add(thisId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemTitle = rdr.GetString(1);
        string itemDescription = rdr.GetString(2);
        DateTime itemDue = rdr.GetDateTime(3);
        int itemCategory = rdr.GetInt32(4);
        bool itemComplete = rdr.GetBoolean(5);
        Item newItem = new Item(itemTitle, itemDescription, itemDue, itemCategory, itemComplete, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    // public static Employee Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM employees WHERE id = @thisId;";
    //   MySqlParameter thisId = new MySqlParameter();
    //   thisId.ParameterName = "@thisId";
    //   thisId.Value = id;
    //   cmd.Parameters.Add(thisId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int employeeId = 0;
    //   string employeeName = "";
    //   Developer developer = 0;
    //   while (rdr.Read())
    //   {
    //     employeeId = rdr.GetInt32(0);
    //     employeeName = rdr.GetString(1);
    //     Developer = (Developer) rdr.GetInt32(2);
    //   }
    //   Employee foundEmployee = new Employee();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return foundItem;
    // }

  }
}
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
    public List<Item> Items { get; set; }

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
      Items = new List<Item> { };
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
      cmd.CommandText = @"SELECT * FROM employeeitems WHERE itemId = @thisId";
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
        bool itemComplete = rdr.GetBoolean(4);
        Item newItem = new Item(itemTitle, itemDescription, itemDue, itemComplete, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
  }
}
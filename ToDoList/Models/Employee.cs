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
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public Developer Developer { get; set; }
    public List<Item> Items { get; set; }

    public Employee(int employeeId, string name, Developer developer)
    {
      Id = employeeId;
      Name = name;
      Developer = developer;
    }
    public static List<Employee> GetAll()
    {
      List<Employee> allItems = new List<Employee> { };
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

        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
    public static List<Item> GetItems()
    {

    }
  }


}
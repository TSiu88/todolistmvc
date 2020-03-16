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
    public Employee()
    {
      this.Employees = new HashSet<Employee>();
    }
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public Developer Developer { get; set; }
    public virtual ICollection<Employee> Employees
    { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}
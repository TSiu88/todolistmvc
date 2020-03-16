using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    // private static List<Category> _instances = new List<Category> { };
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }

    public Category(string categoryName, string description)
    {
      Name = categoryName;
      Description = description;
      Items = new List<Item> { };
    }
    public Category(string categoryName, string description, int categoryId)
    {
      Name = categoryName;
      Description = description;
      Id = categoryId;
    }
    public List<Item> GetCompletedItems()
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items WHERE Id = @thisId AND IsComplete = true";
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO categories (name, description) VALUES (@categoryName, @categoryDescription);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@categoryName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);

      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@categoryDescription";
      description.Value = this.Description;
      cmd.Parameters.Add(description);

      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM categories;";
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Category Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM categories WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int categoryId = 0;
      string categoryName = "";
      string categoryDescription = "";
      while (rdr.Read())
      {
        categoryId = rdr.GetInt32(0);
        categoryName = rdr.GetString(1);
        categoryDescription = rdr.GetString(2);
      }
      Category foundCategory = new Category(categoryName, categoryDescription, categoryId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundCategory;
    }

  }
}
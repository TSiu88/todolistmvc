using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Item> Items { get; set; }

    public Category(string categoryName, string description)
    {
      Name = categoryName;
      Description = description;
    }
    public Category(string categoryName, string description, int categoryId)
    {
      Name = categoryName;
      Description = description;
      Id = categoryId;
    }

    public static List<Category> GetAll()
    {
      List<Category> allCategories = new List<Category> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM categories;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int categoryID = rdr.GetInt32(0);
        string categoryName = rdr.GetString(1);
        string categoryDescription = rdr.GetString(2);
        Category newcategory = new Category(categoryName, categoryDescription, categoryID);
        allCategories.Add(newcategory);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCategories;
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

    public static void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM categories WHERE categories.Id = @Id;";
      MySqlParameter categoryId = new MySqlParameter();
      categoryId.ParameterName = "@Id";
      categoryId.Value = id;
      cmd.Parameters.Add(categoryId);

      cmd.ExecuteNonQuery();
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

    // public void AddItem(Item item)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"Insert into categories () * FROM categories WHERE id = @thisId;";
    //   MySqlParameter thisId = new MySqlParameter();
    //   thisId.ParameterName = "@thisId";
    //   thisId.Value = id;
    //   cmd.Parameters.Add(thisId);

    //   @"INSERT INTO items (title, description, due, category, complete) VALUES (@ItemTitle, @ItemDescription, @ItemDue, @ItemCategory, @ItemComplete);";
    // }
  }
}
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Due { get; set; }
    public bool IsComplete { get; set; }
    public int Id { get; set; }

    public Item(string title, string description, DateTime due, int category)
    {
      Title = title;
      Description = description;
      Due = due;
      CategoryId = category;
      IsComplete = false;
    }

    public Item(string title, string description, DateTime due, int category, bool complete, int itemId)
    {
      Id = itemId;
      Title = title;
      Description = description;
      Due = due;
      CategoryId = category;
      IsComplete = complete;
    }

    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item)otherItem;
        bool idEquality = (this.Id == newItem.Id);
        bool descriptionEquality = (this.Description == newItem.Description);
        return descriptionEquality;
      }
    }
    //Gets all items
    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
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

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    //Gets all items for a specific category
    public static List<Item> FindForCategory(int id)
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items WHERE categoryId = @thisCategory;";
      MySqlParameter thisCategory = new MySqlParameter();
      thisCategory.ParameterName = "@thisCategory";
      thisCategory.Value = id;
      cmd.Parameters.Add(thisCategory);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemTitle = "";
      string itemDescription = "";
      DateTime itemDue = DateTime.MinValue;
      int itemCategory = 0;
      bool itemComplete = false;
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemTitle = rdr.GetString(1);
        itemDescription = rdr.GetString(2);
        itemDue = rdr.GetDateTime(3);
        itemCategory = rdr.GetInt32(4);
        itemComplete = rdr.GetBoolean(5);
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

    public static Item Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemTitle = "";
      string itemDescription = "";
      DateTime itemDue = DateTime.MinValue;
      int itemCategory = 0;
      bool itemComplete = false;
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemTitle = rdr.GetString(1);
        itemDescription = rdr.GetString(2);
        itemDue = rdr.GetDateTime(3);
        itemCategory = rdr.GetInt32(4);
        itemComplete = rdr.GetBoolean(5);
      }
      Item foundItem = new Item(itemTitle, itemDescription, itemDue, itemCategory, itemComplete, itemId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO items (title, description, due, category, complete) VALUES (@ItemTitle, @ItemDescription, @ItemDue, @ItemCategory, @ItemComplete);";

      MySqlParameter title = new MySqlParameter();
      title.ParameterName = "@ItemTitle";
      title.Value = this.Title;
      cmd.Parameters.Add(title);

      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@ItemDescription";
      description.Value = this.Description;
      cmd.Parameters.Add(description);

      MySqlParameter due = new MySqlParameter();
      due.ParameterName = "@ItemDue";
      due.Value = this.Due;
      cmd.Parameters.Add(due);

      MySqlParameter category = new MySqlParameter();
      category.ParameterName = "@ItemCategory";
      category.Value = this.CategoryId;
      cmd.Parameters.Add(category);

      MySqlParameter complete = new MySqlParameter();
      complete.ParameterName = "@ItemComplete";
      complete.Value = this.IsComplete;
      cmd.Parameters.Add(complete);

      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}


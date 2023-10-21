// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Data;
// using System.Data.SqlClient.SqlConnection;
using System;

void AddRecord(){
   string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=LoveDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
   string cmdtext = "insert into product values(@id, @name, @price, @stock)";
   Console.WriteLine("ENTER ID");
   int id = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Enter Product");
   string name = Console.ReadLine();
   Console.WriteLine("ENTER Price");
   int price = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("ENTER stock");
   int stock = Convert.ToInt32(Console.ReadLine());

   SqlConnection con = null;
   SqlCommand command = null;

   try{
      con = new SqlConnection(connectionString);
      command = new SqlCommand(cmdtext, con);

      command.Parameters.AddWithValue("@id", id);
      command.Parameters.AddWithValue("@name", name);
      command.Parameters.AddWithValue("@price", price);
      command.Parameters.AddWithValue("@stock", stock);

      con.Open();
      command.ExecuteNonQuery();
      Console.WriteLine("Record Added");
   }
   catch(Exception ex){
      Console.WriteLine(ex.Message);
   }
   finally{
      con.Close();
   }
}
// AddRecord();

void Show(){
string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=LoveDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
string cmdtext= "select * from product";


try{
    SqlConnection con = new SqlConnection(connectionString);
    con.Open();

    Console.WriteLine("Connection opened Successfully.");
    SqlCommand command = new SqlCommand(cmdtext, con);
    SqlDataReader reader = command.ExecuteReader();
    
    while(reader.Read()){
       Console.WriteLine($"{reader["id"]} --- {reader["Name"]} --- {reader["Price"]} --- {reader["Stock"]}");

    }
    // Console.WriteLine(reader.Connection);
    con.Close();
}
catch(Exception ex){
   Console.WriteLine(ex.Message);
}
}

// Show();
void AddDisconnect(){
   string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=LoveDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
   
   Console.WriteLine("ENTER ID");
   int id = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("Enter Product");
   string name = Console.ReadLine();
   Console.WriteLine("ENTER Price");
   int price = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine("ENTER stock");
   int stock = Convert.ToInt32(Console.ReadLine());

   SqlConnection connection = null;
   SqlDataAdapter adapter = null;
   
   DataSet ds = null;
   DataTable prodTable = null;

   try{
      ds = new DataSet();
      connection = new SqlConnection(connectionString);
      adapter = new SqlDataAdapter("select * From product", connection);
      adapter.Fill(ds, "Prods");
      prodTable = ds.Tables["Prods"];
      DataRow prodrow = prodTable.NewRow();
      prodrow["id"] = id;
      prodrow["name"] = name;
      prodrow["price"] = price;
      prodrow["stock"] = stock;
      prodTable.Rows.Add(prodrow);
      
      SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
    
      adapter.Update(prodTable);
      Console.WriteLine("ROW ADDED.");
   } 
   catch(Exception ex){
      Console.WriteLine(ex.Message);
   }
}

void ShowDisconnect()
{
  string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=LoveDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
  string cmdtext = "insert into product values(@id, @name, @price, @stock)";
  SqlConnection connection  = null;
  SqlDataAdapter adapter = null;
  DataSet ds = null;
  DataTable prodTable = null;
  try
  {
    ds = new DataSet();
    connection = new SqlConnection(connectionString);
    adapter = new SqlDataAdapter("select * from product", connection);
    adapter.Fill(ds,"Prods");
    prodTable = ds.Tables["Prods"];
    Console.WriteLine($"Rows = {prodTable.Rows.Count}");
    Console.WriteLine($"Columns = {prodTable.Columns.Count}");

    foreach(DataRow row in prodTable.Rows){
        Console.WriteLine($"{row["Name"]}");
    }
  }
  catch(Exception ex){
    Console.WriteLine(ex.Message);
  }
}
AddDisconnect();
ShowDisconnect();

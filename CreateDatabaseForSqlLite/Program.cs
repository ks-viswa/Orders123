using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

string connectionString = "Data Source=mydatabase.db;Version=3;";
SQLiteConnection connection = new SQLiteConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Connected to SQLite Database!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{

    connection.Close();


    // Create customer table if not exists
    string createTableSql = "CREATE TABLE IF NOT EXISTS Customers (" +
   "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
   "Name  TEXT NOT NULL" +
   "); ";


    // Create order table
    createTableSql += " CREATE TABLE IF NOT EXISTS Orders (" +
     "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
     "CustomerId INTEGER NOT NULL," +
     "ItemName TEXT NOT NULL," +
     "Quantity INTEGER NOT NULL," +
     "UnitPrice TEXT NOT NULL," +
     "Total TEXT  NULL," +
     "PaymentTimestamp TEXT  NULL," +

     "FOREIGN KEY(CustomerId) REFERENCES Customers(Id) " +
     "); ";



    SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, connection);

    try
    {
        connection.Open();
        createTableCommand.ExecuteNonQuery();
        Console.WriteLine("Table created!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }

    //// Insert a record in customer table
    //string insertCustomerRecord =
    //    "INSERT INTO Customers(Name) " +
    //    "VALUES('Vishwa');";


    //SQLiteCommand insertCustomerCommand = new SQLiteCommand(insertCustomerRecord, connection);

    //try
    //{
    //    connection.Open();
    //    insertCustomerCommand.ExecuteNonQuery();
    //    Console.WriteLine("Customer Inserted!");
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine($"Error: {ex.Message}");
    //}
    //finally
    //{
    //    connection.Close();
    //}

    //SQLiteCommand readCustomer = new SQLiteCommand("Select * from Customers", connection);

    //try
    //{
    //    connection.Open();
    //    SQLiteDataReader dataCustomers = readCustomer.ExecuteReader();
    //    //Console.WriteLine("Customer Inserted!");
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine($"Error: {ex.Message}");
    //}
    //finally
    //{
    //    connection.Close();
    //}

}
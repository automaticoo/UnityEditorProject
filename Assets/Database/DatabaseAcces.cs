using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;


public class DatabaseAcces {
    private string connection;
    private SqliteConnection databaseConnection;
    private SqliteCommand databaseCommand;
    private SqliteDataReader reader;

    public DatabaseAcces()
    {
        
    }

    public void OpenDatabase(string p)
    {
        connection = "URI=file:" + p;
        databaseConnection = new SqliteConnection(connection);
        databaseConnection.Open();
    }
    public SqliteDataReader ExecuteQuery(string q)
    {
        databaseCommand = databaseConnection.CreateCommand();
        databaseCommand.CommandText = q;
        reader = databaseCommand.ExecuteReader();

        return reader;
    }

    public ArrayList ReadFullTable(string tableName)
    {
        string query = "SELECT * FROM " + tableName;

        databaseCommand = databaseConnection.CreateCommand();
        databaseCommand.CommandText = query;

        reader = databaseCommand.ExecuteReader();

        ArrayList readArray = new ArrayList();
        while (reader.Read())
        {
            ArrayList lineArray = new ArrayList();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                lineArray.Add(reader.GetValue(i));
            }
            readArray.Add(lineArray);
        }
        return readArray;
    }

    public void CloseDatabase()
    {
        if (reader != null)
        {
            reader.Close();
            reader = null;
        }
        databaseCommand = null;
        databaseConnection.Close();
        databaseConnection = null;
    }
}

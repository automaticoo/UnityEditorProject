using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;


public class BlockData
{
    public int ID { get; private set; }
    public string File { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int AvailableWidth { get; private set; }
    public int AvailableHeight { get; private set; }

    public BlockData(SqliteDataReader reader)
    {
        ID = reader.GetInt32(0);
        File = reader.GetString(1);
        Width = reader.GetInt32(2);
        Height = reader.GetInt32(3);
        AvailableWidth = reader.GetInt32(4);
        AvailableHeight = reader.GetInt32(5);
    }
}

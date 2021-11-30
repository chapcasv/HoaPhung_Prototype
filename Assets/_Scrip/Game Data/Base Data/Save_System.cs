using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save_System 
{
    private static string Player_data_path = "playerData.trandao";
    private static string Game_data_path = "gameData.trandao";

    public static bool isHavePlayerData()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if(File.Exists(path)) return true;
        else return false;
    }

    public static void ResetPlayerData()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Player_data_path;
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_Database data = new Player_Database(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveData(Player_Database data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Player_data_path;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void Save_Game_Data(Game_Database data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + Game_data_path;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
   
    public static Game_Database LoadGame()
    {
        string path = Application.persistentDataPath + Game_data_path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Game_Database data = formatter.Deserialize(stream) as Game_Database;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static Player_Database LoadPlayer()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_Database data = formatter.Deserialize(stream) as Player_Database;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static int Load_playerMoney()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_Database data = formatter.Deserialize(stream) as Player_Database;
            stream.Close();
            return data.money;
        }
        else
        {
            return 0;
        }
    }

    public static int Load_playerRuneCoin()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_Database data = formatter.Deserialize(stream) as Player_Database;
            stream.Close();
            return data.runeCoin;
        }
        else
        {
            return 0;
        }
    }

   
}

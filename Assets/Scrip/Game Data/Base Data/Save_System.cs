using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save_System 
{
    private static string Player_data_path = "playerData.fun";
    private static string Game_data_path = "gameData.fun";
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

    public static int Get_player_money()
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

    public static int Get_player_food()
    {
        string path = Application.persistentDataPath + Player_data_path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_Database data = formatter.Deserialize(stream) as Player_Database;
            stream.Close();
            return data.food;
        }
        else
        {
            return 0;
        }
    }

    public static UnitOfPlayer GetHero_Database_From_ID(Player_Database data, string ID)
    {
        
        foreach(UnitOfPlayer hero in data.hero_list)
        {
            if(hero.HeroID == ID)
            {
                return hero;
            }
        }
        return null;
    }
}

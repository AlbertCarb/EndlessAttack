using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveDataManager
{
/**/
    /*
    SaveDataManager::SavePlayer SaveDataManager::SavePlayer

    NAME
        SaveDataManager::SavePlayer - saves the player data

    SYNOPSIS
        public static void SaveDataManager::SavePlayer(Player a_player); 
            a_player -> player to be saved
        
    DESCRIPTION
        This function is responsible for saving the player's save data in a 
        binary format to a file to be accessed later on load.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public static void SavePlayer(Player a_player)
    {
        // creates a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // specifies a path and file type to save the persistant data 
        string path = Application.persistentDataPath + "/player.save";

        // opens a file stream
        FileStream fstream = new FileStream(path, FileMode.Create);

        // saves the player's data and stats
        PlayerSaveData pData = new PlayerSaveData(a_player);

        // serializes the data and closes the file stream
        formatter.Serialize(fstream, pData);
        fstream.Close();
    }
/* public static void SaveDataManager::SavePlayer(Player a_player); */

/**/
    /*
    SaveDataManager::LoadPlayer SaveDataManager::LoadPlayer

    NAME
        SaveDataManager::LoadPlayer - loads the player data

    SYNOPSIS
        public static PlayerSaveData SaveDataManager::LoadPlayer(); 
        
    DESCRIPTION
        This function is responsible for loading the player's save data and
        load it back into the game.

    RETURNS
        PlayerSaveData values from the file stream

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public static PlayerSaveData LoadPlayer()
    {
        // the save file to look for
        string path = Application.persistentDataPath + "/player.save";

        // if the file exists at the path then create new binary formatter
        // open the filestream at the path and deserialize the player's data
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fStream = new FileStream(path, FileMode.Open); 

            PlayerSaveData pData = formatter.Deserialize(fStream) as PlayerSaveData;
            fStream.Close();

            return pData;
        }
        else 
        {
            return null;
        }
    }
/* public static PlayerSaveData SaveDataManager::LoadPlayer(); */

/**/
    /*
    SaveDataManager::SaveGame SaveDataManager::SaveGame

    NAME
        SaveDataManager::SaveGame - saves the game data

    SYNOPSIS
        public static void SaveDataManager::SaveGame(GameManager a_game); 
            a_game -> game to be saved
        
    DESCRIPTION
        This function is responsible for saving the games's save data in a 
        binary format to a file to be accessed later on load.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public static void SaveGame(GameManager a_game)
    {
        // creates a binary formatter   
        BinaryFormatter formatter = new BinaryFormatter();
        
        // specifies a path and file type to save the persistant data 
        string path = Application.persistentDataPath + "/game.save";

        // opens a file stream
        FileStream fstream = new FileStream(path, FileMode.Create);

        // saves the games's data and stats
        GameSaveData gData = new GameSaveData(a_game);

        // serializes the data and closes the file stream
        formatter.Serialize(fstream, gData);
        fstream.Close();
    }
/* public static void SaveDataManager::SaveGame(GameManager a_game); */

/**/
    /*
    SaveDataManager::LoadGame SaveDataManager::LoadGame

    NAME
        SaveDataManager::LoadGame - loads the player data

    SYNOPSIS
        public static GameSaveData SaveDataManager::LoadGame(); 
        
    DESCRIPTION
        This function is responsible for loading the games's save data and
        load it back into the game.

    RETURNS
        GameSaveData values from the file stream

    AUTHOR
        Albert Carbillas

    DATE
        9/3/2019
    */
/**/
    public static GameSaveData LoadGame()
    {
        // the save file to look for
        string path = Application.persistentDataPath + "/game.save";

        // if the file exists at the path then create new binary formatter
        // open the filestream at the path and deserialize the player's data
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fStream = new FileStream(path, FileMode.Open); 

            GameSaveData gData = formatter.Deserialize(fStream) as GameSaveData;
            fStream.Close();

            return gData;
        }
        else 
        {
            return null;
        }
    }
/* public static GameSaveData SaveDataManager::LoadGame(); */
}

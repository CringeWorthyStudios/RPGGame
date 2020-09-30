using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // "c:/windows/something/player.sav"
        //string path = Application.persistentDataPath + "/player.sav";
        //create the file name +path only, to be used later
        string path = Application.dataPath + "/player.meme";
        //opens the file to be written to
        FileStream stream = new FileStream(path, FileMode.Create);
        //creates the data to be saved
        PlayerStats data = new PlayerStats(player);
        
        //writes he data to the file (also converts the data to text)
        formatter.Serialize(stream, data);

        stream.Close();
    }
    public static PlayerStats LoadPlayer()
    {
        string path = Application.dataPath + "/player.meme";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerStats data = formatter.Deserialize(stream) as PlayerStats;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
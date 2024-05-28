using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SavePlayer(ProgStuff Player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.FSCT";

        FileStream stream = new FileStream(path, FileMode.Create);

        Playerdata data = new Playerdata(Player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Playerdata LoadPlayer(){

        string path = Application.persistentDataPath + "/player.FSCT";

        if(File.Exists(path)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Playerdata data = formatter.Deserialize(stream) as Playerdata;
            stream.Close();

            return data;

        }else{
            Debug.Log("No Files?");
            return null;
        }

    }
}

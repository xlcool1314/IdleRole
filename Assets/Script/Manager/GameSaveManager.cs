using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : SingletonMono<GameSaveManager>
{
    public MyRoleData myAllRoles;

    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath+"/SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
        }

        BinaryFormatter bf = new BinaryFormatter();//二进制转化

        FileStream file = File.Create(Application.persistentDataPath + "/SaveData/myAllRoles.txt");

        var json = JsonUtility.ToJson(myAllRoles);

        bf.Serialize(file, json);

        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/SaveData/myAllRoles.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/myAllRoles.txt", FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myAllRoles);

            file.Close();

            
            
        }
    }
}

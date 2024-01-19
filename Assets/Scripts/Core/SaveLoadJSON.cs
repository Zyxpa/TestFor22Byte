using UnityEngine;
using System.IO;


public class SaveLoadJSON
{
    public static void Save(object obj, string jsonName)
    {
        string json = JsonUtility.ToJson(obj);
        string saveFilePath = Application.persistentDataPath + "/" + jsonName;
        File.WriteAllText(saveFilePath, json);

        Debug.Log("json save in " + saveFilePath);
    }

    public static T Load<T>(string jsonName)
    {
        string saveFilePath = Application.persistentDataPath + "/" + jsonName;
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            T Data = JsonUtility.FromJson<T>(loadPlayerData);
            return Data;
        }
        else
            return default(T); //TODO
            
    }
}

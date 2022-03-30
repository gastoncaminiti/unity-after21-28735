using UnityEngine;
using System;
using System.IO;

[Serializable]
public class GameData 
{
    public int score;
    public int[] gemQuantity;
    
    public void SaveGameDataJSON(){
        string jsonGameData = JsonUtility.ToJson(this);
        Debug.Log(jsonGameData);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", jsonGameData);
    }

    public bool LoadGameDataJSON(){
        if(File.Exists(Application.persistentDataPath + "/GameData.json")){
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
            GameData auxGameData = JsonUtility.FromJson<GameData>(jsonString);
            this.score = auxGameData.score;
            this.gemQuantity = auxGameData.gemQuantity;
            return true;
        }
        return false;
    }
}

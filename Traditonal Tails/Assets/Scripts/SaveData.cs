using UnityEngine;
using System.IO;

public static class SaveData
{
    private static string savePath = Application.persistentDataPath + "/savedata.json";

    public static void Save(Scores scores)
    {
        string json = JsonUtility.ToJson(scores);
        File.WriteAllText(savePath, json);
    }

    public static Scores Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<Scores>(json);
        }
        else
        {
            Debug.LogWarning("Save file not found. Returning default Scores object.");
            return new Scores { score = 0, highScore = 0 };
        }
    }
}
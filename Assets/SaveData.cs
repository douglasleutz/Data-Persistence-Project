using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{

    public static SaveData Instance;
    public string playerName;

    public string HighScoreName;
    public int HighScorePoints;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveString(string s)
    {
        playerName = s;
    }

    [System.Serializable]
    class SavedData
    {
        public int HSP; //High Score Points
        public string HSN; //High Score Name
    }

    public void SaveHighScore()
    {

        HighScoreName = playerName;

        SavedData data = new SavedData();
        data.HSP = HighScorePoints;
        data.HSN = HighScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            HighScoreName = data.HSN;
            HighScorePoints = data.HSP;
        }


    }

}

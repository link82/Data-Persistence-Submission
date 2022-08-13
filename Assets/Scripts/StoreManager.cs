using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;
    public string playerName;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

    public void SetHighScore(int value)
    {
        highScore = value;
        highScoreName = playerName;
        StoreData();
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    // Serializazion
    [System.Serializable]
    class PlayerData
    {
        public string highScoreName;
        public int highScore;
    }

    void LoadData()
    {
        string path = Application.persistentDataPath + "gamedata.json";
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        highScoreName = data.highScoreName;
        highScore = data.highScore;

    }

    void StoreData()
    {
        string path = Application.persistentDataPath + "gamedata.json";
        PlayerData data = new PlayerData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string output = JsonUtility.ToJson(data);

        File.WriteAllText(path, output);

    }
}

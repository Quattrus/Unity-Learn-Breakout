using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highestScore;
    }
    public static GameManager instance = null;
    private string currentPlayerName;
    [SerializeField] GameObject inputField;
    [SerializeField] TextMeshProUGUI highestScorer;
    private int highScore;
    private string playerName;
    private string highScorePlayerName;
    public string HighScorePlayerName
    {
        get
        {
            return highScorePlayerName;
        }
        set
        {
            highScorePlayerName = value;
        }
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }
    }
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        LoadHighScore();
    }
    private void Start()
    {
        highestScorer.text = $"Highest Score: {highScorePlayerName}: {highScore}";
    }

    private void Update()
    {
        playerName = currentPlayerName;
    }
    public void CurrentPlayerInput(string player)
    {
        player = inputField.GetComponent<TextMeshProUGUI>().text;
        currentPlayerName = player;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highestScore = highScore;
        data.highScorePlayerName = highScorePlayerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highestScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}

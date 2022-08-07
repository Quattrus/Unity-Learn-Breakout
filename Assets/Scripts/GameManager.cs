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
        public string playerName;
        public int highScore;
    }
    public static GameManager instance = null;
    private string currentPlayerName;
    [SerializeField] GameObject inputField;
    private int highScore;
    private string playerName;

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
        Debug.Log("name inputted: " + currentPlayerName);
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
        data.highScore = highScore;
        data.playerName = currentPlayerName;
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

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }
}

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
    public static GameManager instance = null;
    private int sceneNum;

    private string currentPlayerName;
    [SerializeField] GameObject inputField;

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
}

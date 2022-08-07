using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private string currentPlayerName;
    [SerializeField] TextMeshProUGUI playerNameDisplay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void CurrentPlayerInput(string player)
    {
        currentPlayerName = player;
        playerNameDisplay.text = "Player: " + currentPlayerName;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

}

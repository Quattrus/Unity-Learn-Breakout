using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] TextMeshProUGUI highestScorer;

    public string currentPlayerInput;

    private void Start()
    {
        highestScorer.text = $"Highest Score: {GameManager.instance.HighScorePlayerName}: {GameManager.instance.HighScore}";
    }

    public void PlayerInput()
    {
        currentPlayerInput = inputField.GetComponent<TextMeshProUGUI>().text;
        GameManager.instance.CurrentPlayerInput(currentPlayerInput);
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
}

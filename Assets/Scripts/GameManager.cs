using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private string currentPlayerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void CurrentPlayerInput(string player)
    {
        currentPlayerName = player;
        Debug.Log(currentPlayerName);
    }

}

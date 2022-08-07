using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameScript : MonoBehaviour
{
    private string currentPlayerName;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject textDisplay;

    public void StoreName()
    {
        currentPlayerName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Player: " + currentPlayerName;
    }

}

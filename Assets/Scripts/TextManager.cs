using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI whoWonText;
    string winner = GameManager.winnerName;

    private void Start()
    {
        whoWonText.text = winner;
    }

    // Rest of your code...
}
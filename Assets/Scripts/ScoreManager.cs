using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("SCORE")]
    public GameManager manager;

    [Header("BEST SCORE")]
    [SerializeField] Text highScoreText;


    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (manager.time * 10 < PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", manager.time * 10);
                //ACTIVAR TEXTO O PANEL DE HIGH SCORE
            }

        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", manager.time * 10);
        }

        highScoreText.text = PlayerPrefs.GetFloat("SavedHighScore").ToString("0");
    }
}

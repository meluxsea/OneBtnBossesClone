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
            //ACTIVAR TEXTO O PANEL DE HIGH SCORE

            if (manager.time > PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", manager.time);
            }
                
        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", manager.time);
        }

        highScoreText.text = PlayerPrefs.GetFloat("SavedHighScore").ToString();
    }
}

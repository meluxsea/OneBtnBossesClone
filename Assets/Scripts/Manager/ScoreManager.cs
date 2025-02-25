using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    [Header("BEST SCORE")]
    [SerializeField] Text highScoreText;
    [SerializeField] GameObject bestTimePanel;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }



    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (GameManager.managerInstance.time * 10 < PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", GameManager.managerInstance.time * 10);
                bestTimePanel.SetActive(true);
            }

        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", GameManager.managerInstance.time * 10);
        }

        highScoreText.text = PlayerPrefs.GetFloat("SavedHighScore").ToString("0");
    }
}

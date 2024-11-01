using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool canChangeTime = true;

    [Header("PANELS")]
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject victoryPanel;

    [Header("OTHER SCRIPTS")]
    public ScoreManager scoreManager;

    [Header("TIME")]
    [SerializeField] GameObject informationPanel;
    [SerializeField] Text textTime;
    public float time;



    private void Start()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    void Update()
    {
        Timer();
    }




    private void Timer()
    {
        if (canChangeTime) 
        {
            time += Time.deltaTime;
            textTime.text = (time * 10).ToString("0");
        }
    }


    public void activatePanel(GameObject panel)    
    {
        canChangeTime = false;
        panel.SetActive(true);
    }


    public void Win()
    {
        activatePanel(victoryPanel);
        scoreManager.HighScoreUpdate();

        textTime.text = "TIME                                          " + (time * 10).ToString("0");
        textTime.transform.SetParent(informationPanel.transform);
    }
}

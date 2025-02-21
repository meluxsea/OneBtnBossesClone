using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager managerInstance { get; private set; }

    bool canChangeTime = true;
    public bool canChangeDirection;

    [Header("PANELS")]
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject victoryPanel;
    [SerializeField] public GameObject powerUpPanel;

    [Header("TIME")]
    [SerializeField] GameObject informationPanel;
    [SerializeField] Text textTime;
    public float time;



    void Awake()
    {
        if (managerInstance == null)
        {
            managerInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);

        activatePanel(powerUpPanel);
        Time.timeScale = 0;
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
        ScoreManager.instance.HighScoreUpdate();

        textTime.text = "TIME                                          " + (time * 10).ToString("0");
        textTime.transform.SetParent(informationPanel.transform);
    }

    public void ChoosePowerUp(bool powerUpState)
    {
        canChangeDirection = powerUpState;
        Time.timeScale = 1;
        canChangeTime = true;
        powerUpPanel.SetActive(false);
    }
}

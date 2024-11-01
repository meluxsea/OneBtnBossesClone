using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject victoryPanel;
    [SerializeField] Text textTime;
    bool canChangeTime = true;
    float time;


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


}

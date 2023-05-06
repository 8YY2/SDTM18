using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;
    public GameObject PausePanel;
    public GameObject GameWinPanel, GameOverPanel;
    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        GameWinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    public void Pause()
    {

        if (PausePanel != null)
        {
           bool isActive = PausePanel.activeSelf;
           PausePanel.SetActive(!isActive);
            if (isActive)
            {
                Time.timeScale = 1;//game restart
            }
            else
            {
                Time.timeScale = 0;//game pause
            }

           
        }
    }


    public void Quit()
    {
        //Time.timeScale = 1;//game start
        SceneManager.LoadScene("mapscene");
    }

     public void Win()
    {
        Debug.Log("yes you touch!");
        bool win = true;
        GameWin(win);
    }
    public void method()
    {
        SceneManager.LoadScene("mapscene");

    }
    public static void GameWin(bool win)
    {
        if (win)
        {
            instance.GameWinPanel.SetActive(true);
            AudioManager.instance.Play("GameWin");
            Time.timeScale = 0;//game pause
        }

    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void GameOver()
    {
        
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;//game pause
        

    }

    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

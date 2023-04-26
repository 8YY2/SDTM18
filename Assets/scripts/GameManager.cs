﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    //public static GameManager instance;
    // Start is called before the first frame update
    public GameObject gameHelpPanel;
    public GameObject SetPanel,optionsPanel,SkinPanel;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ClearAll();
    }

    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
    public void backmenu()
    {
        SceneManager.LoadScene("mapscene");
    }
    public void backmain()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void method()
    {
        if (gameHelpPanel != null)
        {
            bool isActive = gameHelpPanel.activeSelf;

            gameHelpPanel.SetActive(!isActive);
        }
      
    }
    public void setmethod()
    {
       
        if (SetPanel != null)
        {
            bool isActive = SetPanel.activeSelf;

            SetPanel.SetActive(!isActive);
        }
    }

    public void close()
    {
        if (gameHelpPanel != null)
        {
            bool isActive = gameHelpPanel.activeSelf;

            gameHelpPanel.SetActive(!isActive);
        }

    }
    public void close2()
    {
        if (SetPanel != null)
        {
            bool isActive = SetPanel.activeSelf;

            SetPanel.SetActive(!isActive);
        }

    }

    public void changepanel()
    {

        if (optionsPanel != null)
        {
            bool isActive = optionsPanel.activeSelf;

            optionsPanel.SetActive(!isActive);
        }
        if (SkinPanel != null)
        {
            bool isActive = SkinPanel.activeSelf;

            SkinPanel.SetActive(!isActive);
        }


    }

    



}

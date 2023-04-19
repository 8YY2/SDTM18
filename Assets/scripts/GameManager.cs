using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    //public static GameManager instance;
    // Start is called before the first frame update
    public GameObject gameHelpPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playgame()
    {
        SceneManager.LoadScene("mapscene");//load level menu scene

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
    public void close()
    {
        if (gameHelpPanel != null)
        {
            bool isActive = gameHelpPanel.activeSelf;

            gameHelpPanel.SetActive(!isActive);
        }
    }
}

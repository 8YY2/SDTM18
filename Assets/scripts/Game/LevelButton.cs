using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int sceneIndex;
   public void OpenScene()
    {
        Time.timeScale = 1;//game start
        SceneManager.LoadScene(sceneIndex);
    }

}

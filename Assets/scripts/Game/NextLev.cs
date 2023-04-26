using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLev : MonoBehaviour
{

    public int levelToUnlock;
    int numberOfUnlockedLevels;

   

    public static NextLev instance = null;
    void Start()
    {
        
       
    }
    // Start is called before the first frame update
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            Debug.Log("HELLO");

            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked",numberOfUnlockedLevels+1);
            }

            FindObjectOfType<UIHealthBar>().Win();
            //UIHealthBar.Win();

        }
    }


   

}

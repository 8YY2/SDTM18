using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = .2f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
        }
    }
}

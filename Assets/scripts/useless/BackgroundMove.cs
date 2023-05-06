using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    //public float speed = 1f;

    private Transform background1, background2;
    Transform target;
    private void Start()
    {
        background1 = transform.GetChild(0);
        background2 = transform.GetChild(1);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
     void FixedUpdate()
    {

        background1.position = new Vector3(target.position.x+ 3.5f, target.position.y+ 3.5f, 0);
        background2.position = new Vector3(target.position.x+ 3.5f, target.position.y+3.5f , 0);


    }
}

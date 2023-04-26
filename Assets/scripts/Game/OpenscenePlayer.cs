using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenscenePlayer : MonoBehaviour
{
    public float speed;
    public bool horizontal;
    public float changeTime = 3.0f;
    int direction = 1;

    Rigidbody2D rigidbody2D;
    float timer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            
        }
    }

    void FixedUpdate()
    {


        Vector2 position = rigidbody2D.position;

        if (horizontal)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            Debug.Log("1");
            
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            Debug.Log("2");
            
            if (direction > 0)
            {
                Debug.Log("3");
                transform.localScale = new Vector2(0.7f, 0.7f);
            }
            else
            {
                Debug.Log("4");
                transform.localScale = new Vector2(-0.7f, 0.7f);//facing left
            }
          
        }

        rigidbody2D.MovePosition(position);
    }
}

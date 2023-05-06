using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
   
    Transform player;
    public float speed=3;
    
    // Start is called before the first frame update
    void Start()
    {
        //bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        //Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        //bulletRB.velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            AudioManager.instance.Play("Blood");
        }

    }

    
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    EnemyFollowPlayer Object = other.gameObject.GetComponent<EnemyFollowPlayer>();

    //    if (Object != null)
    //    {
    //        Destroy(Object);
    //        AudioManager.instance.Play("ZombieDie");
    //    }
    //}
}

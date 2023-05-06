using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float fireRate = 1f;
    private float nextfireTime;
    public float lineOfSite;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public int enemyHP = 100;
    public ParticleSystem smokeEffect;
    // Start is called before the first frame update
    private void Awake()
    {
        //smokeEffect.Stop();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer=Vector2.Distance(player.position, transform.position);
       
        if (distanceFromPlayer < lineOfSite &&distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange &&nextfireTime<Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextfireTime = Time.time+fireRate;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;

        if (enemyHP > 0)
        {

            Debug.Log(enemyHP);
        }
        else
        {
           
           
            Die();
            Instantiate(smokeEffect,transform.position,transform.rotation);
            AudioManager.instance.Play("ZombieDie");
            //AudioManager.instance.Play("ZombieDie");
            //Debug.Log(enemyHP);
        }

    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
        Gizmos.DrawWireSphere(transform.position,shootingRange);
    }
}

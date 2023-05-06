﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        //Debug.Log("Project" +other.gameObject);
        EnemyController e = other.collider.GetComponent<EnemyController>();
        gatecontrol door = other.collider.GetComponent<gatecontrol>();
        EnemyGFX ene = other.collider.GetComponent<EnemyGFX>();
        EnemyFollowPlayer boss=other.collider.GetComponent<EnemyFollowPlayer>();
        //bulletScript bullet = other.collider.GetComponent<bulletScript>();
        if (e != null)
        {
            e.Die();
        }
        if(door != null)
        {
            door.Die();
        }
        if( ene != null)
        {
            ene.TakeDamage(25);
        }
        if (boss != null)
        {
            boss.TakeDamage(20);
        }
        //if (bullet != null)
        //{
        //    Destroy(bullet);
        //}
        //if (other.gameObject.tag == "Zombie")
        //{
        //    other.gameObject.GetComponent<EneZombie>().TakeDamage(25);
        //    Debug.Log("Zombie01");
        //}

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            collision.GetComponent<EneZombie>().TakeDamage(25);
            Debug.Log("Zombie");
        }
        if(collision.tag == "bullet")
        {
            bulletScript bullet = collision.GetComponent<bulletScript>();
            Destroy(bullet);
        }

    }
}

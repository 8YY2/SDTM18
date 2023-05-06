using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    // Start is called before the first frame update

    public int enemyHP = 100;
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
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

            //AudioManager.instance.Play("ZombieDie");
            //Debug.Log(enemyHP);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            AudioManager.instance.Play("Blood");
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            if(playerController.Health < playerController.maxHealth)
            {
                playerController.ChangeHealth(1);
                Destroy(gameObject);
            }

            

        }

        //Debug.Log("object that entered the trigger :"+ other); 
    }
}

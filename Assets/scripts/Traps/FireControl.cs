using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public Animator animator;

    void OnCollisionEnter2D(Collision2D other)
    {

       
        PlayerController e = other.collider.GetComponent<PlayerController>();
        if (e != null)
        {
            animator.SetTrigger("isHit");
            e.ChangeHealth(-1);
            AudioManager.instance.Play("Blood");
            animator.SetTrigger("Fireon");
            AudioManager.instance.Play("FireBox");
        }

      
    }
  
}

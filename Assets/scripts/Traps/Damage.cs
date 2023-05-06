using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller= other.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
            AudioManager.instance.Play("Blood");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    

    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        /*
        if(other.CompareTag("Enemy")|| other.CompareTag("Player"))
        Destroy(other.gameObject);
        */

        Life life = other.GetComponent<Life>();
        if (life != null)
        {
            life.Amount -= damage; //-> Versión acortada de: life.amount = life.amount - damage;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("TerrainStructures") )
        {
            gameObject.SetActive(false);
            //Destroy(other.gameObject);            
        }
        Life life = other.GetComponent<Life>();
        if (life != null)
        {
            life.Amount -= damage; //-> Versión acortada de: life.amount = life.amount - damage;
        }
    }
}
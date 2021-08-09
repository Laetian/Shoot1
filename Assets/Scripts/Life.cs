using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;

    public float Amount
    {
        get => amount;
        set
        {
            amount = value;
            if (amount<= 0)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("PlayDie");
                Invoke("PlayDestruction", 0.6f);
                Destroy(gameObject, 2);
            }
        }
    }
    void PlayDestruction()
    {
        ParticleSystem xplosion = GetComponentInChildren<ParticleSystem>();
        xplosion.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    [SerializeField]
    [Tooltip("Punto de salida del disparo")]
    private GameObject shootingPoint;

    [SerializeField]
    [Tooltip("Balas del jugador")]
    private int bulletAmount;
    public int BulletAmount
    {
        get => bulletAmount;
        set
        {
            bulletAmount = bulletAmount + value;
        }
    }
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (bulletAmount > 0)
            {
                _animator.SetTrigger("ShotBullet");
                Invoke("FireBullet", 0);
            }
            else
            {
                //Activar texto NoAmmo
            }
        }

    }
    void FireBullet()
    {
        GameObject bullet = BulletPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("PlayerBullet");// asignas al prefab la layer que queremos
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);
        bulletAmount--;
    }
}

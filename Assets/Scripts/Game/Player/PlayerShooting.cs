using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting SharedInstance;

    [SerializeField]
    [Tooltip("Punto de salida del disparo")]
    private GameObject shootingPoint;

    public UnityEvent onAmmoChanged;

    [SerializeField]
    [Tooltip("Balas del jugador")]
    private int bulletAmount;
    public int BulletAmount
    {
        get => bulletAmount;

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
        onAmmoChanged.Invoke();
    }

}

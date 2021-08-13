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

    [SerializeField]
    [Tooltip("Particles shooting effect")]
    private ParticleSystem shootingEffect;

    [SerializeField]
    [Tooltip("Número de balas del jugador")]
    private int bulletAmount;
    public int BulletAmount
    {
        get => bulletAmount;
        set
        {
            bulletAmount = value;
        }
    }
    private Animator _animator;

    public UnityEvent onAmmoChanged;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("PlayerShooting duplicado debe ser destruido", gameObject);
            Destroy(this);
        }
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& Time.timeScale > 0)
        {
            if (bulletAmount > 0)
            {
                FireBullet();
                //Invoke("FireBullet", 0);
            }
            else
            {
                //Activar texto NoAmmo
            }
        }

    }
    private void FireBullet()
    {
        _animator.SetTrigger("ShotBullet");
        GameObject bullet = BulletPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("PlayerBullet");// asignas al prefab la layer que queremos
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);
        bulletAmount--;
        shootingEffect.Play();
        if(bulletAmount<0)
        {
            bulletAmount = 0;
        }
        onAmmoChanged.Invoke();
    }

}

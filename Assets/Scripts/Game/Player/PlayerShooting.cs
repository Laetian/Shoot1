using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting SharedInstance;

    [SerializeField]
    [Tooltip("Start point of bullet")]
    private GameObject shootingPoint;

    [SerializeField]
    [Tooltip("Particles shooting effect")]
    private ParticleSystem shootingEffect;

    [SerializeField]
    [Tooltip("Shoot sound basic")]
    private AudioSource shootSound;

    [SerializeField]
    [Tooltip("Player number of bullets")]
    private int bulletAmount;
    public int BulletAmount
    {
        get => bulletAmount;
        set
        {
            bulletAmount = value;
        }
    }
    [SerializeField]
    [Tooltip("Time between shoots")]
    private float fireRate = 0.5f;
    private float lastShootTime;

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
            Debug.LogWarning("Duplicated PlayerShooting must be destroyed", gameObject);
            Destroy(this);
        }
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& Time.timeScale > 0)
        {
            if (bulletAmount > 0)
            {
                var timeSinceLastShoot = Time.time - lastShootTime;
                if(timeSinceLastShoot < fireRate)
                {
                    return;
                }
                lastShootTime = Time.time;
                FireBullet();
                //Invoke("FireBullet", 0);
            }
            else
            {
                //TODO: Activate text NoAmmo + sound
            }
        }
        else
        {
            _animator.SetBool("ShotBullet", false);
        }
    }
    private void FireBullet()
    {
        //_animator.SetTrigger("ShotBulletTrigger");
        _animator.SetBool("ShotBullet", true);
        GameObject bullet = BulletPool.SharedInstance.GetFirstPooledObject();
        bullet.layer = LayerMask.NameToLayer("PlayerBullet");// Assign the wanted layer to prefab 
        bullet.transform.position = shootingPoint.transform.position;
        bullet.transform.rotation = shootingPoint.transform.rotation;
        bullet.SetActive(true);
        bulletAmount--;
        if(shootingEffect!=null)
        {
            shootingEffect.Play();
        }
        Instantiate(shootSound, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
        if(bulletAmount<0)
        {
            bulletAmount = 0;
        }
        onAmmoChanged.Invoke();
    }

}

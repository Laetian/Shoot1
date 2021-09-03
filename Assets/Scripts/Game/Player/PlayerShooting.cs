using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting SharedInstance;







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

    public Weapon weapon;

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
            if (bulletAmount > 0 && weapon.Shoot("PlayerBullet"))
            {
                //_animator.SetTrigger("ShotBulletTrigger");
                _animator.SetBool("ShotBullet", true);
                FireBullet();
            }
        }
        else
        {
            _animator.SetBool("ShotBullet", false);
        }
    }
    private void FireBullet()
    {
        bulletAmount--;
        if(bulletAmount<0)
        {
            bulletAmount = 0;
        }
        onAmmoChanged.Invoke();
    }

}

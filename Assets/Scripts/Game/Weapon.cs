using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootingPoint;

    private float lastShootTime;
    [SerializeField]
    private float shootRate;

    [SerializeField]
    [Tooltip("Particles shooting effect")]
    private ParticleSystem shootingEffect;

    [SerializeField]
    [Tooltip("Shoot sound basic")]
    private AudioSource shootSound;
    public bool Shoot(string layerName)
    {
        if (Time.timeScale > 0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < shootRate)
            {
                return false;
            }
            lastShootTime = Time.time;
            var bullet = BulletPool.SharedInstance.GetFirstPooledObject();
            bullet.layer = LayerMask.NameToLayer(layerName);
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true);
            if (shootingEffect != null)
            {
                shootingEffect.Play();
            }
            if (shootSound != null)
            {
                Instantiate(shootSound, transform.position, transform.rotation).GetComponent<AudioSource>().Play();
            }
            return true;
        }
        return false;
    }
}

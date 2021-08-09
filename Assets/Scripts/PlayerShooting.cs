using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    [SerializeField]
    [Tooltip("Punto de salida del disparo")]
    private GameObject shootingPoint;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = BulletPool.SharedInstance.GetFirstPooledObject();
            bullet.layer = LayerMask.NameToLayer("PlayerBullet");// asignas al prefab la layer que queremos
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true);
        }

    }
}

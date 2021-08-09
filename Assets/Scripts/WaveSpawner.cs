using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab de enemigo a generaar")]
    private GameObject prefab;

    [SerializeField]
    [Tooltip("Tiempo de inicio y fin de spawn")]
    private float startTime, endTime;

    [SerializeField]
    [Tooltip("Tiempo entre la generación de enemigos")]
    private float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }


    void SpawnEnemy()
    {
        //Forma sencilla de hacerlo
        Instantiate(prefab, transform.position, transform.rotation);

        /*Aleatorizando la rotación, complicandolo un huevo
        Quaternion q = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Random.Range(-45.0f, 45.0f), 0);
        Instantiate(prefab, transform.position, q);*/
    }
}

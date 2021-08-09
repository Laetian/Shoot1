using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    public List<WaveSpawner> waves;

    private void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.Log("WaveManager duplicado debe ser destruido", gameObject);
            Destroy(this);
        }
    }
}

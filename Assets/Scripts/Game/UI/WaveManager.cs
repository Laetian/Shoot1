using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    private List<WaveSpawner> waves;

    public int WaveCount
    {
        get => waves.Count;
    }

    private void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
            waves = new List<WaveSpawner>(); 
        }
        else
        {
            Debug.Log("WaveManager duplicado debe ser destruido", gameObject);
            Destroy(this);
        }
    }
    public void AddWave(WaveSpawner wave)
    {
        waves.Add(wave);

    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
    }
}

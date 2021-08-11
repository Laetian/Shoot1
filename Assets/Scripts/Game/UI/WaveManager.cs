using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    private List<WaveSpawner> waves;
    public int WaveCount
    {
        get => waves.Count;
    }

    public UnityEvent onWaveChanged;

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
        onWaveChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        waves.Remove(wave);
        onWaveChanged.Invoke();
    }
}

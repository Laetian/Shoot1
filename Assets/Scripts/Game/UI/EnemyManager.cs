using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    public List<Enemy> enemies;

    private void Awake()
    {
        if(SharedInstance ==null)
        {
            SharedInstance = this;
            enemies = new List<Enemy>();
        }
        else
        {
            Debug.LogWarning("EnemyManager duplicado debe ser destruido", gameObject);
            Destroy(this);
        }
    }
}

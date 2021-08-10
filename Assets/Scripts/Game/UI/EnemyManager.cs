using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    private List<Enemy> enemies;

    public int EnemyCount
    {
        get => enemies.Count;
    }

    public UnityEvent onEnemyChanged;

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
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onEnemyChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onEnemyChanged.Invoke();
    }
}

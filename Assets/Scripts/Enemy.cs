using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Puntos que se suman al destruir al enemigo")]
    public int pointsAmount;

    private void Start()
    {
        EnemyManager.SharedInstance.enemies.Add(this);
    }
    private void OnDestroy()
    {
        EnemyManager.SharedInstance.enemies.Remove(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }
}

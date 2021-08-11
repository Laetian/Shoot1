using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;

    [SerializeField]
    private Life baseLife;

    private void Start()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        baseLife.onDeath.AddListener(CheckLoseCondition);

        EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
        WaveManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckLoseCondition()
    {
    //PERDER
    SceneManager.LoadScene("LoseScene");      
    }
    void CheckWinCondition()
    {
        //GANAR
        if (EnemyManager.SharedInstance.EnemyCount <= 0 && WaveManager.SharedInstance.WaveCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

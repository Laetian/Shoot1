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
        RegisterScore();
    SceneManager.LoadScene("LoseScene");      
    }
    void CheckWinCondition()
    {
        //GANAR
        if (EnemyManager.SharedInstance.EnemyCount <= 0 && WaveManager.SharedInstance.WaveCount <= 0)
        {
            RegisterScore();
            SceneManager.LoadScene("WinScene");
        }
    }
    void RegisterScore()
    {
        var actualScore = ScoreManager.SharedInstance.Amount;
        PlayerPrefs.SetInt("Last Score", actualScore);

        var highScore = PlayerPrefs.GetInt("High Score", 0);
        if (actualScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", actualScore);
        }
    }
    /*void RegisterTime() //En caso de querer registrar un record por tiempo
    {
        var actualTime = Time.time;
        PlayerPrefs.SetFloat("Last Time", actualTime);

        var lowestTime = PlayerPrefs.GetFloat("Lowest Time", 99999.0f);
        if (actualTime < lowestTime)
        {
            PlayerPrefs.SetFloat("Lowest Time", actualTime);
        }
    }*/
}

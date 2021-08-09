using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;

    // Update is called once per frame
    void Update()
    {
        //GANAR
        if(EnemyManager.SharedInstance.enemies.Count <= 0 && WaveManager.SharedInstance.waves.Count <=0)
        {
            SceneManager.LoadScene("WinScene");
        }
        //PERDER
        if (playerLife.Amount <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

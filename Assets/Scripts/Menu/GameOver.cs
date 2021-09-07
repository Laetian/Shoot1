using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text actualScore, highScore;// actualTime, lowestTime;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        int scoreActual = PlayerPrefs.GetInt("Last Score");
        int scoreMax = PlayerPrefs.GetInt("High Score");
        //actualScore.text = "Score: " + PlayerPrefs.GetInt("Last Score");
        actualScore.text = string.Format("Score: {0}", scoreActual);
        highScore.text = string.Format("High Score: {0}", scoreMax);
    }
}

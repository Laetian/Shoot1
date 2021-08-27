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

        actualScore.text = "Score: " + PlayerPrefs.GetInt("Last Score");
        highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }


}

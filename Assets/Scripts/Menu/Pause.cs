using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu;

    [SerializeField]
    private AudioMixerSnapshot pauseSnp, gameSnp;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }


}

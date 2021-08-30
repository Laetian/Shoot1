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
    private void Start()
    {
        ResumeButton.SharedInstance.gameResume.AddListener(ResumeGame);
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

            pauseSnp.TransitionTo(0.2f);
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameSnp.TransitionTo(0.2f);
    }


}

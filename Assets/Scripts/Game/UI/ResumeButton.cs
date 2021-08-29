using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    
    private Button resumeButton;
    [SerializeField]
    private GameObject pauseMenu;
    private void Awake()
    {
        resumeButton = GetComponent<Button>();
    }
    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

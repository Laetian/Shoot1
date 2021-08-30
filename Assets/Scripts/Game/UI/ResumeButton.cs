using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    public UnityEvent gameResume;
    public static ResumeButton SharedInstance;

    private Button resumeButton;
    [SerializeField]
    private GameObject pauseMenu;
    private void Awake()
    {
        resumeButton = GetComponent<Button>();
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("ResumeButton duplicated must be destroyed", gameObject);
            Destroy(this);
        }
    }
    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);

    }
    public void ResumeGame()
    {
        gameResume.Invoke();
    }
}

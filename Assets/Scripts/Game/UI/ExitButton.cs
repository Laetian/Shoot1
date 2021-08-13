using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button exitButton;
    [SerializeField]
    private void Awake()
    {
        exitButton = GetComponent<Button>();
    }
    private void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

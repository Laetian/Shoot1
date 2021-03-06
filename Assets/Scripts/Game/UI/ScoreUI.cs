using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI SharedInstance;

    private TextMeshProUGUI _text;

    [SerializeField]
    [Tooltip("Puntuación")]
    private int score;
    public int Score
    {
        get => score;
        set
        {
            score += value;
        }
    }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("ScoreUI duplicado debe ser destruido", gameObject);
            Destroy(this);
        }
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = "Score: " + 0;
    }

    public void ChangeScore(int value)
    {
        score += value;
        _text.text = "Score: " + score;
    }


}

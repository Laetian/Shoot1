using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{


    private TextMeshProUGUI _text;


    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
   
    }
    private void Start()
    {
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(UpdateText);
        _text.text = "Remaining enemies: " + EnemyManager.SharedInstance.EnemyCount;
    }

    private void UpdateText()
    {
        _text.text = "Remaining enemies: " + EnemyManager.SharedInstance.EnemyCount;
    }

}

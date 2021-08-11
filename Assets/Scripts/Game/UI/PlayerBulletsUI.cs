using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerBulletsUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [SerializeField]
    private PlayerShooting targetShooting;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text= "Bullets: " + targetShooting.BulletAmount;
    }
    private void Start()
    {
        PlayerShooting.SharedInstance.onAmmoChanged.AddListener(CheckAmmo);
    }

    private void CheckAmmo()
    {
        _text.text = "Bullets: " + targetShooting.BulletAmount;
    }



}

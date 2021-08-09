using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Velocidad de movimiento del objeto en m/S")]
    [Range(0, 100)]
    private float speed;
    void Update()
    {
        float space = speed * Time.deltaTime;
        transform.Translate(0, 0, space);
    }
}

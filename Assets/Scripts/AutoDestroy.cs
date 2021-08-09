using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tiempo de autodestrucción")]
    private float destructionDelay;
    void OnEnable()
    {
        //Destroy(gameObject, destructionDelay);
        Invoke("HideObject", destructionDelay);
    }
    private void HideObject()
    {
        gameObject.SetActive(false);
    }

}

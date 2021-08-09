using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //Si no tiene RigidBody se lo pone

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Fuerza de movimiento del personaje en N/S")]
    [Range(0, 1000)]
    private float speed;

    [SerializeField]
    [Tooltip("Fuerza de rotacion del personaje en N/s")]
    [Range(0, 90)]
    private float rotationSpeed;


    private Rigidbody rb;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {



        float space = speed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(dir.normalized * space);
        rb.AddRelativeForce(dir.normalized * space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX * angle, 0);
        rb.AddRelativeTorque(0, mouseX * angle, 0);


        /*
    if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
    {
    this.transform.Translate(0, 0, space);
    }
    if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
    {
    this.transform.Translate(-space, 0, 0);
    }
    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
    this.transform.Translate(0, 0, -space);
    }
    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
    this.transform.Translate(space, 0, 0);
    }*/
    }
}

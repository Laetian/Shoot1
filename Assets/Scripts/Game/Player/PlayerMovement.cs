using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //Place RigidBody inn case do not have it.
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Movement force of character in N/S")]
    [Range(0, 1000)]
    private float speed;
    [SerializeField]
    [Tooltip("Movement force of character in N/S")]
    [Range(0, 1000)]
    private float speedRun;

    [SerializeField]
    [Tooltip("Torque of character in N/s")]
    [Range(0, 90)]
    private float rotationSpeed;


    private Rigidbody rb;
    private Animator _animator;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {



        float space = speed * Time.deltaTime;
        float spaceRun = speedRun * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(dir.normalized * space);
        rb.AddRelativeForce(dir.normalized * space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX * angle, 0);
        rb.AddRelativeTorque(0, mouseX * angle, 0);
        _animator.SetFloat("Speed", rb.velocity.magnitude);
        _animator.SetFloat("MoveX", horizontal);
        _animator.SetFloat("MoveY", vertical);

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rb.AddRelativeForce(dir.normalized * spaceRun);
        }



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

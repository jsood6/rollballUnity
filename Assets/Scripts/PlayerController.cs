using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float rotateSpeed;
    public float breakSensitivity;

    public float fallSpeed;

    public Rigidbody car;


    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Let the rigidbody take control and detect collisions.
    void EnableRagdoll()
    {
        car.isKinematic = false;
        car.detectCollisions = true;
    }

    // Let animation control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        car.isKinematic = true;
        car.detectCollisions = false;
    }

    void Update()
    {

        // Gravity
        transform.Translate(Vector3.down * fallSpeed, Space.World);

        // Steering Right
        if ( Input.GetAxis("Horizontal") > 0 )
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        }
        // Steering Left
        if ( Input.GetAxis("Horizontal") < 0 )
        {
            transform.Rotate(Vector3.down, Input.GetAxis("Horizontal") * -1 * rotateSpeed, 0);
        }
        // Gas Pedal
        if ( Input.GetAxis("Vertical") != -1 && Input.GetAxis("Vertical") != 0 )
        {
            float tmp2 = (Input.GetAxis("Vertical") + 1.0f) * movementSpeed;
            Debug.Log(tmp2);
            transform.Translate(0, 0, tmp2 * movementSpeed);
        }
        // Break pedal
        if ( Input.GetAxis("Mouse ScrollWheel") != 0 && Input.GetAxis("Mouse ScrollWheel") != 0.1f )
        {
            transform.Translate(0, 0, -.75f);
        }

    }
}
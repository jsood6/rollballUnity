using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float rotateSpeed = 1.7f;
    public float breakSensitivity;

    public float fallSpeed = .03f;

    public Rigidbody car;


    void Start()
    {
        car = GetComponent<Rigidbody>();
        car.AddForce(Vector3.down * 100000000000000);
    }

    void Update()
    {

        // Gravity
        transform.Translate(Vector3.down * fallSpeed, Space.World);

        // Steering Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        }
        // Steering Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.down, Input.GetAxis("Horizontal") * -1 * rotateSpeed, 0);
        }
        // Gas Pedal
        if (Input.GetAxis("Vertical") != -1 && Input.GetAxis("Vertical") != 0)
        {
            float tmp2 = (Input.GetAxis("Vertical") + 1.0f) * movementSpeed;
            Debug.Log(tmp2);
            if ( tmp2 >= .7f )
            {
                transform.Translate(0, 0, .7f * movementSpeed);
            }
            else
            {
                transform.Translate(0, 0, tmp2 * movementSpeed);
            }
        }
        // Break pedal
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && Input.GetAxis("Mouse ScrollWheel") != 0.1f)
        {
            transform.Translate(0, 0, -.75f);
        }

    }
}
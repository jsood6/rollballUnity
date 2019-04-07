using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public float maxSteerAngle = 30;
    public float motorForce = 50;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;


    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    public void GetInput()
    {
        //Debug.Log("Getting Input");
        m_horizontalInput = Input.GetAxis("Horizontal");
        // No pedals pressed
        if (!Input.anyKey)            
        {

            //Going backwards
            if (Input.GetAxis("Mouse ScrollWheel") != 0.1f && m_verticalInput > -10.19f)
            {
                m_verticalInput = -10;
                //m_verticalInput = (Input.GetAxisRaw("Vertical")-10);
            }
            else if (Input.GetAxis("Vertical") != -1 && m_verticalInput < 10.19f)
            {
                m_verticalInput = 10;
                //m_verticalInput = Input.GetAxisRaw("Vertical")+10;
            }
        }
        else
        {
            m_verticalInput = 0;
        }
    }

    private void Steer()
    {
        //Debug.Log("Steering");
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        //Debug.Log("Accelerating");
        frontDriverW.motorTorque = m_verticalInput * motorForce * (Time.deltaTime / 2);
        frontPassengerW.motorTorque = m_verticalInput * motorForce * (Time.deltaTime / 2);
    }

    private void UpdateWheelPoses()
    {
        //Debug.Log("Update Wheel Poses");
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int movementSpeed;
    public int rotateSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down, Input.GetAxis("Horizontal") * -1 * rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.07f);
        }
    }
}*/
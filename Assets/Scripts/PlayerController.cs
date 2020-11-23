using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    const float turnSpeed = 30.0f;
    const float acceleration = 10.0f;
    const float turboAcceleration = 100.0f;
    const float deceleration = 40.0f;
    const float turboDeceleration = 100.0f;
    const float maxSpeed = 20.0f;
    const float turboMaxSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += turboAcceleration * Time.deltaTime;
                speed = Mathf.Min(speed, turboMaxSpeed);
            }
            else
            {
                speed += acceleration * Time.deltaTime;
                if (speed > maxSpeed)
                {
                    speed -= turboDeceleration * Time.deltaTime;
                    speed = Mathf.Max(speed, maxSpeed);
                }
            }
        }
        else
        {
            if (speed > maxSpeed)
            {
                speed -= turboDeceleration * Time.deltaTime;
            }
            else
            {
                speed -= deceleration * Time.deltaTime;
            }
            speed = Mathf.Max(speed, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -turnSpeed * (Mathf.Min(speed, 20.0f) / 20.0f) * Time.deltaTime, 0.0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, turnSpeed * (Mathf.Min(speed, 20.0f) / 20.0f) * Time.deltaTime, 0.0f, Space.Self);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0.0f, 0.0f, 2000.0f * Time.deltaTime, Space.Self);
        }
        

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

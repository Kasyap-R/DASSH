using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Rigidbody rb;

    public float turningRate = 0f;
    public float m_Speed = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1f, 0);
    }
    
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        
        Vector3 movement = transform.forward * moveInput * Time.deltaTime * m_Speed;
        rb.MovePosition(transform.position + movement);

        Quaternion turnTorque = Quaternion.Euler(0f, turnInput * turningRate * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnTorque);
    }
}

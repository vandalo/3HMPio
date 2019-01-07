using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pio_controller : MonoBehaviour
{

    public float m_acceleration;
    public float m_velocityLimit;
    public float m_jump;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right") && rb.velocity.x < m_velocityLimit)
        {
            rb.AddForce(transform.forward * m_acceleration * Time.deltaTime * 100);
        }

        if (Input.GetKey("left") && rb.velocity.x > -m_velocityLimit)
        {
            rb.AddForce(transform.forward * m_acceleration * -1 * Time.deltaTime * 100);
        }

        if (Input.GetKey("up"))
        {
            rb.AddForce(transform.up * m_jump * Time.deltaTime * 100);
        }

    }

}

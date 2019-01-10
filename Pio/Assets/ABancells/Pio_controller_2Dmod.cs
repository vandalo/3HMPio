using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pio_controller_2Dmod : MonoBehaviour
{

    public float m_acceleration;
    public float m_velocityLimit;
    public float m_jump;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right") && Mathf.Abs(rb.velocity.x) < m_velocityLimit)
        {
            rb.AddForce(Vector2.right * m_acceleration * Time.deltaTime * 100);
            print("right");
        }

        if (Input.GetKey("left") && Mathf.Abs(rb.velocity.x) < m_velocityLimit)
        {
            rb.AddForce(Vector2.left * m_acceleration * Time.deltaTime * 100);
            print("left");
        }

        if (Input.GetKey("up") && !IsJumping())
        {
            rb.AddForce(transform.up * m_jump * Time.deltaTime * 100);
            print("up");
        }

    }

    private bool IsJumping()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f);

        if (hit.collider != null)
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            return false;
        }
        return true;
    }
}

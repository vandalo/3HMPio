using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer_belt : MonoBehaviour
{
    public float m_speed;
    public bool m_goesLeft;

    private void Start()
    {
        m_goesLeft = true;
    }

    void OnCollisionStay(Collision collision)
    {        
        float conveyerVelocity = m_speed;
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (Mathf.Abs(rigidbody.velocity.x) < m_speed)
        {
            int direction = -1;
            if (m_goesLeft)
            {
                direction = 1;
            }
            rigidbody.velocity += conveyerVelocity * (new Vector3(direction, 0, 0));
        }        
    }
}

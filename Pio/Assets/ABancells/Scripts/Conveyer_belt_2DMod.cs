using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer_belt_2DMod : MonoBehaviour
{
    public float m_speed;
    public bool m_goesLeft;

    private void Start()
    {
        m_goesLeft = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {        
        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        print("entra");
        if (Mathf.Abs(rigidbody.velocity.x) < m_speed)
        {

            int direction = -1;
            if (m_goesLeft)
            {
                direction = 1;
            }
            rigidbody.velocity += m_speed * (new Vector2(direction, 0.0f));
        }        
    }
}

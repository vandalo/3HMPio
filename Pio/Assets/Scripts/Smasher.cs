using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    public float m_limitMovement;
    public float m_speed;
    
    private float m_initPosition;
    private int m_moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        m_initPosition = gameObject.transform.position.y;
        m_moveDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_limitMovement < (gameObject.transform.position.y - m_initPosition) && m_moveDirection == 1)
        {
            m_moveDirection = -1;
        }
        else if (Mathf.Abs((gameObject.transform.position.y - m_initPosition)) > m_limitMovement && m_moveDirection == -1)
        {
            m_moveDirection = 1;
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (Time.deltaTime * m_speed * m_moveDirection), gameObject.transform.position.z);
    }
}

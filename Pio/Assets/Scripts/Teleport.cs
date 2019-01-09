using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject m_destiny;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        collision.gameObject.transform.position = m_destiny.transform.position;
    }
}

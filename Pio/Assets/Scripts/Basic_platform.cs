using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_platform : MonoBehaviour
{
    private Vector3 initPosition;

    public bool moveX;
    public float speedX;
    public float distanceMovementX;
    public float delayAtChangeX;

    private int directionX;

    public bool moveY;
    public float speedY;
    public float distanceMovementY;
    public float delayAtChangeY;

    private int directionY;


    public bool rotate;
    public float speedRotate;
    public float radi;

    private float timerCounter;
    List<GameObject> collisionItems = new List<GameObject>();

    void Start()
    {
        initPosition = transform.position;
        directionX = 1;
        directionY = 1;

        timerCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = transform.position;
        if (moveX)
        {
            transform.position = new Vector3(transform.position.x + (Time.deltaTime * speedX * directionX), transform.position.y, transform.position.z);
            if (Mathf.Abs(transform.position.x - initPosition.x) > distanceMovementX)
            {
                directionX *= -1;
                transform.position = new Vector3(transform.position.x + (Time.deltaTime * speedX * directionX), transform.position.y, transform.position.z);
            }
        }

        if (moveY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * speedY * directionY), transform.position.z);
            if (Mathf.Abs(transform.position.y - initPosition.y) > distanceMovementY)
            {
                directionY *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * speedY * directionY), transform.position.z);
            }
        }

        if (rotate)
        {
            timerCounter += Time.deltaTime * speedRotate;

            float x = Mathf.Cos(timerCounter) * radi;
            float y = Mathf.Sin(timerCounter);

            transform.position = new Vector3(initPosition.x + x, initPosition.y + y, initPosition.z);
        }

        foreach (GameObject collisionItem in collisionItems)
        {
            float posX = collisionItem.transform.position.x + (transform.position.x - oldPosition.x);
            float posY = collisionItem.transform.position.y + (transform.position.y - oldPosition.y);
            float posZ = collisionItem.transform.position.z + (transform.position.z - oldPosition.z);
            collisionItem.transform.position = new Vector3(posX, posY, posZ);
        }
        collisionItems.Clear();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        collisionItems.Add(collision.gameObject);
    }

}

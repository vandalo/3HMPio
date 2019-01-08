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
    }
}

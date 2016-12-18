using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 position, acceleration, startPosition, velocity;
    public Vector3 startVelocity;
    float mass;
    Quaternion baseRotation;

    public Vector3 getPosition()
    {
        return position;
    }

    public float getMass()
    {
        return mass;
    }

    public void resetPosition()
    {
        position = startPosition;
        gameObject.transform.position = position;
        velocity = startVelocity;
        rotateShip();
    }

    void rotateShip()
    {
        //Vector3 tempVector = new Vector3(-velocity.x, -velocity.y, 0);
        //gameObject.transform.rotation = Quaternion.LookRotation(tempVector);
        
        //gameObject.transform.rotation. = FromToRotation(Vector3.forward, Vector3.down);
    }
    // Use this for initialization
    void Start()
    {
        acceleration = new Vector3(0, 0, 0);
        mass = 0.001f;
        baseRotation = gameObject.transform.rotation;
        startPosition = gameObject.transform.position;
        position = startPosition;
        velocity = startVelocity;
        rotateShip();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isLaunched)
        {
            acceleration = GameManager.findAcceleration();
            velocity += acceleration * GameManager.timeStep;
            position += velocity * GameManager.timeStep;
            gameObject.transform.position = position;
            rotateShip();
        }
    }
}

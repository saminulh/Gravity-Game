using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 acceleration, startPosition, velocity;
    public Vector3 startVelocity, up;
    float mass;

    public Vector3 getPosition()
    {
        return gameObject.transform.position;
    }

    public void setPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public float getMass()
    {
        return mass;
    }

    public void resetPosition()
    {
        gameObject.transform.position = startPosition;
        velocity = startVelocity;
        acceleration = Vector3.zero;
        rotateShip();
    }

    void rotateShip()
    {
        Quaternion rotation = new Quaternion();
        rotation.SetLookRotation(-velocity, Vector3.back);// +acceleration/10);
        transform.localRotation = rotation;
    }
    // Use this for initialization
    void Start()
    {
        acceleration = new Vector3(0, 0, 0);
        mass = 0.001f;
        startPosition = gameObject.transform.position;
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
            gameObject.transform.position += velocity * GameManager.timeStep; ;
            rotateShip();
        }
    }
}

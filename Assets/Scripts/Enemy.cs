using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerControls.playerColor color;
    GameObject target;
    public float maxSpeed;
    public Vector3 position, velocity, acceleration, targetPosition;
    public bool pinged;

    // Start is called before the first frame update
    void Start()
    {
        pinged = false;
        target = GameManager.instance.GetPlayer(color);

        position = transform.position;
        velocity = Vector3.zero;
        acceleration = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinged)
        {
            Pursue();
        }
        else
        {
            targetPosition = target.transform.position;
        }
    }

    public void Ping()
    {
        pinged = true;
    }

    public void Unping()
    {
        pinged = false;
    }

    void Pursue()
    {
        Vector3 desiredVelocity = targetPosition - position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 pursuingForce = desiredVelocity - velocity;
        pursuingForce.z = 0;
        velocity += pursuingForce * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
}

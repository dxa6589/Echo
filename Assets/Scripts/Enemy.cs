using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerControls.playerColor color;
    GameObject target;
    public float maxSpeed;
    Vector3 position, velocity, targetPosition;
    bool pinged;

    // Start is called before the first frame update
    void Start()
    {
        pinged = false;
        target = GameManager.instance.GetPlayer(color);

        position = transform.position;
        velocity = Vector3.zero;
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

    void Pursue()
    {
        Vector3 desiredVelocity = targetPosition - position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 pursuingForce = desiredVelocity - velocity;
        pursuingForce.z = 0;
        velocity += pursuingForce * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
        bool closeEnough = position.x - targetPosition.x < Mathf.Abs(0.01f) && position.y - targetPosition.y < Mathf.Abs(0.01f);
        if (closeEnough)
        {
            pinged = false;
        }
    }

    //Collision logic and kill here
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(target))
        {
            other.GetComponent<PlayerControls>().Kill();
            velocity = Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    public float maxSpeed;
    Vector3 position, velocity, targetPosition;
    bool pinged;

    // Start is called before the first frame update
    void Start()
    {
        pinged = false;
        target = tag == "Orange" ? GameManager.instance.GetOrangePlayer() : GameManager.instance.GetBluePlayer();

        position = transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinged)
        {
            Seek();
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

    void Seek()
    {
        Vector3 desiredVelocity = targetPosition - position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;
        Vector3 pursuingForce = desiredVelocity - velocity;
        pursuingForce.z = 0;
        velocity += pursuingForce * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;
        bool closeEnough = (Mathf.Abs(position.x - targetPosition.x) < 0.01f) && (Mathf.Abs(position.y - targetPosition.y) < 0.01f);
        if (closeEnough)
        {
            pinged = false;
        }
    }

    //Collision logic and kill here
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Colliding with " + other.name);
        if (other.gameObject.Equals(target))
        {
            other.GetComponent<PlayerControls>().Kill();
            velocity = Vector3.zero;
        }
    }
}

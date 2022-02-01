using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = tag == "Blue" ? GameManager.instance.GetOrangePlayer() : GameManager.instance.GetBluePlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Collision logic and kill here
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(target))
        {
            other.GetComponent<PlayerControls>().Kill();
        }
    }

}

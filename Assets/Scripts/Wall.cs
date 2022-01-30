using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public PlayerControls.playerColor color;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.GetOtherPlayer(color);
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

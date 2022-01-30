using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public PlayerControls.playerColor color;
    public bool pinged = true;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //pinged = false;
        target = GameManager.instance.GetOtherPlayer(color);
    }

    // Update is called once per frame
    void Update()
    {
        if (pinged) Show();
        else Hide();
    }

    void Show()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Hide()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Ping()
    {
        pinged = true;
    }

    public void Unping()
    {
        pinged = false;
    }
}

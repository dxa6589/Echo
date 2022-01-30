using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject orangePlayer;
    [SerializeField] GameObject bluePlayer;
    GameObject active;
    public static GameManager instance;
    void Start()
    {
        instance = this;
        active = bluePlayer;
        orangePlayer.GetComponent<PlayerControls>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (active == bluePlayer)
            {
                active = orangePlayer;
                orangePlayer.GetComponent<PlayerControls>().enabled = true;
                bluePlayer.GetComponent<PlayerControls>().enabled = false;
            }
            else
            {
                active = bluePlayer;
                orangePlayer.GetComponent<PlayerControls>().enabled = false;
                bluePlayer.GetComponent<PlayerControls>().enabled = true;
            }
        }
    }

    public GameObject GetPlayer(PlayerControls.playerColor color)
    {
        if (color == PlayerControls.playerColor.orange)
        {
            return orangePlayer;
        }
        else
        {
            return bluePlayer;
        }
    }

    public GameObject GetOtherPlayer(PlayerControls.playerColor color)
    {
        if (color == PlayerControls.playerColor.orange)
        {
            return bluePlayer;
        }
        else
        {
            return orangePlayer;
        }
    }
}

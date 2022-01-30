using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject orangePlayer;
    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject GameWonMenu;
    [SerializeField] GameObject GameLostMenu;
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

    public void GameWon()
    {
        Debug.Log("Game Won!");
        GameWonMenu.SetActive(true);
        bluePlayer.GetComponent<PlayerControls>().enabled = false;
        orangePlayer.GetComponent<PlayerControls>().enabled = false;
    }

    public void GameLost(string message)
    {
        Debug.Log("Game Won!");
        GameLostMenu.transform.Find("LossDetails").GetComponent<Text>().text = message;
        GameLostMenu.SetActive(true);
        bluePlayer.GetComponent<PlayerControls>().enabled = false;
        orangePlayer.GetComponent<PlayerControls>().enabled = false;
    }

    public void Restart()
    {
        Debug.Log("Game restarted");
        Scene currentScene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentScene.name);
        //GameWonMenu.SetActive(false);
        //GameLostMenu.SetActive(false);
    }
}

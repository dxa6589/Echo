using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject GameWonMenu;
    [SerializeField] GameObject GameLostMenu;
    [SerializeField] PlayerControls playerOrange;
    [SerializeField] PlayerControls playerBlue;
    GameObject active;
    public static GameManager instance;

    void Start()
    {
        instance = this;
        
        playerBlue.gameObject.SetActive(true);
        playerOrange.gameObject.SetActive(false);
    }
    public GameObject GetActivePlayer()
    {
        if (playerBlue.gameObject.activeSelf)
        {
            return playerBlue.gameObject;
        }
        else
        {
            return playerOrange.gameObject;
        }
    }
    public void SwapPlayers()
    {
        if (playerBlue.gameObject.activeSelf)
        {
            playerBlue.gameObject.SetActive(false);
            playerOrange.gameObject.SetActive(true);
        }
        else if (playerOrange.gameObject.activeSelf)
        {
            playerOrange.gameObject.SetActive(false);
            playerBlue.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject GetPlayer(PlayerControls.playerColor color)
    {
        if (color == PlayerControls.playerColor.orange)
        {
            return playerOrange.gameObject;
        }
        else
        {
            return playerBlue.gameObject;
        }
    }

    public GameObject GetOtherPlayer(PlayerControls.playerColor color)
    {
        if (color == PlayerControls.playerColor.orange)
        {
            return playerBlue.gameObject;
        }
        else
        {
            return playerOrange.gameObject;
        }
    }

    public void GameWon()
    {
        Debug.Log("Game Won!");
        GameWonMenu.SetActive(true);
        playerBlue.enabled = false;
        playerOrange.enabled = false;
    }

    public void GameLost(string message)
    {
        Debug.Log("Game Won!");
        GameLostMenu.transform.Find("LossDetails").GetComponent<Text>().text = message;
        GameLostMenu.SetActive(true);
        playerBlue.enabled = false;
        playerOrange.enabled = false;
    }

    public void Restart()
    {
        Debug.Log("Game restarted");
        Scene currentScene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentScene.name);
    }

    public void NextLevel()
    {
        Debug.Log("Loading next level");
        Scene nextScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nextScene.name);
    }
}

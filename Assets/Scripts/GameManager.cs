using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayerControls playerOrange;
    [SerializeField] PlayerControls playerBlue;
    [SerializeField] GameObject menu, status;
    public static GameManager instance;
    bool paused, gameActive;

    void Start()
    {
        instance = this;
        paused = false;
        gameActive = true;
        
        playerBlue.enabled = true;
        playerOrange.enabled = false;

        if (menu) print("MENU: " + menu.name);
        else print("No menu");

        if (!menu)
        {
            menu = GameObject.Find("/Canvas/Menu").gameObject;
            print(menu.name);
        }
    }
    public GameObject GetActivePlayer()
    {
        if (playerBlue.enabled)
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
        if (playerBlue.enabled)
        {
            playerBlue.enabled = false;
            playerOrange.enabled = true;
        }
        else if (playerOrange.enabled)
        {
            playerBlue.enabled = true;
            playerOrange.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (paused) Resume();
            else Pause();
        }

    }

    public GameObject GetOrangePlayer()
    {
        return playerOrange.gameObject;
    }

    public GameObject GetBluePlayer()
    {
        return playerBlue.gameObject;
    }

    public void GameWon()
    {
        gameActive = false;
        Debug.Log("Game Won!");
        status.GetComponent<Text>().text = "GAME WON!";
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameLost()
    {
        gameActive = false;
        Debug.Log("Game Lost");
        status.GetComponent<Text>().text = "GAME OVER";
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        paused = true;
        Debug.Log("Game Paused");
        status.GetComponent<Text>().text = "GAME PAUSED";
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        paused = false;
        Debug.Log("Game Resumed");
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        gameActive = true;
        Debug.Log("Game restarted");
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentScene.name);
    }

    public void Quit()
    {
        Debug.Log("Quitting game");
        //if (Application.isEditor) UnityEditor.EditorApplication.isPlaying = false;
        //else 
            Application.Quit();
    }
}

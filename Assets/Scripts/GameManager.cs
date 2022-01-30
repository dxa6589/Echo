using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerControls playerOrange;
    [SerializeField] PlayerControls playerBlue;
    [SerializeField] GoalScript goal;
    void Start()
    {
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
        if (goal.hasBlueTouchedGoal && goal.hasOrangeTouchedGoal)
        {
            SceneManager.LoadScene("level1");
            print("The player has won");
        }
       
    }
}

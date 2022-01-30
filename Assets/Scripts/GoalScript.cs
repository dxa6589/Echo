using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasOrangeTouchedGoal;
    public bool hasBlueTouchedGoal;
    bool hasWon;
    void Start()
    {
        hasBlueTouchedGoal = false;
        hasOrangeTouchedGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOrange")
        {
            hasOrangeTouchedGoal = true;
        }
        if (collision.gameObject.tag == "PlayerBlue")
        {
            hasBlueTouchedGoal = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool orangeCrossed, blueCrossed;

    // Start is called before the first frame update
    void Start()
    {
        orangeCrossed = false;
        blueCrossed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (orangeCrossed && blueCrossed)
        {
            GameManager.instance.GameWon();
        }
    }

    //Collision logic and kill here
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PlayerOrange")
        {
            orangeCrossed = true;
        }
        else if (other.tag == "PlayerBlue")
        {
            blueCrossed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerOrange")
        {
            orangeCrossed = false;
        }
        else if (other.tag == "PlayerBlue")
        {
            blueCrossed = false;
        }
    }

}

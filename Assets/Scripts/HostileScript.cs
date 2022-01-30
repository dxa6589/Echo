using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool isBlue;
    void Start()
    {
        if (this.tag == "Orange")
        {
            isBlue = false;
        }
        if (this.tag == "Blue")
        {
            isBlue = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.tag == "Orange")
        {
            isBlue = false;
            Physics2D.IgnoreLayerCollision(11,13);
        }
        if (this.tag == "Blue")
        {
            isBlue = true;
            Physics2D.IgnoreLayerCollision(12, 14);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if the player is orange and touches a orange object it will kill them
        if (collision.gameObject.tag == "PlayerOrange" && isBlue)
        {
            print("Destroy Orange");
            SceneManager.LoadScene("level1");
            Destroy(collision.gameObject);
        }
        //if the player is blue and touches a blue object it will kill them
        if (collision.gameObject.tag == "PlayerBlue" && !isBlue)
        {
            print("Destroy Blue");
            SceneManager.LoadScene("level1");
            Destroy(collision.gameObject);
        }
    }
}

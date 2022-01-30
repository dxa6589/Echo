
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class PulseScript : MonoBehaviour
{
    private float pulseSpeed;
    public Vector3 maxPulseRadius;
    public bool pulseActive;
    private bool pulseGrowing;
    public PlayerControls.playerColor color;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxPulseRadius = new Vector3(2f, 2f);
        pulseSpeed = 10f;
        pulseActive = true;
        pulseGrowing = true;
    }
    
    void PulseControls()
    {
        if (transform.localScale.y < maxPulseRadius.y && pulseGrowing == true)
        {
            transform.localScale += new Vector3(0.1f, 0.1f) * pulseSpeed * Time.deltaTime;
            //this.GetComponent<Light2D>().pointLightInnerRadius
        }
        else
        {
            
            pulseGrowing = false;
            transform.localScale -= new Vector3(0.1f, 0.1f) * pulseSpeed * Time.deltaTime;
            if (transform.localScale.y < 0.1)
            {
                Collider2D[] pingedObjs = Physics2D.OverlapCircleAll(transform.position,(maxPulseRadius.y+1.1f));
                if (pingedObjs.Length > 0)
                {
                    foreach (var pingedObj in pingedObjs)
                    {
                        print(pingedObj.name);
                        if (pingedObj.tag != "Player")
                        {
                            //Ping(pingedObj);
                            pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
                        }
                    }
                    pulseActive = false;
                    
                }
                Destroy(this.gameObject);


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        PulseControls();

    }

    void Ping(Collider2D pingedObj)
    {
        print("Pinging " + pingedObj.name);
        if (pingedObj.tag == "Blue" && gameManager.GetActivePlayer().tag == "PlayerBlue")
        {
            if (pingedObj.GetComponent<HostileScript>().isBlue == true)
            {
                pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            }
        }
        else if (pingedObj.tag == "Orange" && gameManager.GetActivePlayer().tag == "PlayerOrange")
        {
            if (pingedObj.GetComponent<HostileScript>().isBlue == false)
            {
                pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            }
            /*if (pingedObj.GetComponent<Enemy>().color == color)
            {
                pingedObj.GetComponent<Enemy>().Ping();
                pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            }*/
        }
    }
}

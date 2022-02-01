
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
    //private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                        if (pingedObj.tag != "Player")
                        {
                            Ping(pingedObj);
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
        //if right color glow, if enemy then ping
        if (pingedObj.tag == this.tag || pingedObj.tag == "Wall")
        {
            print("Triggering " + pingedObj.name);
            pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            if (pingedObj.GetComponent<Enemy>())
            {
                pingedObj.GetComponent<Enemy>().Ping();
                print("Pinging " + pingedObj.name);
            }
        }
    }
}

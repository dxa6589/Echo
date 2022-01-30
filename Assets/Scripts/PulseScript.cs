
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
    // Start is called before the first frame update
    void Start()
    {
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
                            Ping(pingedObj);
                            //pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
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
        if (pingedObj.tag == "Wall")
        {
            if (pingedObj.GetComponent<Wall>().color == color)
            {
                pingedObj.GetComponent<Wall>().Ping();
                pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            }
        }
        else if (pingedObj.tag == "Enemy")
        {
            if (pingedObj.GetComponent<Enemy>().color == color)
            {
                pingedObj.GetComponent<Enemy>().Ping();
                pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
            }
        }
        //pingedObj.GetComponentInChildren<Animator>().SetTrigger("TriggerGlow");
        pingedStore.Add(pingedObj);
    }

    void Unping(Collider2D pingedObj)
    {
        //pingedObj.GetComponent<SpriteRenderer>().color = Color.white;
        if (pingedObj.tag == "Pingable")
        {
            if (pingedObj.GetComponent<Wall>())
            {
                pingedObj.GetComponent<Wall>().Unping();
            }
            else if (pingedObj.GetComponent<Enemy>())
            {
                pingedObj.GetComponent<Enemy>().Unping();
            }
        }
        pingedStore.Remove(pingedObj);
    }
}

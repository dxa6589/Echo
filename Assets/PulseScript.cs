using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    private float pulseSpeed;
    public Vector3 maxPulseRadius;
    public bool pulseActive;
    private bool pulseGrowing;
    // Start is called before the first frame update
    void Start()
    {
        maxPulseRadius = new Vector3(6,6);
        pulseSpeed = 3f;
        pulseActive = true;
        pulseGrowing = true;
    }
    void PulseControls()
    {
        if (transform.localScale.y < maxPulseRadius.y && pulseGrowing == true)
        {
            transform.localScale += new Vector3(1, 1) * pulseSpeed * Time.deltaTime;
        }
        else
        {
            pulseGrowing = false;
            transform.localScale -= new Vector3(1, 1) * pulseSpeed * Time.deltaTime;
            if (transform.localScale.y < 1)
            {
                Collider2D[] pingedObjs = Physics2D.OverlapCircleAll(transform.position,maxPulseRadius.y);
                if (pingedObjs.Length > 0)
                {
                    foreach (var pingedObj in pingedObjs)
                    {
                        print(pingedObj.name);
                        if (pingedObj.tag != "Player")
                        {
                            pingedObj.GetComponent<SpriteRenderer>().color = Color.yellow;
                        }
                    }
                    pulseActive = false;
                    Destroy(this);
                }
                
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        PulseControls();
    }
}

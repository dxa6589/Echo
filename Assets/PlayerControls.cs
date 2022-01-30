using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    private float movementSpeed;
    [SerializeField] GameObject pulsePrefab;
    public bool isPlayerActive;
    void Start()
    {
        movementSpeed = 1f;
    }

    bool PulseActive()
    {
        if (GameObject.Find("EchoPulse(Clone)"))
        {
            PulseScript pulse = GameObject.Find("EchoPulse(Clone)").GetComponent<PulseScript>();
            if(pulse != null)
            {
                return pulse.pulseActive;
            }
        }
        return false;
    }
    void PlayerControl()
    {
        if (!PulseActive())
        {
            //Vertical Movement
            if (Input.GetKey(KeyCode.W))//up
            {
                transform.position += new Vector3(0, 1) * movementSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))//down
            {
                transform.position += new Vector3(0, -1) * movementSpeed * Time.deltaTime;
            }

            //Horizontal Movement
            if (Input.GetKey(KeyCode.D))//right
            {
                transform.position += new Vector3(1, 0) * movementSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))//left
            {
                transform.position += new Vector3(-1, 0) * movementSpeed * Time.deltaTime;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.F) && !PulseActive())
        {
            Pulse();
        }
    }
    void Pulse()
    {
        GameObject pulse = Instantiate(pulsePrefab,transform.position,Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {

        PlayerControl();
    }
}

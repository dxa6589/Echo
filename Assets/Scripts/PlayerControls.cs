using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    private float movementSpeed;
    [SerializeField] GameObject pulsePrefab;
    public bool isPlayerActive;
    private bool hasPlayed;
    private AudioSource audioSource;
    
    [SerializeField] Sprite playerUp;
    [SerializeField] Sprite playerBack;
    [SerializeField] Sprite playerRight;
    [SerializeField] Sprite playerLeft;

    //[SerializeField] GameManager gameManager;
    void Start()
    {
        movementSpeed = 2f;
        audioSource = GetComponent<AudioSource>();
    }

    bool PulseActive()
    {
        if (GameObject.Find("EchoPulseBlue(Clone)"))
        {
            PulseScript pulse = GameObject.Find("EchoPulseBlue(Clone)").GetComponent<PulseScript>();
            if(pulse != null)
            {
                return pulse.pulseActive;
            }
        }
        if (GameObject.Find("EchoPulseOrange(Clone)"))
        {
            PulseScript pulse = GameObject.Find("EchoPulseOrange(Clone)").GetComponent<PulseScript>();
            if (pulse != null)
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
                this.GetComponent<SpriteRenderer>().sprite = playerUp;
            }
            if (Input.GetKey(KeyCode.S))//down
            {
                transform.position += new Vector3(0, -1) * movementSpeed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().sprite = playerBack;
            }

            //Horizontal Movement
            if (Input.GetKey(KeyCode.D))//right
            {
                transform.position += new Vector3(1, 0) * movementSpeed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().sprite = playerRight;
            }
            if (Input.GetKey(KeyCode.A))//left
            {
                transform.position += new Vector3(-1, 0) * movementSpeed * Time.deltaTime;
                this.GetComponent<SpriteRenderer>().sprite = playerLeft;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.E) && !PulseActive())
        {
            audioSource.Play();
            Pulse();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.instance.SwapPlayers();
        }
    }
    void Pulse()
    {
        GameObject pulse = Instantiate(pulsePrefab,transform.position,Quaternion.identity);
        if (tag == "PlayerOrange") {
            pulse.GetComponent<PulseScript>().tag = "Orange";
        }
        else if (tag == "PlayerBlue") {
            pulse.GetComponent<PulseScript>().tag = "Blue";
        }
        Debug.Log("Created pulse with tag: "+ pulse.GetComponent<PulseScript>().tag);
    }

    public void Kill()
    {
        string color = tag == "PlayerOrange" ? "orange" : "blue";
        Debug.Log("Oh no! The " + color+" dolphin was killed!");
        GameManager.instance.GameLost();
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerControl();
    }
}

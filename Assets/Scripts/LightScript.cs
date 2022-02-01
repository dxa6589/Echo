using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public bool isEnemyGlowing;
    // Start is called before the first frame update
    void Start()
    {
        isEnemyGlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IsGlowingTrue()
    {
        isEnemyGlowing = true;
    }
    public void IsGlowingFalse()
    {
        isEnemyGlowing = false;
    }
}

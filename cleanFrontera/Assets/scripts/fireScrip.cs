using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScrip : MonoBehaviour
{
    public float TIMER = 5.0f;
    public float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //instantiate facing back and forward at the same time
            timer = TIMER;
        }
        
    }
}

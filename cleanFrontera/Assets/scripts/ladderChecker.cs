using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderChecker : MonoBehaviour
{
    public bool isOnLadder = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "randomCollider")
        {
            Debug.Log("here Working");
            isOnLadder = true;
        }
        else
        {
            isOnLadder = false;
        }
    }
    
}

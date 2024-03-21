using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFire : MonoBehaviour
{
    public int fireWindow = 0;
    public GameObject[] windows;
    // Start is called before the first frame update
    void Start()
    {
        fireWindow = Random.Range(0, 6);
        windows[fireWindow].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

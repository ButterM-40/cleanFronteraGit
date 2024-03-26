using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //check for at top of ladder and prevent from going more up (put another collision box at the top or near top)
    //randomize layout


    private float speed = 5.0f;
    private bool onLadder = false;
    private bool onTopLadder = false;
    private Rigidbody myRG;
    public GameObject water;


    public int negGravity = 0;
    public int jumpForce = 0;

    public groundCheck GC;


    public Animator theAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRG = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(!onLadder)
        {
            gameObject.transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
            if(Input.GetKey(KeyCode.F)){
                //Debug.Log("On");
                water.SetActive(true);
            }else water.SetActive(false);
        }
        else
        {
            if(GC.onGround && onLadder && vertical < 0) //prevents from cliping into ground
            {
                vertical = 0;
            }
            if(onTopLadder && vertical > 0)
            {
                Debug.Log("vertifcal 0 ");
                vertical = 0;
            }

            gameObject.transform.position += new Vector3(horizontal,vertical, 0) * speed * Time.deltaTime;
        }

        if(onLadder)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            //model facing away from camera
        }

        else if(horizontal<0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
            //face left
        }
        else if(horizontal>0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
            //face right
        }


        if (!GC.onGround && !onLadder) // if in the air
        {
            
            
            
            myRG.useGravity = true;
            myRG.constraints = ~RigidbodyConstraints.FreezePositionY;
            myRG.AddForce(transform.up * -10);
        }
        else if (GC.onGround && !onLadder && Input.GetKeyDown("space")) //ground and not ladder and press space frame one
        {
            
            myRG.constraints = ~RigidbodyConstraints.FreezePositionY; //remove freeze in position y
            myRG.AddForce(0, 1000, 0, ForceMode.Acceleration); //adds acceleration
        }
        
        else if (onLadder)//if on ladder attach to it
        {
           
            myRG.constraints = RigidbodyConstraints.FreezeAll;
        }

        if(onLadder)
        {
            theAnimator.SetBool("onLadder", true);
        }
        else
        {
            theAnimator.SetBool("onLadder", false);
        }

        if(GC.onGround)
        {
            theAnimator.SetBool("inAir", false);
        }
        else if(!onLadder)
        {
            theAnimator.SetBool("inAir", true);
        }


        if(Mathf.Abs(horizontal) > 0)
        {
            theAnimator.SetBool("moving", true);
        }
        else if(Mathf.Abs(horizontal) == 0)
        {
            theAnimator.SetBool("moving", false);
        }

        if (Mathf.Abs(vertical) > 0 && onLadder)
        {
            theAnimator.SetBool("movingLadder", true);
        }
        else if (Mathf.Abs(vertical) == 0 && onLadder)
        {
            theAnimator.SetBool("movingLadder", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
       
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = true;
            myRG.useGravity = false;
            

        }

        if(other.gameObject.tag == "topLadder")
        {
            onTopLadder = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }

        if (other.gameObject.tag == "topLadder")
        {
            onTopLadder = false;
        }


    }
}

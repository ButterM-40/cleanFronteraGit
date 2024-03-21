using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerScript : MonoBehaviour
{
    public Transform[] parentArray;
    private int addtoPosition = 0;
    // Start is called before the first frame update
    void Awake()
    {
        int thisLadder = -1;
        for (int i = 0; i < parentArray.Length; i++)
        {
            int j = 0;
            int ladderBelow = thisLadder;

            addtoPosition = 0;
            while (parentArray[i].childCount != 0)
            {
                int newHome = Random.Range(0, (parentArray[i].childCount));
                Transform newChild = parentArray[i].GetChild(newHome);
                newChild.parent = null;
                newChild.position = new Vector3(newChild.position.x + addtoPosition, newChild.position.y, newChild.position.z);

                if (newChild.tag == "ladderPrefab")
                {
                    thisLadder = j;
                }

                if (j == ladderBelow)
                {
                    newChild.position = new Vector3(newChild.position.x -3, newChild.position.y, newChild.position.z);
                    addtoPosition -= 3;
                }

                j++;
                addtoPosition -= 3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

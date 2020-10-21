using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyBehavior : GeneralUnitBehavior
{
    public GameObject mainTarget; //stores GameObject of current target.
    public GameObject nexusTarget; //stores GameObject of the Nexus.
    private Vector2 targetLocation; //used to target mainTarget.
    private bool shouldMove = true; //defines if object should or not move.
    public float followDistance = 8.0f; //variable that defines range for target acquisition.
    
    // Start is called before the first frame update
    void Start()
    {
        nexusTarget = GameObject.Find("NexusBase");
    }

    void FixedUpdate()
    {
        if (mainTarget == null && shouldMove) //tests if main target exists, if not, attributes Nexus. Prevents targeting a destroyed object.
        {
            mainTarget = nexusTarget;
            targetLocation = new Vector2(mainTarget.transform.position.x, mainTarget.transform.position.y); //gets Target location.
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, moveSpeed / 30); //moves Unit towards target.
        }
        if (shouldMove) //tests if it should move towards nexus in case first if didn't work.
        {
            targetLocation = new Vector2(mainTarget.transform.position.x, mainTarget.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetLocation, moveSpeed / 30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] myTargets = GameObject.FindGameObjectsWithTag("AlliedUnit"); // gets all Allied Units and add them to an array.
        float[] targetDistances = new float[myTargets.Length];
        for (int i = 0; i < myTargets.Length; i++)//attributes the distance of each Allied unit to an array
        {
            targetDistances[i] = (myTargets[i].transform.position - transform.position).sqrMagnitude;
        }
        Array.Sort(targetDistances); //sorts given array to provice index 0 with the minimum distance.
        if (myTargets != null && myTargets.Length > 0) //verifies that the arrays are not empty.
        {
            if (targetDistances[0] < followDistance) //verifies if minimum is followable.
            {
                foreach (GameObject target in myTargets)//tests if object distance is the minimum.
                {
                    if ((target.transform.position - transform.position).sqrMagnitude == targetDistances[0]) //which object has min distance.
                    {
                        mainTarget = target; //defines such object as target.
                        break;
                    }
                }
            }
            if (targetDistances[0] > followDistance) //if the target distance to nearest unit exceeds followDistance, goes back to nexus.
            {
                mainTarget = nexusTarget;
            }
        }
        else //refocus to nexus if arrays are empty.
        {
            mainTarget = nexusTarget;
        }
    }

    void OnTriggerStay2D(Collider2D collisionTarget) //if object stays connected to target it stops moving.
    {
        if (collisionTarget == mainTarget.GetComponent<Collider2D>())
        {
            shouldMove = false;
            //Debug.Log("I " + gameObject.name + " am colliding with my target.");
        }
    }
    void OnTriggerExit2D(Collider2D collisionTarget) //if object loses all his collisions, he goes back to moving.
    {
        shouldMove = true;
        //Debug.Log("I " + gameObject.name + " am NOT colliding with my target.");
    }
}

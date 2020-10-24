using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AllyBehavior : GeneralUnitBehavior
{
	public bool isSpawned;
    public GameObject nexusTarget; //stores GameObject of the Nexus, in case of allies it's the Nexus Regroup Area.
    private Vector2 targetLocation; //used to target mainTarget.
    public float followDistance = 24.0f; //variable that defines range for target acquisition.
    public SummoningEffect summonEffect;
    public bool particleEmmited;

    // Start is called before the first frame update
    void Start()
    {
        isSpawned = false;
        nexusTarget = GameObject.Find("Nexus Regroup");
        mainTarget = nexusTarget;
    }

    new void FixedUpdate()
    {
         if (isSpawned)
         {  
            base.FixedUpdate();
            if (particleEmmited == false)
            {
                Instantiate(summonEffect, transform.position, transform.rotation);
                particleEmmited = true;
            }
            
            if (shouldMove == false) { 
}
            {
                if (mainTarget == null) //verifies if the ally has a target if not, assign nexus point to it.
                {
                    mainTarget = nexusTarget;
                    shouldMove = true;
                }
            }
            if (mainTarget == null && shouldMove && startMove) //tests if main target exists, if not, attributes Nexus. Prevents targeting a destroyed object.
            {
                mainTarget = nexusTarget;
                targetLocation = new Vector2(mainTarget.transform.position.x, mainTarget.transform.position.y); //gets Target location.
                transform.position = Vector2.MoveTowards(transform.position, targetLocation, moveSpeed * Time.deltaTime); //moves Unit to target
            }
            if (shouldMove && startMove) //tests if it should move towards nexus in case first if didn't work.
            {
                targetLocation = new Vector2(mainTarget.transform.position.x, mainTarget.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, targetLocation, moveSpeed * Time.deltaTime);
            }
          }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] myTargets = GameObject.FindGameObjectsWithTag("EnemyUnit"); // gets all Enemy Units and add them to an array.
        float[] targetDistances = new float[myTargets.Length];
        for (int i = 0; i < myTargets.Length; i++)//attributes the distance of each Enemy unit to an array
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
                        if (mainTarget != target)
                        {
                            shouldMove = true;
                        }
                        mainTarget = target; //defines such object as target.
                        break;
                    }
                }
            }
            if (targetDistances[0] > followDistance) //if the target distance to nearest unit exceeds followDistance, goes back to regroup.
            {
                mainTarget = nexusTarget;
            }
        }
        else //refocus to nexus regroup if arrays are empty.
        {
            mainTarget = nexusTarget;
        }
    }

    new void OnTriggerStay2D(Collider2D collisionTarget) //if object stays connected to target it stops moving.
    {
        if (collisionTarget.tag == mainTarget.tag)
        {
            base.OnTriggerStay2D(collisionTarget);
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
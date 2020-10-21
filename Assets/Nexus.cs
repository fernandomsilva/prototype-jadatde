using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void NexusHit (int damage)
    {
        playerCharacter.GetComponent<PlayerStats>().LoseHealth(damage);
        Debug.Log(playerCharacter.GetComponent<PlayerStats>().currentHealth + " health remains on the nexus.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

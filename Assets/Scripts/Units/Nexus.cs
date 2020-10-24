using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject loseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnHit (int damage)
    {
        playerCharacter.GetComponent<PlayerStats>().LoseHealth(damage);
        //Debug.Log(playerCharacter.GetComponent<PlayerStats>().currentHealth + " health remains on the nexus.");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter.GetComponent<PlayerStats>().currentHealth <= 0)
        {
            loseText.GetComponent<Text>().text = "You Lose!\nPress R to reset and try again.";
            Time.timeScale = 0;
        }
    }
}

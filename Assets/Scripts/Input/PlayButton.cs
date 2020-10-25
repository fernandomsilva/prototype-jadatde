using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;  
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject countdown;
    public GameObject enemySpawner;
    public GameObject enemyAlive;
    public GameObject winText;
    public bool hasStarted;
    public bool waveCleared;
    public float timeUntil;
    public int numberWaves;
    public int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        countdown.GetComponent<Text>().text = "Press Play to Start";
        timeUntil = 5.0f;
        numberWaves = 5;
        currentWave = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        GameObject[] enemyAlive = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if (enemyAlive.Length >= 1)
        {
            waveCleared = false;
        }
        else
        {
            waveCleared = true;
        }

        if (hasStarted == true && currentWave <= numberWaves && waveCleared == true)
        {
            if (timeUntil >= 0)
            {
                countdown.GetComponent<Text>().text = "Wave " + currentWave + "/" + numberWaves + " in " + timeUntil.ToString("F2") + "s";
                timeUntil -= Time.deltaTime;
                //Debug.Log(timeUntil);
            }
            if (timeUntil < 0)
            {
                countdown.GetComponent<Text>().text = "Wave " + currentWave + "/" + numberWaves + " is here!";
                enemySpawner.GetComponent<EnemySpawner>().SpawnEnemies(currentWave);
                timeUntil = 5.0f;
                waveCleared = false;
                currentWave++;
            }
        }
        //if (currentWave - 1 == numberWaves && waveCleared == false)
        //{
        //    countdown.GetComponent<Text>().text = "Wave " + (currentWave-1) + "/" + numberWaves + " is here!";
        //}
        if (currentWave - 1 == numberWaves && waveCleared == true)
        {
            countdown.GetComponent<Text>().text = "All cleared!";
            winText.GetComponent<Text>().text = "You Win!\n Press R to reset and play again.";
            Time.timeScale = 0;
        }

    }

    public void OnMouseDown()
    {
        hasStarted = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
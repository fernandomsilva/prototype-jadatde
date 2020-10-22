using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
         if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}

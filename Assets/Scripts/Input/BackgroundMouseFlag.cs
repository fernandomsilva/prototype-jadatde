using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMouseFlag : MonoBehaviour
{
	public bool mouseIsOver;
	
    // Start is called before the first frame update
    void Start()
    {
        mouseIsOver = false;
    }
	
	void OnMouseOver()
	{
		mouseIsOver = true;
	}
	
	void OnMouseExit()
	{
		mouseIsOver = false;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMouseEvents : MonoBehaviour
{
	private bool selected;
	private Vector3 mousePositionLastFrame;
	private Vector3 myHUDPosition;
	
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
		myHUDPosition = transform.position;
    }
	
	void OnMouseUp()
	{
		if (selected)
		{
			selected = false;
			
			transform.position = myHUDPosition;
		}
	}
	
	void OnMouseDown()
	{
		selected = true;
		
		mousePositionLastFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void OnMouseDrag()
	{
		if (selected)
		{
			Vector3 moveDistance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePositionLastFrame;
			
			transform.position += moveDistance;
			
			mousePositionLastFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

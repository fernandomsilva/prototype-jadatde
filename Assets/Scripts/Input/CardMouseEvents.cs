using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMouseEvents : MonoBehaviour
{
	private PlayerStats playerStatsScript;
	private BackgroundMouseFlag backgroundMouseFlag;
	
	private bool selected;
	private Vector3 mousePositionLastFrame;
	private Vector3 myHUDPosition;
	
	private CardStats myCardStats;
	
    // Start is called before the first frame update
    void Start()
    {
		playerStatsScript = GameObject.Find("Player").GetComponent<PlayerStats>();
		backgroundMouseFlag = GameObject.Find("Field Background").GetComponent<BackgroundMouseFlag>();
		
        selected = false;
		myHUDPosition = transform.position;
		
		myCardStats = GetComponent<CardStats>();
    }
	
	void OnMouseUp()
	{
		if (selected)
		{
			selected = false;
			//backgroundMouseFlag.mouseIsOver = false;
			
			transform.position = myHUDPosition;
			
			playerStatsScript.hideManaToSpend();
		}
	}
	
	void OnMouseDown()
	{
		selected = true;
		//backgroundMouseFlag.mouseIsOver = false;
		
		mousePositionLastFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void OnMouseDrag()
	{
		if (selected)
		{
			Vector3 currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 moveDistance = currentMouseWorldPosition - mousePositionLastFrame;
			
			//currentMouseWorldPosition.z = 0.0f;
			
			transform.position += moveDistance;			
			mousePositionLastFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			playerStatsScript.displayManaToSpend(myCardStats.cost);
			
			if (backgroundMouseFlag.mouseIsOver)
			{
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

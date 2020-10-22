using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMouseEvents : MonoBehaviour
{
	private PlayerStats playerStatsScript;
	private BackgroundMouseFlag backgroundMouseFlag;
	public GameObject areaOfEffect;
	
	private bool selected;
	private Vector3 mousePositionLastFrame;
	private Vector3 myHUDPosition;
	
	private CardStats myCardStats;
	private Renderer myRenderer;
	
    // Start is called before the first frame update
    void Start()
    {
		playerStatsScript = GameObject.Find("Player").GetComponent<PlayerStats>();
		backgroundMouseFlag = GameObject.Find("Field Background").GetComponent<BackgroundMouseFlag>();
		
		//if (areaOfEffect)
		//{
			//areaOfEffect.SetActive(false);
		//}
		
        selected = false;
		myHUDPosition = transform.position;
		
		myCardStats = GetComponent<CardStats>();
		myRenderer = GetComponent<Renderer>();
    }
	
	void OnMouseUp()
	{
		if (selected)
		{
			selected = false;
			
			transform.position = myHUDPosition;
			
			playerStatsScript.hideManaToSpend();
			
			myRenderer.enabled = true;
			
			areaOfEffect.SetActive(false);
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
			Vector3 currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 moveDistance = currentMouseWorldPosition - mousePositionLastFrame;
			
			currentMouseWorldPosition.z = 0.0f;
			
			transform.position += moveDistance;			
			mousePositionLastFrame = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			playerStatsScript.displayManaToSpend(myCardStats.cost);
			
			if (backgroundMouseFlag.mouseIsOver)
			{
				myRenderer.enabled = false;
				
				if (myCardStats.type == "Spell")
				{
					areaOfEffect.transform.position = currentMouseWorldPosition;
					
					if (areaOfEffect.activeSelf == false)
					{
						Debug.Log("I'm active");
						Debug.Log(areaOfEffect.transform.position);
						areaOfEffect.SetActive(true);
						areaOfEffect.transform.localScale = new Vector3(myCardStats.intensity, myCardStats.intensity, 1.0f);
					}
				}
			}
			else
			{
				areaOfEffect.SetActive(false);
				myRenderer.enabled = true;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

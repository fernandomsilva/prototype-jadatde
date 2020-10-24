using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMouseEvents : MonoBehaviour
{
	private PlayerStats playerStatsScript;
	private BackgroundMouseFlag backgroundMouseFlag;
	public GameObject areaOfEffect;
	public GameObject alliedUnitPrefab;
	
	private bool selected;
	private Vector3 mousePositionLastFrame;
	private Vector3 myHUDPosition;
	
	private CardStats myCardStats;
	private CardEffects myCardEffects;
	private Renderer myRenderer;
	
	private List<GameObject> listOfAlliedUnitsToSpawn;
	
    // Start is called before the first frame update
    void Start()
    {
		playerStatsScript = GameObject.Find("Player").GetComponent<PlayerStats>();
		backgroundMouseFlag = GameObject.Find("Field Background").GetComponent<BackgroundMouseFlag>();
		
        selected = false;
		myHUDPosition = transform.position;
		
		myCardStats = GetComponent<CardStats>();
		myCardEffects = GetComponent<CardEffects>();
		myRenderer = GetComponent<Renderer>();
		
		listOfAlliedUnitsToSpawn = new List<GameObject>();
    }
	
	void OnMouseUp()
	{
		if (selected)
		{
			selected = false;
			
			transform.position = myHUDPosition;
			
			myRenderer.enabled = true;
			
			playerStatsScript.hideManaToSpend();
			
			if (playerStatsScript.currentMana >= myCardStats.cost && backgroundMouseFlag.mouseIsOver)
			{
				playerStatsScript.SpendMana(myCardStats.cost);

				if (myCardStats.type == "Spell")
				{			
					areaOfEffect.layer = 0; // Layer 0 == Default
					Collider2D[] overlappingColliders = new Collider2D[GameObject.FindGameObjectsWithTag("EnemyUnit").Length * 2];
					
					areaOfEffect.GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), overlappingColliders);
					
					List<GameObject> enemiesInRange = new List<GameObject>();
					
					for (int i=0; i<overlappingColliders.Length; i++)
					{						
						if (overlappingColliders[i])
						{
							if (!overlappingColliders[i].isTrigger && overlappingColliders[i].gameObject.tag == "EnemyUnit")
							{
								enemiesInRange.Add(overlappingColliders[i].gameObject);
							}
						}
					}
					
					if (enemiesInRange.Count > 0)
					{
						myCardEffects.RunCardEffects(myCardStats, enemiesInRange);
					}

					areaOfEffect.SetActive(false);
				}
				
				if (listOfAlliedUnitsToSpawn.Count > 0)
				{	
					for (int i=0; i<listOfAlliedUnitsToSpawn.Count; i++)
					{
						listOfAlliedUnitsToSpawn[i].GetComponent<AllyBehavior>().isSpawned = true;
						listOfAlliedUnitsToSpawn[i].layer = 0; // Layer 0 == Default
						listOfAlliedUnitsToSpawn[i].GetComponent<AllyBehavior>().Summoned(myCardStats.health, myCardStats.attackDamage, myCardStats.attackSpeed, myCardStats.moveSpeed);
					}

					listOfAlliedUnitsToSpawn.Clear();
				}
				
				myCardStats.toRemove = true;
			}
			else
			{
				if (myCardStats.type == "Spell")
				{
					areaOfEffect.SetActive(false);
				}
				else
				{
					if (listOfAlliedUnitsToSpawn.Count > 0)
					{
						for (int i=0; i<listOfAlliedUnitsToSpawn.Count; i++)
						{
							Destroy(listOfAlliedUnitsToSpawn[i].gameObject);
						}
						
						listOfAlliedUnitsToSpawn.Clear();
					}
				}
			}
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
						areaOfEffect.SetActive(true);
						areaOfEffect.layer = 8; // Layer 8 == Effects
						areaOfEffect.transform.localScale = new Vector3(myCardStats.intensity, myCardStats.intensity, 1.0f);
					}
				}
				else 
				{
					if (listOfAlliedUnitsToSpawn.Count == 0)
					{
						float angleBetweenUnits = 360.0f / ((float) myCardStats.amount);
						float radius = 0.5f;
						
						Vector3 offsetFromMouse = new Vector3(radius, radius, 0.0f);
						Quaternion rotation;
						
						for (int i=0; i<myCardStats.amount; i++)
						{
							rotation = Quaternion.Euler(0, 0, angleBetweenUnits * i);
							listOfAlliedUnitsToSpawn.Add(Instantiate(alliedUnitPrefab));
							listOfAlliedUnitsToSpawn[i].transform.position = currentMouseWorldPosition + (rotation * offsetFromMouse);
							listOfAlliedUnitsToSpawn[i].layer = 8; // Layer Effects == 8
							listOfAlliedUnitsToSpawn[i].GetComponent<AllyBehavior>().isSpawned = false;
						}
					}
					else
					{
						for (int i=0; i<myCardStats.amount; i++)
						{
							listOfAlliedUnitsToSpawn[i].transform.position += moveDistance;
						}
					}
				}
			}
			else
			{
				areaOfEffect.SetActive(false);
		
				if (listOfAlliedUnitsToSpawn.Count > 0)
				{
					for (int i=0; i<listOfAlliedUnitsToSpawn.Count; i++)
					{
						GameObject.Destroy(listOfAlliedUnitsToSpawn[i]);
					}
					
					listOfAlliedUnitsToSpawn.Clear();
				}
				
				myRenderer.enabled = true;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
    }
}

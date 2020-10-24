using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
	public CardDatabase cardDatabase;
	
	public string cardName;
	public string type;
	public string element;
	public string summonType;
	public int health;
	public int attackDamage;
	public float attackSpeed;
	public float moveSpeed;
	public int amount;
	public int damage;
	public float magnitude;
	public float intensity;
	public int cost;
	public string effect1;
	public string effect2;
	
	public bool toRemove;
	
	public SpriteRenderer mySpriteRenderer;
	private Sprite defaultCardSprite;
	
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
		defaultCardSprite = Instantiate(mySpriteRenderer.sprite);
		
		toRemove = false;
    }
	
	public void ResetCard()
	{
		mySpriteRenderer.sprite = defaultCardSprite;
		
		cardName = "";
		type = "";
		element = "";
		summonType = "";
		health = 0;
		attackDamage = 0;
		attackSpeed = 0.0f;
		moveSpeed = 0.0f;
		amount = 0;
		damage = 0;
		magnitude = 0.0f;
		intensity = 0.0f;
		cost = 0;
		effect1 = "";
		effect2 = "";
		
		toRemove = false;
	}

	public void LoadCard(string newName)
	{
		cardName = newName;
		if (newName != "")
		{
			LoadCardImage();
			ParseCardAttributes(cardDatabase.GetCardAttributes(cardName));
		}
	}
	
	void LoadCardImage()
	{
		mySpriteRenderer.sprite = cardDatabase.GetCardSprite(cardName);
	}
	
	void ParseCardAttributes(Dictionary<string, string> attributeDict)
	{
		foreach (string key in attributeDict.Keys)
		{
			switch (key)
			{
				case "type":
					type = attributeDict[key];
					break;
				case "element":
					element = attributeDict[key];
					break;
				case "summonType":
					summonType = attributeDict[key];
					break;
				case "health":
					health = int.Parse(attributeDict[key]);
					break;
				case "attackDamage":
					attackDamage = int.Parse(attributeDict[key]);
					break;
				case "attackSpeed":
					attackSpeed = float.Parse(attributeDict[key]);
					break;
				case "moveSpeed":
					moveSpeed = float.Parse(attributeDict[key]);
					break;
				case "amount":
					amount = int.Parse(attributeDict[key]);
					break;
				case "damage":
					damage = int.Parse(attributeDict[key]);
					break;
				case "magnitude":
					magnitude = float.Parse(attributeDict[key]);
					break;
				case "intensity":
					intensity = float.Parse(attributeDict[key]);
					break;
				case "cost":
					cost = int.Parse(attributeDict[key]);
					break;
				case "effect1":
					effect1 = attributeDict[key];
					break;
				case "effect2":
					effect2 = attributeDict[key];
					break;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
	public int attackSpeed;
	public int moveSpeed;
	public int amount;
	public int damage;
	public int magnitude;
	public int intensity;
	public int cost;
	
	private SpriteRenderer mySpriteRenderer;
	
	
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
		
    }

	public void loadCard(string newName)
	{
		cardName = newName;
		LoadCardImage();
	}
	
	void LoadCardImage()
	{
		mySpriteRenderer.sprite = cardDatabase.GetCardSprite(cardName);
		ParseCardAttributes(cardDatabase.GetCardAttributes(cardName));
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
					attackSpeed = int.Parse(attributeDict[key]);
					break;
				case "moveSpeed":
					moveSpeed = int.Parse(attributeDict[key]);
					break;
				case "amount":
					amount = int.Parse(attributeDict[key]);
					break;
				case "damage":
					damage = int.Parse(attributeDict[key]);
					break;
				case "magnitude":
					magnitude = int.Parse(attributeDict[key]);
					break;
				case "intensity":
					intensity = int.Parse(attributeDict[key]);
					break;
				case "cost":
					cost = int.Parse(attributeDict[key]);
					break;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

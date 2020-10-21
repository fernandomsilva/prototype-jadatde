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
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

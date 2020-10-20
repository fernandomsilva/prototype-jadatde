using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
	public CardDatabase cardDatabase;
	
	public string cardName;
	public string type;
	public string element;
	public int HP;
	public int attack;
	public int attackSpeed;
	public int moveSpeed;
	public int amount;
	public int damage;
	public int area;
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
		loadCardImage();
	}
	
	void loadCardImage()
	{
		mySpriteRenderer.sprite = cardDatabase.GetCardSprite(cardName);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

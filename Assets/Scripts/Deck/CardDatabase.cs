using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
	public Sprite[] cardSprites;
	
    // Start is called before the first frame update
    void Start()
    {
        cardSprites = Resources.LoadAll<Sprite>("Cards/");		
    }
	
	public Sprite GetCardSprite(string cardName)
	{
		foreach (Sprite card in cardSprites)
		{
			Debug.Log(card.name);
			if (card.name == cardName)
			{
				return card;
			}
		}
		
		return null;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

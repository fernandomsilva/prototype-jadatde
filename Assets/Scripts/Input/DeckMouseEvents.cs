using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMouseEvents : MonoBehaviour
{
	public GameObject cards;
	
	private CardStats[] cardSlots;
	private int maxHandSize;
	
	private string[] deck = {"Summon Footman", "Throw Fireball", "Freeze Enemies"};
	
    // Start is called before the first frame update
    void Start()
    {
        cardSlots = cards.GetComponentsInChildren<CardStats>();
		maxHandSize = 5;
		
		//Debug.Log(NumberOfCardsInHand());
    }
	
	int NumberOfCardsInHand()
	{
		int count = 0;
		
		foreach (CardStats card in cardSlots)
		{
			if (card.cardName != "")
			{
				count += 1;
			}
			else
			{
				break;
			}
		}
		
		return count;
	}
	
	void OnMouseDown()
	{
		int handLength = NumberOfCardsInHand();
		
		if (handLength < maxHandSize)
		{
			int randomValue = Random.Range(0, 3);
			
			cardSlots[handLength].loadCard(deck[randomValue]);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

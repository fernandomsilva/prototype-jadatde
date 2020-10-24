using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMouseEvents : MonoBehaviour
{
	public GameObject cards;
	public PlayerStats playerStats;
	public int cardDrawMPCost;
	
	private CardStats[] cardSlots;
	private int maxHandSize;
	
	private string[] deck = {"Summon Footman", "Throw Fireball", "Freeze Enemies"};
	
    // Start is called before the first frame update
    void Start()
    {
        cardSlots = cards.GetComponentsInChildren<CardStats>();
		maxHandSize = 5;
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
		
		if (handLength < maxHandSize && playerStats.currentMana >= cardDrawMPCost)
		{
			int randomValue = Random.Range(0, 3);
		
			playerStats.SpendMana(cardDrawMPCost);
			cardSlots[handLength].LoadCard(deck[randomValue]);
		}
	}
	
	int NumberOfCardsToRemove()
	{
		int count = 0;
		
		foreach (CardStats card in cardSlots)
		{
			if (card.toRemove)
			{
				count += 1;
			}
		}
		
		return count;
	}
	
	void RemoveCards()
	{	
		if (NumberOfCardsToRemove() > 0)
		{
			for (int i=0; i<maxHandSize-1; i++)
			{
				if (cardSlots[i].toRemove)
				{
					for (int j=i+1; j<maxHandSize; j++)
					{
						cardSlots[j-1].ResetCard();
						cardSlots[j-1].LoadCard(cardSlots[j].cardName);
					}
					
					cardSlots[maxHandSize-1].ResetCard();
				}
			}
			if (cardSlots[maxHandSize-1].toRemove)
			{
				cardSlots[maxHandSize-1].ResetCard();
			}
		}		
	}

    // Update is called once per frame
    void Update()
    {
		RemoveCards();
    }
}

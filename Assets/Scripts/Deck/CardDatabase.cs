using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
	public TextAsset cardDataFile;
	
	private Sprite[] cardSprites;
	private Dictionary<string, Dictionary<string, string>> cardAttributes;
	
	// Start is called before the first frame update
    void Start()
    {
		
        cardSprites = Resources.LoadAll<Sprite>("Cards/");
		cardAttributes = new Dictionary<string, Dictionary<string, string>>();

		PopulateCardAttributesFromFileContents(cardDataFile.text);
    }

	void PopulateCardAttributesFromFileContents(string fileContents)
	{
		foreach (string cardDefinition in fileContents.Split('\n'))
		{
			if (cardDefinition != "")
			{
				string[] card = cardDefinition.Split('|');
				Dictionary<string, string> attributes = new Dictionary<string, string>();
				
				foreach (string attributeValues in card[1].Split(','))
				{
					string[] values = attributeValues.Split(':');
					
					attributes.Add(values[0], values[1]);
				}
				
				cardAttributes.Add(card[0], attributes);
			}
		}
	}
	
	public Sprite GetCardSprite(string cardName)
	{
		foreach (Sprite card in cardSprites)
		{
			if (card.name == cardName)
			{
				return card;
			}
		}
		
		return null;
	}
	
	public Dictionary<string, string> GetCardAttributes(string cardName)
	{
		return cardAttributes[cardName];
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

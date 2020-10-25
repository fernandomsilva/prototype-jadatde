using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int currentHealth;
	public int maxHealth;
	public int currentMana;
	public int maxMana;
	
	public float manaRegenSpeed;
	
	public GameObject healthBar;
	private float healthBarFullLength;
	private float healthBarOriginalX;
	
	public GameObject manaBar;
	public GameObject manaToSpend;
    public GameObject gameRun;
	private SpriteRenderer manaBarSpriteRenderer;
	private SpriteRenderer manaToSpendSpriteRenderer;
	private float manaBarFullLength;
	private float manaBarOriginalX;
	
	private float accumulatedManaRegen;
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		currentMana = maxMana;
		
		healthBarFullLength = healthBar.transform.localScale.x;
		healthBarOriginalX = healthBar.transform.position.x;
		manaBarFullLength = manaBar.transform.localScale.x;
		manaBarOriginalX = manaBar.transform.position.x;
		manaBarSpriteRenderer = manaBar.GetComponent<SpriteRenderer>();
		manaToSpendSpriteRenderer = manaToSpend.GetComponent<SpriteRenderer>();
    }

	public void LoseHealth(int quantity)
	{
		currentHealth -= quantity;
		
		UpdateBar(healthBar, (float) currentHealth, (float) maxHealth, healthBarOriginalX, healthBarFullLength);
	}

	public void SpendMana(int quantity)
	{
		currentMana -= quantity;
		
		UpdateBar(manaBar, (float) currentMana, (float) maxMana, manaBarOriginalX, manaBarFullLength);
	}

	void UpdateBar(GameObject bar, float currentValue, float maxValue, float originalX, float fullLength)
	{
		float factor = currentValue / maxValue;
		float newScaleX = factor * fullLength;
		float translateX = -1 * ((1 - factor) * fullLength) / 2;
		
		bar.transform.localScale = new Vector3(newScaleX, bar.transform.localScale.y, bar.transform.localScale.z);
		
		bar.transform.position = new Vector3(originalX, bar.transform.position.y, bar.transform.position.z);
		bar.transform.Translate(translateX, 0.0f, 0.0f);
	}
	
	public void displayManaToSpend(int quantity)
	{
		float factor = ((float) quantity) / ((float) maxMana);
		float newScaleX = factor * manaBarFullLength;
		
		manaToSpend.transform.localScale = new Vector3(newScaleX, manaToSpend.transform.localScale.y, manaToSpend.transform.localScale.z);
		manaToSpend.transform.position = manaBar.transform.position;
		manaToSpend.transform.Translate((manaBarSpriteRenderer.bounds.size.x / 2.0f) - (manaToSpendSpriteRenderer.bounds.size.x / 2.0f), 0.0f, 0.0f);
		
		manaToSpend.SetActive(true);
	}
	
	public void hideManaToSpend()
	{
		manaToSpend.SetActive(false);
	}

	void FixedUpdate()
	{
        if (currentMana < maxMana && gameRun.GetComponent<PlayButton>().hasStarted == true)
		{
			accumulatedManaRegen += manaRegenSpeed * Time.deltaTime;
			if (accumulatedManaRegen > 1.0f)
			{
				int amountToRegen = Mathf.Min(maxMana - currentMana, (int) Mathf.Floor(accumulatedManaRegen));
				
				SpendMana(-amountToRegen);
				accumulatedManaRegen -= amountToRegen;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
    }
}

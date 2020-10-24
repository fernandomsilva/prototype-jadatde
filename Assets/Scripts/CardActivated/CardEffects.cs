using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    public GeneralEffect particleEffect;

    public void RunCardEffects(CardStats thisCardStats, List<GameObject> enemiesInRange)
	{
		cardEffect(thisCardStats.effect1, thisCardStats.magnitude, enemiesInRange);
		cardEffect(thisCardStats.effect2, 0, enemiesInRange);
	}
	
	void cardEffect(string effect, float power, List<GameObject> enemiesInRange)
	{
		foreach (GameObject enemy in enemiesInRange)
		{
			if (enemy)
			{
				if (effect == "Damage")
				{
                    enemy.GetComponent<EnemyBehavior>().OnHit((int) power);
                    //fumaça
                    particleEffect = Resources.Load<GeneralEffect>("Effects/FireEffect");
                    Instantiate(particleEffect, enemy.transform.position, enemy.transform.rotation);
                }
                if (effect == "Slow")
                {
                    enemy.GetComponent<EnemyBehavior>().ApplyEffect(effect);
                }
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectEvents : MonoBehaviour
{
	public List<GameObject> enemiesInRange;
	
    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<GameObject>();
    }

	void OnCollisionEnter2D(Collision2D collisions)
	{
		if (!enemiesInRange.Contains(collisions.gameObject))
		{
			enemiesInRange.Add(collisions.gameObject);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

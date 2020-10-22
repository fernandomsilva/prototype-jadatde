using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehavior enemyUnit;
    public Vector3[] unitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        unitPosition = new Vector3[5];
        unitPosition[0] = new Vector3(transform.position.x, transform.position.y - 2, 0);
        unitPosition[1] = new Vector3(transform.position.x, transform.position.y - 1, 0);
        unitPosition[2] = new Vector3(transform.position.x, transform.position.y + 0, 0);
        unitPosition[3] = new Vector3(transform.position.x, transform.position.y + 1, 0);
        unitPosition[4] = new Vector3(transform.position.x, transform.position.y + 2, 0);


        for (int i = 0; i < 5; i++)
        {
            EnemyBehavior enemyInst = Instantiate(enemyUnit, unitPosition[i], Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestCommands : MonoBehaviour
{
    public GameObject enemySpawn;
    public GameObject alliedSpawn;//this is for testing purposes only.
    public EnemyBehavior enemyUnit;
    public AllyBehavior allyUnit;//this is for testing purposes only.
    public Vector3[] unitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown("e"))//spawns enemies.
        {
            unitPosition = new Vector3[3];
            unitPosition[0] = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y - 1, 0);
            unitPosition[1] = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y + 0, 0);
            unitPosition[2] = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y + 1, 0);

            for (int i = 0; i < 3; i++)
            {
                EnemyBehavior enemyInst = Instantiate(enemyUnit, unitPosition[i], Quaternion.identity);
            }

        }
        if (Input.GetKeyDown("q"))//spawns allies.
        {
            unitPosition = new Vector3[3];
            unitPosition[0] = new Vector3(alliedSpawn.transform.position.x, enemySpawn.transform.position.y - 1, 0);
            unitPosition[1] = new Vector3(alliedSpawn.transform.position.x, enemySpawn.transform.position.y + 0, 0);
            unitPosition[2] = new Vector3(alliedSpawn.transform.position.x, enemySpawn.transform.position.y + 1, 0);

            for (int i = 0; i < 3; i++)
            {
                AllyBehavior allyInst = Instantiate(allyUnit, unitPosition[i], Quaternion.identity);
            }
        }
    }
}

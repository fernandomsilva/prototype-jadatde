using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public float time;
    public Collider2D targetCollider;
    public string intendedTarget;
    public int damage;
    public Vector3 direction;
    public CriticalHit isCritical;

    // Start is called before the first frame update
    void Start()
    {
        direction.z = 0.0f;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject == targetCollider)
        {
            int crit = Random.Range(1, 5);
            if (crit == 1)
            {
                otherObject.SendMessage("OnHit", damage * 2);
                Instantiate(isCritical, otherObject.transform.position, transform.rotation);
            }
            else
            {
                otherObject.SendMessage("OnHit", damage);
            }
        }
    }
}

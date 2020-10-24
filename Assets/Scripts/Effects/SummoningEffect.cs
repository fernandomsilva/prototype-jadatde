using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningEffect : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.6f)
        {
            Destroy(gameObject);
        }
    }
}

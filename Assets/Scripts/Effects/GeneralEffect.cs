using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEffect : MonoBehaviour
{
    public float time;
    public float timeDeath;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        timeDeath = 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeDeath)
        {
            Destroy(gameObject);
        }
    }
}

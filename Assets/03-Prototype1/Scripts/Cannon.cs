using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float destroyTime = 2;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time + Time.fixedDeltaTime;
        if (time > destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public float destroyTime = 2;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "RedWall")
        {
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Health>().Striked();
        }
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

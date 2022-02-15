using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RedWall"))
        {
            this.GetComponent<Health>().health = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

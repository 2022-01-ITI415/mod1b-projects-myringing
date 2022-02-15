using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health S;
    public int health;
    // Start is called before the first frame update

    public void Striked()
    {
        health -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Player" && health <= 0)
        {
            transform.tag = "Untagged";
            health = 1;
            this.gameObject.SetActive(false);
        }
        else if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health S;
    public GameObject dropPrefab;
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
        else if ((transform.tag == "Tower" || transform.tag == "Boss") && health <= 0)
        {
            Vector3 pos = transform.position;
            pos.y = 0.5f;
            GameObject drop = Instantiate(dropPrefab) as GameObject;
            drop.transform.position = pos;
            Destroy(this.gameObject);
        }
        else if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

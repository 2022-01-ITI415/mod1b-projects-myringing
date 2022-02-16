using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    public float destroyTime = 2;
    private float time;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "RedWall")
        {
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Tower" || other.transform.tag == "Enemy" || other.transform.tag == "Boss")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Health>().Striked();
        }
        else if (other.transform.tag == "Cannon")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
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

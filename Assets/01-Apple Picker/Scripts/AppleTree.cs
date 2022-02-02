using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 0.1f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    public GameObject boomPrefab;
    public float chanceToDropBooms = 0.1f;
    private GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (secondsBetweenAppleDrops > 0.2f)
        {
            secondsBetweenAppleDrops -= 0.1f * Time.deltaTime;
        }
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }

        if (Random.value < chanceToDropBooms)
        {
            drop = boomPrefab;
        }
        else
        {
            drop = applePrefab;
        }
    }

    void DropApple()
    {
        GameObject GO = Instantiate(drop) as GameObject;
        GO.transform.position = transform.position;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}

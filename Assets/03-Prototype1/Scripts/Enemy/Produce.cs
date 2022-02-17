using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    public GameObject prefab;
    public float produceRate = 5f;
    public float range = 20f;
    public float posX;
    public float posZ;

    private GameObject player;
    private Vector3 playerPos;

    private float next;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void ProduceObject()
    {
        Vector3 pos = transform.position;
        pos.x += posX;
        pos.z += posZ;
        GameObject Go = Instantiate(prefab) as GameObject;
        Go.transform.position = pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < range)
        {
            next = next + Time.fixedDeltaTime;
            if (next > produceRate)
            {
                ProduceObject();
                next = 0;
            }
        }
    }
}

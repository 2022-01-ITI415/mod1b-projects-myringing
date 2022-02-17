using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallFol : MonoBehaviour
{
    public float speed = 10f;
    public float range = 10f;

    private GameObject player;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < range)
        {
            Follow();
        }
    }

    void Follow()
    {
        playerPos = player.transform.position;
        playerPos.y = 1;
        transform.position = Vector3.Lerp(transform.position, playerPos, 0.05f);
    }
}

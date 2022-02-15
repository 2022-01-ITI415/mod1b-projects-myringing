using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cannonprefab;
    public float speed = 10;

    private GameObject player;
    private Vector3 playerPos;
    private float height = 0.4f;

    public float fireRate = 1f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");     
    }

    private void Fire()
    {
        float fireAngle = Vector2.Angle(playerPos - transform.position, playerPos - transform.position);
        GameObject cannon = Instantiate(cannonprefab, transform.position, Quaternion.identity) as GameObject;
        cannon.GetComponent<Rigidbody>().velocity = ((playerPos - transform.position).normalized * speed);
        cannon.transform.eulerAngles = new Vector3(0, fireAngle, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;
        playerPos.y = height;

        if (Vector3.Distance(playerPos, transform.position) < 15f)
        {
            nextFire = nextFire + Time.fixedDeltaTime;
            if (nextFire > fireRate)
            {
                Fire();
                nextFire = 0;
            }
        }

    }
}

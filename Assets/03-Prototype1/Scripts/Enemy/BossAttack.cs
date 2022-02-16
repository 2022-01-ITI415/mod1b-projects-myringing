using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject cannonprefab;
    public float fireRate = 4f;
    public float speed = 10;
    public float range;

    private GameObject player;
    private Vector3 playerPos;
    private float height = 0.4f;

    private int ammo = 9;
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

        if (Vector3.Distance(playerPos, transform.position) < range)
        {
            transform.LookAt(playerPos);
            nextFire = nextFire + Time.fixedDeltaTime;
            if (nextFire > fireRate && ammo > 0)
            {
                Fire();
                ammo -= 1;
            }
            else if (ammo <= 0)
            {
                nextFire = 0;
                ammo = 9;
            }
        }
    }
}

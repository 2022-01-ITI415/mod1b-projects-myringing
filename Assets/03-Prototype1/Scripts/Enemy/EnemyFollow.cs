using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject frontWheel;
    public GameObject backWheel;

    public float speed = 1f;
    public float range = 15f;
    public float rotSpeed = 0.05f;
    public float wheelRotSpeed = 5f;

    private GameObject player;

    private void Start()
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
        Vector3 movement = player.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(rotSpeed));
    }

    void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        frontWheel.transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime * wheelRotSpeed);
        backWheel.transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime * wheelRotSpeed);
    }
}

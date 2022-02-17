using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarRot : MonoBehaviour
{
    public GameObject bar;

    private float range;
    private GameObject player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<Enemy>().range;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < range)
        {
            Debug.Log("2");
            bar.transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime * 10);
        }
    }
}

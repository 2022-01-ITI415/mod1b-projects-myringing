using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float camY;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        camY = this.transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = player.transform.position;
        pos.y = camY;
        this.transform.position = pos;
    }
}

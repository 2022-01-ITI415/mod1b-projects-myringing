using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float camY;
    public GameObject player;
    public Vector3 mousePos;
    public Vector3 destination;
    public float easing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        camY = this.transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = GetMouse.S.mousePos3D;
        mousePos.y = camY;
        Vector3 pos = player.transform.position;
        pos.y = camY;
        destination = (pos + mousePos) / 2;
        destination = Vector3.Lerp(transform.position, destination, easing);
        transform.position = destination;
        //if (Mathf.Abs(destination.x) <= 5 && Mathf.Abs(destination.z) <= 5)
        //{            
            //this.GetComponent<Camera>().orthographicSize = Mathf.Max(Mathf.Abs(destination.x), Mathf.Abs(destination.z)) / 2 + 5;
        //}
    }
}

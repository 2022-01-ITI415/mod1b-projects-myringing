using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(0, 30, 0);
        transform.Rotate(rot * Time.deltaTime);
    }
}

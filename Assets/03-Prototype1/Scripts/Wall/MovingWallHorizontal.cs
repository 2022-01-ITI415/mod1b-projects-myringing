using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallHorizontal : MonoBehaviour
{
    public float speed = 1;
    private int movingSwitch;

    // Update is called once per frame
    void Update()
    {
        if (movingSwitch == 0)
        {
            MoveLeft();
        }
        else if (movingSwitch == 1)
        {
            MoveRight();
        }
    }

    void MoveRight()
    {
        transform.position += (new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.position += (new Vector3(-speed, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tright")
        {
            movingSwitch = 0;
        }

        if (other.gameObject.name == "Tleft")
        {
            movingSwitch = 1;
        }
    }
}

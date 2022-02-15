using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallVertical : MonoBehaviour
{
    private int movingSwitch;

    // Update is called once per frame
    void Update()
    {
        if (movingSwitch == 0)
        {
            MoveDown();
        }
        else if (movingSwitch == 1)
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        transform.position += (new Vector3(0, 0, 1) * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.position += (new Vector3(0, 0, -1) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tup")
        {
            movingSwitch = 0;
        }

        if (other.gameObject.name == "Tdown")
        {
            movingSwitch = 1;
        }
    }
}

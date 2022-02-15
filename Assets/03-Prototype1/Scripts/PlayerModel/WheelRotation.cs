using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelRotation : MonoBehaviour
{
    private Keyboard keyboard = Keyboard.current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime * PlayerController.S.velocity);
    }
}

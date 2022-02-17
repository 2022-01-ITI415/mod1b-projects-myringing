using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetMouse : MonoBehaviour
{
    public static GetMouse S;
    public float mouseHeight;
    public Vector3 mousePos3D;
    public Mouse mouse = Mouse.current;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse's position (x, z)
        Vector2 mousePos2D = mouse.position.ReadValue();
        //mousePos2D.y = mouseHeight;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.y = mouseHeight;
    }
}

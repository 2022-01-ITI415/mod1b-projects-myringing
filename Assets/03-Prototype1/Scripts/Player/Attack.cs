using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public float speed = 15;
    public GameObject cannonprefab;
    public GameObject bar;
    public Mouse mouse = Mouse.current;
    public Vector3 mousePos;
    public float fireRate = 0.4f;
    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PlayerFire()
    {
        nextFire = 0;
        mousePos = GetMouse.S.mousePos3D;
        float fireAngle = Vector2.Angle(mousePos - this.transform.position, mousePos - this.transform.position);
        GameObject cannon = Instantiate(cannonprefab, bar.transform.position, Quaternion.identity) as GameObject;
        cannon.GetComponent<Rigidbody>().velocity = ((mousePos - transform.position).normalized * speed);
        cannon.transform.eulerAngles = new Vector3(0, fireAngle, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nextFire = nextFire + Time.fixedDeltaTime;
        if (mouse.leftButton.isPressed && nextFire > fireRate)
        {
            PlayerFire();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController S;
    public float speed = 0;
    public GameObject player;
    public float velocity;
    public float rotSpeed;

    private Rigidbody rb;
    public float movementX;
    public float movementY;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        //get player's velocity
        Vector3 vel = rb.velocity;
        velocity = Mathf.Max(Mathf.Abs(vel.x), Mathf.Abs(vel.z));

        if (movementX != 0 || movementY != 0)
        {
            Quaternion lookRot = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(rotSpeed));
        }
    }
}

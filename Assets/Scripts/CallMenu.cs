using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CallMenu : MonoBehaviour
{
    public GameObject menu;

    public Keyboard keyboard = Keyboard.current;
    private bool menuOpen;
    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            if (menuOpen == false)
            {
                menu.SetActive(true);
                menuOpen = true;
            }
            else if (menuOpen == true)
            {
                menu.SetActive(false);
                menuOpen = false;
            }
        }
    }
}

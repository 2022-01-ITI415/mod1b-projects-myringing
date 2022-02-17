using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Skill : MonoBehaviour
{
    public Keyboard keyboard = Keyboard.current;

    private GameObject[] enemyCan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Use()
    {
        enemyCan = GameObject.FindGameObjectsWithTag("EnemyCan");
        foreach (GameObject tGO in enemyCan)
        {
            Destroy(tGO);
        }
        GetComponent<Player>().empNum -= 1;
    }

    private void CheatCode()
    {
        GetComponent<Health>().health += 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.spaceKey.wasPressedThisFrame && GetComponent<Player>().empNum > 0)
        {
            Use();
        }

        else if (keyboard.jKey.wasPressedThisFrame)
        {
            CheatCode();
        }
    }
}

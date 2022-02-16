using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI emp;

    public int empNum = 3;

    public GameObject winT;
    public GameObject menu;
    public GameObject door_1;
    public GameObject door_2;
    public GameObject door_3;


    private int score = 0;
    private int count = 0;
    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedWall"))
        {
            this.GetComponent<Health>().health = 0;
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            this.GetComponent<Health>().health += 1;
            score += 1;
            count += 1;
            Collected();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Treasure"))
        {
            this.GetComponent<Health>().health += 10;
            win = true;
            other.gameObject.SetActive(false);
        }
    }

    private void Collected()
    {
        scoreGUI.text = "Gold: " + score.ToString() + "/4";
    }

    private void NextLv()
    {
        if (count == 4)
        {
            door_1.SetActive(false);
            GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: 2/4";
            score = 0;
            empNum += 1;
            Collected();
        }
        if (count == 8)
        {
            door_2.SetActive(false);
            GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: 3/4";
            score = 0;
            empNum += 1;
            Collected();
        }
        if (count == 12)
        {
            door_3.SetActive(false);
            GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Boss";
            score = 0;
            empNum += 1;
            Collected();
        }
        if (count == 16 && win == true)
        {
            menu.SetActive(true);
            winT.SetActive(true);
            gameObject.SetActive(false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + GameObject.Find("Player").GetComponent<Health>().health.ToString();
        emp.text = "EMP: " + empNum.ToString();

        if (score == 4)
        {
            NextLv();
        }
    }
}

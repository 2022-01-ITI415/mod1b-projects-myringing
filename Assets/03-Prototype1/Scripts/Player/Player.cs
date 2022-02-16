using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreGUI;
    public GameObject door_1;
    public GameObject door_2;
    public GameObject door_3;

    private int score = 0;
    private int count = 0;

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
            Collected();
        }
        if (count == 8)
        {
            door_2.SetActive(false);
            GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: 3/4";
            score = 0;
            Collected();
        }
        if (count == 12)
        {
            door_3.SetActive(false);
            GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Boss";
            score = 0;
            Collected();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 4)
        {
            NextLv();
        }
    }
}

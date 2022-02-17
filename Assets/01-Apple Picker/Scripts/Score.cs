using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text cs;
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        GameObject sGo = GameObject.Find("CS");
        cs = sGo.GetComponent<Text>();
        score = GameObject.Find("ScoreCounter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cs.text = "Your Score: " + score.text;
    }
}

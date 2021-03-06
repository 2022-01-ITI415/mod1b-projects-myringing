using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd,
    end
}
public class MissionDemolition : MonoBehaviour
{
    static public MissionDemolition S;
    public GameObject[] castles;
    public Text gtLevel;
    public Text gtScore;
    public Vector3 castlePos;

    public bool _____________________________;

    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot";

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate(castles[level]) as GameObject;
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Both");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        ShowGT();

        mode = GameMode.playing;
    }

    void ShowGT()
    {
        gtLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        gtScore.text = "Shots Taken: " + shotsTaken;
    }

    // Update is called once per frame
    void Update()
    {
        ShowGT();

        if (mode == GameMode.playing && Goal.goalMet)
        {
            mode = GameMode.levelEnd;

            SwitchView("Both");
            if (mode != GameMode.end)
            {
                Invoke("NextLevel", 2f);
            }
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            mode = GameMode.end;
            menu.SetActive(true);
            return;
        }
        StartLevel();
    }

    private void OnGUI()
    {
        Rect ButtonRect = new Rect((Screen.width / 2) - 50, 10, 100, 24);
        switch (showing)
        {
            case "Slingshot":
                if (GUI.Button(ButtonRect, "Show Castle"))
                {
                    SwitchView("Castle");
                }
                break;

            case "Castle":
                if (GUI.Button(ButtonRect, "Show Both"))
                {
                    SwitchView("Both");
                }
                break;
            case "Both":
                if (GUI.Button(ButtonRect, "Show Slingshot"))
                {
                    SwitchView("Slingshot");
                }
                break;
        }
    }

    static public void SwitchView(string eView)
    {
        S.showing = eView;
        switch (S.showing)
        {
            case "Slingshot":
                FollowCam.S.poi = null;
                break;
            case "Castle":
                FollowCam.S.poi = S.castle;
                break;
            case "Both":
                FollowCam.S.poi = GameObject.Find("ViewBoth");
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}

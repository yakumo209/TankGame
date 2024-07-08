using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;

    public CustomGUIButton btnQuit;

    public CustomGUIButton btnSetting;

    public CustomGUITexture texHP;

    [HideInInspector]public int nowScore=0;

    [HideInInspector]public float nowTime=0;

    private int time;
    // Start is called before the first frame update
    void Start()
    {
        btnSetting.clickEvent += () =>
        {

        };
        btnQuit.clickEvent += () =>
        {

        };
        // AddScore(100);
        // UpdateHP(100,20);
    }

    public void AddScore(int score)
    {
        nowScore += score;
        labScore.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * 104.4f;
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labTime.content.text = "";
        if (time/3600>0)
        {
            labTime.content.text += time / 3600 + "h";
        }

        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60+"m";
        }

        labTime.content.text += time % 60 + "s";
    }
}

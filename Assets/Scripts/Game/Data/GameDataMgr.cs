using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;


    public MusciData musciData;
    public RankList rankData;
    private GameDataMgr()
    {
        musciData=PlayerPrefsDataMgr.Instance.LoadData(typeof(MusciData),"Music") as MusciData;
        if (!musciData.notFirst)
        {
            musciData.notFirst = true;
            musciData.isOpenBg = true;
            musciData.isOpenSound = true;
            musciData.bgValue = 1;
            musciData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musciData,"Music");
        }

        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank")as RankList;
        
    }

    public void OpenOrCloseBgMusic(bool isOpen)
    {
        musciData.isOpenBg = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musciData,"Music");
    }
    public void OpenOrCloseSound(bool isOpen)
    {
        musciData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musciData,"Music");
    }

    public void ChangeBgValue(float value)
    {
        musciData.bgValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musciData,"Music");
    }
    public void ChangeSoundValue(float value)
    {
        musciData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musciData,"Music");
    }

    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name,score,time));
        rankData.list.Sort((a,b)=>a.time<b.time?-1:1);
        for (int i=rankData.list.Count-1;i>=3;i--)
        {
            rankData.list.RemoveAt(i); 
        }
        
        PlayerPrefsDataMgr.Instance.SaveData(rankData,"Rank");
    }
}

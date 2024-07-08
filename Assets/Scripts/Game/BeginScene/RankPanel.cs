using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    public List<CustomGUILabel> labPM = new List<CustomGUILabel>();
    public List<CustomGUILabel> labName = new List<CustomGUILabel>();
    public List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    public List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    // Start is called before the first frame update
    void Start()
    {
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    private void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            labName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            if (time/3600>0)
            {
                labTime[i].content.text += time / 3600 + "h";
            }

            if (time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60+"m";
            }

            labTime[i].content.text += time % 60 + "s";
        }
    }
}

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
        
    }
}

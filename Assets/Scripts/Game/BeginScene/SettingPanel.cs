using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeBgValue(value);
        };sliderSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.ChangeSoundValue(value);
        };
        togMusic.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseBgMusic(value);
        };togSound.changeValue += (value) =>
        {
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };
        btnClose.clickEvent += () =>
        {
            HideMe();
            if(SceneManager.GetActiveScene().name=="BeginScene")
                BeginPanel.Instance.ShowMe();
            Time.timeScale = 1;
        }; 
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePanelInfo()
    {
        MusciData data = GameDataMgr.Instance.musciData;
        sliderMusic.nowValue = data.bgValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBg;
        togSound.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        };sliderSound.changeValue += (value) =>
        {

        };
        togMusic.changeValue += (value) =>
        {

        };togSound.changeValue += (value) =>
        {

        };
        btnClose.clickEvent += () =>
        {
            HideMe(); 
            BeginPanel.Instance.ShowMe();
        }; 
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        btnBegin.clickEvent += () =>
        {
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowMe();
            HideMe();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

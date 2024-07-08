using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnOk;

    public CustomGUIButton btnContinue;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnOk.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
            
            Time.timeScale = 1;
        };
        btnClose.clickEvent += () =>
        {
            HideMe();
            Time.timeScale = 1;

        };
        btnContinue.clickEvent += () =>
        {
            HideMe();
            Time.timeScale = 1;

        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

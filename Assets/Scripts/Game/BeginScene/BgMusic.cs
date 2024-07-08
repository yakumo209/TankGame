using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private static BgMusic instance;

    public static BgMusic Instance=>instance;
    private AudioSource _audioSource;
    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
        ChangeOpen(GameDataMgr.Instance.musciData.isOpenBg);
        ChangeValue(GameDataMgr.Instance.musciData.bgValue);
    }

    public void ChangeValue(float value)
    {
        _audioSource.volume = value;
    }

    public void ChangeOpen(bool isOpen)
    {
        _audioSource.mute = !isOpen;
    }
}

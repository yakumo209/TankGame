using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewards;
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {

        int rangeInt = Random.Range(0, 100);
        if (rangeInt<50)
        {
            rangeInt = Random.Range(0, rewards.Length);
            Instantiate(rewards[rangeInt], this.transform.position, this.transform.rotation);
        }
        GameObject eff = Instantiate(deadEff, this.transform.position, this.transform.rotation);
        AudioSource audioSource = eff.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musciData.soundValue;
        audioSource.mute = !GameDataMgr.Instance.musciData.isOpenSound; 
        
        
        Destroy(gameObject);
    }
    
}

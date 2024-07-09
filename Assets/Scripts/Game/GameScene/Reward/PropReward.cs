using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PropType{
    atk,
    def,
    maxHp,
    hp,
}

public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.atk;
    public int changeValue=2;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.def:
                    player.def += changeValue;
                    break;
                case E_PropType.maxHp:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHP(player.maxHp,player.hp);
                    break;
                case E_PropType.hp:
                    player.hp += changeValue;
                    if (player.hp>=player.maxHp)
                    {
                        player.hp = player.maxHp;
                    }
                    
                    GamePanel.Instance.UpdateHP(player.maxHp,player.hp);
                    break;
            }
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musciData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musciData.isOpenSound; 
            
            Destroy(gameObject);
        }
    }
}

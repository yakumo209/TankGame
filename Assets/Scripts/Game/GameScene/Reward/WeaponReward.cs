using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;

    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index=Random.Range(0, weaponObj.Length);
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musciData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musciData.isOpenSound;
            
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed=50;

    public TankBaseObj fatherObj;

    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (effObj != null)
            {
                GameObject eff = Instantiate(effObj, transform.position, transform.rotation);
                eff.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musciData.soundValue;
                eff.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musciData.isOpenSound;
            }
            Destroy(gameObject);
            
        }
    }

    public void SetFather(TankBaseObj obj)
    {
        this.fatherObj = obj;
    }
}

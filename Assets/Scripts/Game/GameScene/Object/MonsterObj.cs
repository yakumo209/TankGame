using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterObj : TankBaseObj
{
    private Transform targetPos;

    public Transform[] randomPos;

    public Transform lookAtTarget;

    public float fireDistance=5;

    public float fireOffsetTime=1;

    private float nowTime=0;

    public Transform[] shootPos;

    public GameObject bulletObj;

    public Texture maxHPBK;

    public Texture hpBK;

    public Rect maxHPRect;

    public Rect hpRect;

    private float showTime;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position,targetPos.position)<0.05f)
        {
            RandomPos();
        }

        if (lookAtTarget!=null)
        {
            tankHead.transform.LookAt(lookAtTarget);
        }

        if (Vector3.Distance(transform.position,lookAtTarget.position)<fireDistance)
        {
            nowTime += Time.deltaTime;
            if (nowTime>fireOffsetTime)
            {
                nowTime = 0;
                Fire();
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length==0)
        {
            return;
        }

        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this); 
        }
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    private void OnGUI()
    {
        if (showTime>0)
        {
            showTime -= Time.deltaTime;
            Vector3 screenPos=Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            maxHPRect.x = screenPos.x;
            maxHPRect.y = screenPos.y;
            maxHPRect.width = 100;
            maxHPRect.height = 15;
            GUI.DrawTexture(maxHPRect,maxHPBK);
            hpRect.x = screenPos.x;
            hpRect.y = screenPos.y;
            hpRect.width =(float) (hp/maxHp)* 100f;
            hpRect.height = 15;
            GUI.DrawTexture(maxHPRect,maxHPBK);
        }
        
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3f;
    }
}

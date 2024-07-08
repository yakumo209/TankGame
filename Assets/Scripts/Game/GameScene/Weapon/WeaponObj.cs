using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;

    public Transform[] shootPos;

    public TankBaseObj fatherObj;

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(this.bullet, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(fatherObj);
        }
    }

    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}

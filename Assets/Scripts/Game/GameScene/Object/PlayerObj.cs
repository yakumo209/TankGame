using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;
    public Transform weaponPos;
    void Update()
    {
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime*Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up*roundSpeed*Time.deltaTime*Input.GetAxis("Horizontal"));
        tankHead.transform.Rotate(Vector3.up*headRoundSpeed*Time.deltaTime*Input.GetAxis("Mouse X"));
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();   
        }
    }

    public override void Fire()
    {
        if (nowWeapon!=null)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHP(this.maxHp,this.hp);
    }

    public void ChangeWeapon(GameObject obj)
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        GameObject weaponObj = Instantiate(obj,weaponPos,false );
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}

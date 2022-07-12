using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TankInfo
{
    public int damage;
    public int hp;
}
public abstract class TankController : MoveController,Ihitt
{
    public Transform body;
    public Transform gun;
    public Transform bulletPos;
    public HPcontroller hpController;
    public LevelController levelController;
    public float damage = 1;

    protected virtual void Awake()
    {
        hpController.onDie = Ondie;
        levelController.onUplevel = OnUpLevel;
    }

    protected override void Move(Vector3 direction)
    {
        body.up = direction;
        base.Move(direction);
    }
    protected void MyGun(Vector3 direction)
    {
        gun.up = direction;
    }
    protected void Shoot()
    {
        Debug.Log(transform.gameObject.name + "Ban");
        Creater.Instance.CreateBullet(bulletPos, damage);
    }
    public void OnHit(float damage)
    {
        Debug.Log("Dinh damage " +transform.name +"dame1 "+damage);
        hpController.TakeDamage(damage);
    }

    protected abstract void Ondie(); 

    protected void OnUpLevel(int level)
    {
        TankInfo tankInfo = GetTankInfo(level);
        damage = tankInfo.damage;
        hpController.SetHP(tankInfo.hp);
    }

    protected abstract TankInfo GetTankInfo(int level);
}

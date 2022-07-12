
using System;
using System.Collections;
using System.Collections.Generic;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : TankController

{
    Vector3 direction = Vector3.zero;
    int timeCountChangeDirection = 0;
    public float distance;  
    private float timeCount = 0;

    protected override void Awake()
    {
        base.Awake();
        levelController.SetLevel(1);
    }
    protected override TankInfo GetTankInfo(int level)
    {
        return DataController.Instance.enemyVO.GetTankInfo(level);
    }
    protected override void Ondie()
    {
        Observer.Instance.Notify(Observerkey.ENEMY_DIE,levelController.level);
        Creater.Instance.CreateExplosion(transform.position);
        Destroy(gameObject);
    }
    void Update()
    {
        Player.Instance.transform.position = new Vector3(
            Player.Instance.transform.position.x,
            Player.Instance.transform.position.y,
            gun.position.z);
        MyGun(Player.Instance.transform.position - gun.position);
        
        if (timeCountChangeDirection == 0)
        {
            distance = Vector2.Distance(transform.position, Player.Instance.transform.position);
            if (distance >=4)
            {
                direction = (Player.Instance.transform.position - body.position).normalized;
            }
            else if(distance<=4)
            {
                direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeCountChangeDirection = Random.Range(1, 1000);
            }
            timeCountChangeDirection = Random.Range(1, 1000);
        }
        timeCountChangeDirection--;
        Move(direction);
        if (Random.Range(1,10000)%500 == 0)
        {
            Shoot();
        }
    }
    // private void OnDestroy()
    // {
    //     Debug.Log("Enemy Destroy");
    //     
    // }
}

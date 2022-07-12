using System;
using System.Collections;
using System.Collections.Generic;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine;

public class PlayerController : TankController
{
    void Start()
    {
        base.Awake();
        levelController.SetLevel(1);
        Observer.Instance.AddObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(new Vector3(horizontal, vertical, 0));

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos = new Vector3(mousePos.x, mousePos.y, gun.position.z);
        
        MyGun(mousePos-gun.position);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void OnEnemyDie(object data)
    {
        int enemylevel = (int)data;
        levelController.AccumulatEXP(enemylevel*2);
    }
    protected override void Ondie()
    {
        
        Debug.Log("YouLose");
        Creater.Instance.CreateExplosion(transform.position);
        Destroy(gameObject);
        Game.Instance.ShowLose();
    }

    protected override TankInfo GetTankInfo(int level)
    {
        return DataController.Instance.playerVO.GetTankInfo(level);
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
    }
}

public class Player : SingletonMonoBehaviour<PlayerController>{}

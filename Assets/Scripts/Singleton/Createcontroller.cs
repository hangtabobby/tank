using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class Createcontroller : MonoBehaviour
{
    //public static Createcontroller instance;
    public BulletController preBullet;
    public GameObject preExplosion;
    public EnemyController preEnemy;
    // Update is called once per frame
    
        public void CreateBullet(Transform shootPos, float damage)
        {
            BulletController bullet = Instantiate(preBullet, shootPos.position, shootPos.rotation);
            bullet.damage= damage;
        }

        public void CreateExplosion(Vector3 pos)
        {
            Instantiate(preExplosion, pos, quaternion.identity);
        }

        public EnemyController CreateEnemy(Vector3 pos) //hàm tạo enemy để tạo enemy rồi trả về ennemy 
        {
            return Instantiate(preEnemy, pos, preEnemy.transform.rotation);
            
        }
    
}

public class Creater : SingletonMonoBehaviour<Createcontroller>
{
    
}

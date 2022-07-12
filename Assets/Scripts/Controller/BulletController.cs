using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{
    int countTime = 0;
    public float damage;
    void Update()
    {
        countTime++;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f);
        if(hit.transform != null)
        {
            Ihitt iHit = hit.transform.GetComponent<Ihitt>();
            if (iHit!=null)
            {
                iHit.OnHit(damage);
                Creater.Instance.CreateExplosion(transform.position);
                Destroy(gameObject);
                return;
            }
        }
        if(countTime==100)
        {
            Creater.Instance.CreateExplosion(transform.position);
            Destroy(gameObject);
        }
        Move(transform.up);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPcontroller : ProcessController
{
    public delegate void die();

    public die onDie;

    public void SetHP(float newHP)
    {
        SetValue(newHP);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Trumau");
        EditValue(currentValue-damage);
        if (currentValue == 0 && onDie != null)
        {
            Debug.Log("HetMau");
            Creater.Instance.CreateExplosion(transform.position);
            onDie();
        }
    }
}

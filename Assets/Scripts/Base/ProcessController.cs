using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class  ProcessController : MonoBehaviour
{
    public float maxValue = 10 ;
    public float currentValue = 10;

    protected void SetValue(float newValue)
    {
        maxValue = newValue;
        EditValue(newValue);
    }
    
    protected void EditValue(float newValue)
    {
        currentValue = newValue;
        if (currentValue < 0) currentValue = 0;// gioi han tu 0
        if (currentValue > maxValue) currentValue = maxValue; // den max
        transform.localScale = new Vector3((float)currentValue / maxValue, 1, 1);
    }
}

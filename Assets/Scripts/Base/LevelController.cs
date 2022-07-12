using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : ProcessController
{
    // lưu kinh nghiem và level hien tai, hamg tang exp, event trẻ về tăng level
    public delegate void Uplevel(int level);

    public Uplevel onUplevel;
    
    public int level;

    public void SetLevel(int newLevel)
    {
        
        level = newLevel;
        if (onUplevel != null)
        {
            onUplevel(level);
        }
        Debug.Log("LenLevel"+ gameObject.name);
    }

    public void AccumulatEXP(float exp)
    {
        
        EditValue(currentValue+exp);
        if (currentValue == maxValue)
        {
            currentValue = 0;
            level++; // bằng level=level+1
            if (onUplevel != null)
            {
                onUplevel(level);
            }
            Debug.Log("ThemKN"+ gameObject.name);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class TankVO : BaseVO
{
    public TankInfo GetTankInfo(int level)
    {
        TankInfo tankInfo = new TankInfo();
        JSONArray array = data.AsArray;
        if (level> array.Count)
             level = array.Count;
        JSONNode tankData = array[level - 1];
        tankInfo.damage = tankData["damage"].AsInt;
        tankInfo.hp = tankData["hp"].AsInt;
        return tankInfo;
    }
}

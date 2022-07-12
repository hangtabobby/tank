using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class StageVO : BaseVO
{
    public StageInfo GetStageInfo(int stage)
    {
        StageInfo stageInfo = new StageInfo();
        JSONArray array = data.AsArray;
        if (stage > array.Count) return null;
        JSONArray datas = array[stage-1].AsArray;
        WaveInfo[] waveInfos = new WaveInfo[datas.Count];
        Debug.Log(waveInfos.Length);
        for (int j = 0; j < datas.Count; j++)
        {
            waveInfos[j] = new WaveInfo(datas[j]["numEnemy"].AsInt, datas[j]["levelEnemy"].AsInt);

        }
        stageInfo.waveInfos = waveInfos;
        return stageInfo;
    }
    public StageVO()
    {
        LoadData("Stage");
    }
    
}

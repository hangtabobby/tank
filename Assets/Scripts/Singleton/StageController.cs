using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.UI;

[System.Serializable]

public class StageInfo
{
    public WaveInfo[] waveInfos;
}
public class StageController : MonoBehaviour
{
    int currentStage = 1;
    public Text txtStage;
    public void Awake()
    {
        DataController.Instance.LoadDataLocal();
        Observer.Instance.AddObserver(Observerkey.WAVE_DONE,WaveDone);
    }

    public void Start()
    {
        txtStage.text = "1";
        WaveInfo[] waveInfos = GetStageInfo(currentStage).waveInfos;
        Waves.Instance.WaveInfos = waveInfos;

    }

    public void WaveDone(object dt)
    {
        txtStage.text = (currentStage+1).ToString();
        NextStage();

    }

    public void NextStage()
    {
        currentStage++;
        Debug.Log(currentStage);
        StageInfo stageInfo = GetStageInfo(currentStage);
        if (stageInfo == null)
        {
            Debug.Log("You Win");
            Game.Instance.ShowWin();
            return;
        }
        Waves.Instance.WaveInfos = stageInfo.waveInfos;
    }
    
    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(Observerkey.WAVE_DONE,WaveDone);
    }

    protected StageInfo GetStageInfo(int stage)
    {
        return DataController.Instance.stageVo.GetStageInfo(stage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class DataController : Singleton<DataController>
{
    public PlayerVO playerVO;
    public EnemyVO enemyVO;
    public StageVO stageVo;

    public void LoadDataLocal()
    {
        playerVO = new PlayerVO();
        enemyVO = new EnemyVO();
        stageVo = new StageVO();
    }
}

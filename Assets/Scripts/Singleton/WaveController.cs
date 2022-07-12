using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.UI;

[System.Serializable]

public class WaveInfo
{
    public int numEnemy;
    public int levelEnemy;

    public WaveInfo(int numEnemy,int levelEnemy)
    {
        this.levelEnemy = levelEnemy;
        this.numEnemy = numEnemy;
    }
}
public class WaveController : MonoBehaviour
{
    int currentWave=1;
    int currentEnemy;

        private WaveInfo[] _waveInfos;

    public WaveInfo[] WaveInfos
    {
        set
        {
            _waveInfos = value;
            currentWave = 0;
            CreateEnemies(_waveInfos[currentWave]);
        }
    }

    // public Text txtWave;
    private void Awake()
    {
        Observer.Instance.AddObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
    }
    public void OnEnemyDie(object data)
    {
        currentEnemy--;
        if (currentEnemy==0)
        {
            NextWave();
            //txtWave.text = currentWave.ToString();
        }

    }
    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
        
    }
    void NextWave()
    {
        currentWave++;
        if (currentWave >=  _waveInfos.Length)
        {
            Observer.Instance.Notify(Observerkey.WAVE_DONE);
            return;
        }
        WaveInfo waveInfo = _waveInfos[currentWave];
        
        CreateEnemies(waveInfo);
    }

    void CreateEnemies(WaveInfo waveInfo)
    {
        //txtWave.text = (currentWave+1).ToString();
        Vector3 playerPos = Player.Instance.transform.position;
        currentEnemy = waveInfo.numEnemy;
        for (int i = 0; i < waveInfo.numEnemy; i++)
        {
            Debug.Log(i);
            Vector3 enemyPos = new Vector3(
                playerPos.x + Random.Range(-10f, 10f),
                playerPos.y + Random.Range(-10f, 10f)
            );
            EnemyController enemy = Creater.Instance.CreateEnemy(enemyPos);
            enemy.levelController.SetLevel(waveInfo.levelEnemy);
        }
    }
}

public class Waves : SingletonMonoBehaviour<WaveController>
{
    
}
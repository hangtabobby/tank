using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using LTAUnityBase.Base.DesignPattern;

public class Observerkey
{
    public const string ENEMY_DIE = " EnemyDie";
    public const string WAVE_DONE = " WaveDone";
}
public class GameController : MonoBehaviour
{
    public bool isPlaying = false;
    public Text txtGame, txtStage;
    public Text txtscore;
    public bool isAllowStartGame = true;
    public int score =0;

    private void Awake()
    {
        DataController.Instance.LoadDataLocal();
        Observer.Instance.AddObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
    }

    public void OnEnemyDie(object data)
    {
        score++;
        txtscore.text = score.ToString();

    }
    public void Start()
    {
        txtscore.text = "Score";
        //txtStage.text = "Stage";
    }
    public void ShowWin()
    {
        txtGame.gameObject.SetActive(true);
        isPlaying = false;
        txtGame.text = "YOU WIN";
    }

    public void ShowLose()
    {
        txtGame.gameObject.SetActive(true);
        isPlaying = false;
        txtGame.text = "YOU LOSE";
    }
    
    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(Observerkey.ENEMY_DIE,OnEnemyDie);
    
    }
}
public class Game : SingletonMonoBehaviour<GameController>{}
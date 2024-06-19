using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : Singleton<GameplayManager>
{
    public LevelResults LevelResults = new();

    [SerializeField] BlobCounter blobCounter;

    int killedEnemies;

    [Header("Enemy Spawner settings")]
    public EnemySpawner EnemySpawner;
    [SerializeField] int maxEnemiesOverall;
    [SerializeField] int maxEnemiesAtOnce;
    protected override void Awake()
    {
        base.Awake();
        killedEnemies = 0;
        LevelResults.colectedMoney = 69;
        EnemySpawner.Init(maxEnemiesOverall, maxEnemiesAtOnce);
        blobCounter.Init(maxEnemiesOverall);
        Enemy.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled(Enemy context)
    {
        LevelResults.moneyOnWin += context.moneyOnKill;
        killedEnemies++;

        if(killedEnemies >= maxEnemiesOverall)
        {
            LevelCompleted(isWin: true);
        }
    }

    public void LevelCompleted(bool isWin)
    {
        LevelResults.isWin = isWin;
        SavableDataManager.Instance.data.levelResults = LevelResults;
        LevelResults.Apply();

        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }

}

using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public LevelResults LevelResults = new();

    [SerializeField] BlobCounter blobCounter;

    int killedEnemies;

    [Header("Enemy Spawner settings")]
    public EnemySpawner EnemySpawner;
    [SerializeField] int maxEnemiesOverall;
    [SerializeField] int maxEnemiesAtOnce;

    [SerializeField] GameObject tutorialCanvas;
    private bool tutorialHidden = false;

    void Awake()
    {
        LevelResults.colectedMoney = 69;
        EnemySpawner.Init(maxEnemiesOverall, maxEnemiesAtOnce);
        blobCounter.Init(maxEnemiesOverall);

        tutorialCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
      if (!tutorialHidden)
      {
        if (Input.anyKeyDown)
        {
          tutorialCanvas.SetActive(false);
          Time.timeScale = 1.0f;
          tutorialHidden = true;
        }
      }
    }
  private void OnEnable()
    {
        killedEnemies = 0;
        Enemy.OnEnemyKilled += OnEnemyKilled;
        SamuraiAlly.OnDeath += OnAllyDeath;
        SamuraiGeneral.OnDeath += OnGeneralDeath;
    }

    private void OnGeneralDeath(Samurai samurai)
    {
        LevelCompleted(isWin: false);
        Application.Quit();
    }

    private void OnAllyDeath(Samurai samurai)
    {
        Destroy(samurai.gameObject);
        SavableDataManager.Instance.data.team.KillCharacter(samurai.Character);
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= OnEnemyKilled;
        SamuraiAlly.OnDeath -= OnAllyDeath;
        SamuraiGeneral.OnDeath -= OnGeneralDeath;
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

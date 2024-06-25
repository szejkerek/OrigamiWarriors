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

    [Header("Tutorial canvas")]
    [SerializeField] GameObject tutorialCanvas;
    private bool tutorialHidden = false;

    [Header("GOAP Tutorial canvas")]
    [SerializeField] GameObject goapTutorialCanvas;
    private bool goapTutorialHidden = true;

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
          //Time.timeScale = 1.0f;
          tutorialHidden = true;

          goapTutorialCanvas.SetActive(true);
          goapTutorialHidden = false;
          //Time.timeScale = 0.0f;
        }
      }
      else if (!goapTutorialHidden)
      { 
        if (Input.anyKeyDown)
        {
          goapTutorialCanvas.SetActive(false);
          Time.timeScale = 1.0f;
          goapTutorialHidden = true;
        }
      }
      else
      {
          if(Input.GetKeyDown(KeyCode.PageUp))
          {
              LevelCompleted(true);
          }

          if (Input.GetKeyDown(KeyCode.PageDown))
          {
              LevelCompleted(false);
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
        SavableDataManager.Instance.RestartGame(toMainMenu: true);
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

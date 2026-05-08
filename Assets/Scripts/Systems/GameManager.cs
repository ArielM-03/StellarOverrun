using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentRound = 1;
    public bool isGameOver = false;

    public AudioSource retryAudio;
    public AudioSource menuAudio;
    public float audioDelay = 0.2f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RoundUp()
    {
        currentRound++;
        EnemySpawner spawner = FindFirstObjectByType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.droneSpawnRate = Mathf.Max(0.5f, spawner.droneSpawnRate - 0.2f);
            spawner.tankSpawnRate = Mathf.Max(2f, spawner.tankSpawnRate - 0.5f);
        }

        if (currentRound % 5 == 0)
        {
            UIManager.Instance.ShowUpgradePanel();
        }

        UIManager.Instance.UpdateLevelText(currentRound);
    }

    public void GameOver()
    {
        isGameOver = true;
        UIManager.Instance.ShowLossScreen();
    }

    public void RestartGame()
    {
        StartCoroutine(LoadWithDelay("GameScene", retryAudio));
    }

    public void GoToMainMenu()
    {
        StartCoroutine(LoadWithDelay("MainMenu", menuAudio));
    }

    IEnumerator LoadWithDelay(string sceneName, AudioSource audio)
    {
        if (audio != null)
            audio.Play();
        yield return new WaitForSecondsRealtime(audioDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
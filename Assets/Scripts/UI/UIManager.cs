using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Slider healthBar;
    public Slider xpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;
    public GameObject upgradePanel;
    public GameObject lossScreen;

    private float timer;
    private bool timerRunning = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void UpdateHealthBar(int current, int max)
    {
        healthBar.maxValue = max;
        healthBar.value = current;
    }

    public void UpdateXPBar(int current, int max)
    {
        xpBar.maxValue = max;
        xpBar.value = current;
    }

    public void UpdateLevelText(int round)
    {
        levelText.text = "LV " + round;
    }

    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0f;
        timerRunning = false;
    }

    public void HideUpgradePanel()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        timerRunning = true;
    }

    public void ShowLossScreen()
    {
        lossScreen.SetActive(true);
        Time.timeScale = 0f;
        timerRunning = false;
    }
}
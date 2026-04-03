using UnityEngine;

public class XPSystem : MonoBehaviour
{
    public static XPSystem Instance;

    public int currentXP = 0;
    public int xpToNextRound = 100;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextRound)
        {
            currentXP = 0;
            GameManager.Instance.RoundUp();
        }

        UIManager.Instance.UpdateXPBar(currentXP, xpToNextRound);
    }
}
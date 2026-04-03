using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public AutoShooter autoShooter;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    public void SelectDoubleShot()
    {
        autoShooter.fireRate = Mathf.Max(0.1f, autoShooter.fireRate - 0.3f);
        UIManager.Instance.HideUpgradePanel();
    }

    public void SelectMoreHealth()
    {
        playerHealth.maxHealth += 5;
        playerHealth.currentHealth += 5;
        UIManager.Instance.UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);
        UIManager.Instance.HideUpgradePanel();
    }

    public void SelectMoveSpeed()
    {
        playerMovement.moveSpeed += 1f;
        UIManager.Instance.HideUpgradePanel();
    }
}
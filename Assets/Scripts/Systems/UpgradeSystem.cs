using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    private AutoShooter autoShooter;
    private ShotgunShooter shotgunShooter;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    public AudioSource upgradeAudio;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            autoShooter = player.GetComponent<AutoShooter>();
            shotgunShooter = player.GetComponent<ShotgunShooter>();
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    void PlayUpgradeSound()
    {
        if (upgradeAudio != null)
            upgradeAudio.PlayOneShot(upgradeAudio.clip);
    }

    public void SelectDoubleShot()
    {
        if (autoShooter != null)
            autoShooter.fireRate = Mathf.Max(0.1f, autoShooter.fireRate - 0.3f);
        if (shotgunShooter != null)
            shotgunShooter.fireRate = Mathf.Max(0.1f, shotgunShooter.fireRate - 0.3f);
        PlayUpgradeSound();
        UIManager.Instance.HideUpgradePanel();
    }

    public void SelectMoreHealth()
    {
        if (playerHealth != null)
        {
            playerHealth.maxHealth += 5;
            playerHealth.currentHealth += 5;
            UIManager.Instance.UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);
        }
        PlayUpgradeSound();
        UIManager.Instance.HideUpgradePanel();
    }

    public void SelectMoveSpeed()
    {
        if (playerMovement != null)
            playerMovement.moveSpeed += 1f;
        PlayUpgradeSound();
        UIManager.Instance.HideUpgradePanel();
    }
}
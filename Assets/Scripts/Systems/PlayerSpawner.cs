using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject alicePrefab;
    public GameObject novaPrefab;

    private GameObject spawnedPlayer;

    void Awake()
    {
        if (CharacterSelect.selectedCharacter == 0)
            spawnedPlayer = Instantiate(alicePrefab, Vector3.zero, Quaternion.identity);
        else
            spawnedPlayer = Instantiate(novaPrefab, Vector3.zero, Quaternion.identity);

        SetupCamera();
        SetupUIManager();
    }

    void SetupCamera()
    {
        CameraFollow cameraFollow = FindFirstObjectByType<CameraFollow>();
        if (cameraFollow != null)
            cameraFollow.target = spawnedPlayer.transform;
    }

    void SetupUIManager()
    {
        UIManager uiManager = FindFirstObjectByType<UIManager>();
        if (uiManager != null)
        {
            PlayerHealth health = spawnedPlayer.GetComponent<PlayerHealth>();
            if (health != null)
                uiManager.UpdateHealthBar(health.currentHealth, health.maxHealth);
        }
    }
}
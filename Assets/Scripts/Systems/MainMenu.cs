using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonAudio;
    public float audioDelay = 0.2f;

    public void StartGame()
    {
        StartCoroutine(LoadWithDelay("CharacterSelect"));
    }

    IEnumerator LoadWithDelay(string sceneName)
    {
        if (buttonAudio != null)
            buttonAudio.Play();

        yield return new WaitForSeconds(audioDelay);
        SceneManager.LoadScene(sceneName);
    }
}
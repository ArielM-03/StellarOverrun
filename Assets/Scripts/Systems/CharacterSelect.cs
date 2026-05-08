using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    public static int selectedCharacter = 0;

    public AudioSource aliceButtonAudio;
    public AudioSource novaButtonAudio;
    public float audioDelay = 0.2f;

    public void SelectAlice()
    {
        StartCoroutine(LoadWithDelay(0, aliceButtonAudio));
    }

    public void SelectNova()
    {
        StartCoroutine(LoadWithDelay(1, novaButtonAudio));
    }

    IEnumerator LoadWithDelay(int characterIndex, AudioSource audio)
    {
        selectedCharacter = characterIndex;
        if (audio != null)
            audio.Play();
        yield return new WaitForSeconds(audioDelay);
        SceneManager.LoadScene("GameScene");
    }
}
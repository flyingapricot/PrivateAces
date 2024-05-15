using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource mainMenuBGM;
    public AudioSource gameplayBGM;

    void Start()
    {
        PlayMainMenuBGM();
    }

    public void StopBGM()
    {
        if (gameplayBGM.isPlaying || mainMenuBGM.isPlaying)
        {
            gameplayBGM.Stop();
            mainMenuBGM.Stop();
        }
    }

    public void PlayMainMenuBGM()
    {
        if (!mainMenuBGM.isPlaying)
        {
            mainMenuBGM.Play();
        }
        gameplayBGM.Stop();
    }

    public void PlayGameplayBGM()
    {
        if (!gameplayBGM.isPlaying)
        {
            gameplayBGM.Play();
        }
        mainMenuBGM.Stop();
    }
}

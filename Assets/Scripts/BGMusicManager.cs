using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource mainMenuBGM;
    public AudioSource gameplayBGM;

    void Start()
    {
        PlayMainMenuBGM();
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

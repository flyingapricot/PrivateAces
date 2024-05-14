using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the slider
    public AudioSource[] audioSources; // Array of AudioSource references
    public VideoPlayer[] videoPlayers; // Array of VideoPlayer references
    public ToggleSoundButton toggleSoundButton; // Reference to the toggle sound button script

    private float lastVolume; // To store the last volume before muting

    void Start()
    {
        // Set the slider's value to its maximum value initially (0 - 5)
        volumeSlider.value = volumeSlider.maxValue;

        // Call SetVolume to initialize the volume of all audio sources and video players
        SetVolume(volumeSlider.value);

        // Add a listener to the slider to call SetVolume() when the value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Store the last volume if it's not zero (not muted)
        if (volume > 0)
        {
            lastVolume = volume;
        }

        // Map the slider value to a volume percentage
        float percentage = volume / volumeSlider.maxValue; // Calculate percentage based on slider's max value (0 - 1)

        // Set the volume of each audio source
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = percentage;
            }
        }

        // Set the volume for each video player
        foreach (var videoPlayer in videoPlayers)
        {
            if (videoPlayer != null)
            {
                videoPlayer.SetDirectAudioVolume(0, percentage); // Adjusting the volume for track 0
            }
        }

        // Update the toggle button sprite based on the volume
        if (toggleSoundButton != null)
        {
            if (percentage <= 0.01f) // Adjusted to include a small threshold for volume being effectively zero
            {
                toggleSoundButton.SetMuteState(true);
            }
            else
            {
                toggleSoundButton.SetMuteState(false);
            }
        }
    }

    public void Mute()
    {
        lastVolume = volumeSlider.value; // Store the current volume before muting
        volumeSlider.value = 0;
    }

    public void Unmute()
    {
        volumeSlider.value = lastVolume;
    }
}

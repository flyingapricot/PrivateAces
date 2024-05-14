using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ToggleSoundButton : MonoBehaviour
{
    public Sprite soundOnImage; // Reference to the "sound on" image
    public Sprite muteImage;    // Reference to the "mute" image
    public VideoPlayer[] videoPlayers; // Array of VideoPlayer references
    public VolumeControl volumeControl; // Reference to the VolumeControl script
    private Button button;      // Reference to the Button component
    public Image buttonImage;  // Reference to the Image component of the Button
    private bool isMuted = false; // Flag to track the mute state
    private bool canToggle = true; // Flag to prevent rapid toggling
    public float toggleCooldown = 0.2f; // Cooldown time in seconds

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>(); // Assuming the Image component is attached to the same GameObject
        button.onClick.AddListener(ToggleSound); // Add the ToggleSound method to the button click event
        buttonImage.sprite = soundOnImage; // Set the initial image
    }

    void ToggleSound()
    {
        if (canToggle)
        {
            isMuted = !isMuted; // Toggle the mute state

            if (isMuted)
            {
                buttonImage.sprite = muteImage; // Change to mute image
                AudioListener.pause = true; // Mute all audio

                foreach (var videoPlayer in videoPlayers)
                {
                    if (videoPlayer != null)
                    {
                        videoPlayer.SetDirectAudioMute(0, true); // Mute the video player audio (track 0)
                    }
                }

                if (volumeControl != null)
                {
                    volumeControl.Mute(); // Mute volume
                }

                Debug.Log("Audio muted");
            }
            else
            {
                buttonImage.sprite = soundOnImage; // Change to sound on image
                AudioListener.pause = false; // Unmute all audio

                foreach (var videoPlayer in videoPlayers)
                {
                    if (videoPlayer != null)
                    {
                        videoPlayer.SetDirectAudioMute(0, false); // Unmute the video player audio (track 0)
                    }
                }

                if (volumeControl != null)
                {
                    volumeControl.Unmute(); // Unmute volume
                }

                Debug.Log("Audio unmuted");
            }

            StartCoroutine(ToggleCooldown());
        }
    }

    IEnumerator ToggleCooldown()
    {
        canToggle = false; // Prevent toggling
        yield return new WaitForSeconds(toggleCooldown); // Wait for the cooldown period
        canToggle = true; // Allow toggling again
    }

    public void SetMuteState(bool mute)
    {
        isMuted = mute;
        buttonImage.sprite = mute ? muteImage : soundOnImage;

        foreach (var videoPlayer in videoPlayers)
        {
            if (videoPlayer != null)
            {
                videoPlayer.SetDirectAudioMute(0, mute); // Mute/unmute the video player audio (track 0)
            }
        }
    }
}

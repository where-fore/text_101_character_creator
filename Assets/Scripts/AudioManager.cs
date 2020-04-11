using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private List<AudioSource> childAudioSources = new List<AudioSource>();
    [SerializeField] private VolumeSlider[] myVolumeSliders = null;

    [SerializeField] private float masterVolume;

    void Start()
    {
        foreach (AudioSource source in GetComponentsInChildren<AudioSource>())
        {
            source.volume = masterVolume; // consider changing to source.volume = source.volume * masterVolume;
        }

    }

    public float GetMasterVolume() { return masterVolume; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField] private AudioManager audioSourceManager = null;
    private Slider mySlider = null; 
    void Start()
    {
        mySlider = GetComponent<Slider>();
        mySlider.value = audioSourceManager.GetMasterVolume();

        foreach (AudioSource source in audioSourceManager.GetComponentsInChildren<AudioSource>())
        {
            audioSources.Add(source);
        }
    }

    void Update()
    {
        SetVolumeToSliderLevel();
    }

    public void SetVolumeToSliderLevel()
    {
        float sliderValue = mySlider.value;
        foreach (AudioSource source in audioSources)
        {
            source.volume = sliderValue;
        }

    }
}

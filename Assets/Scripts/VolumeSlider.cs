using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private List<AudioSource> audioSources = new List<AudioSource>();
    [SerializeField] private GameObject audioSourceManager = null;
    private Slider mySlider = null; 
    void Start()
    {
        mySlider = GetComponent<Slider>();

        foreach (AudioSource source in audioSourceManager.GetComponentsInChildren<AudioSource>())
        {
            audioSources.Add(source);
        }
    }

    void Update()
    {
        float sliderValue = mySlider.value;
        foreach (AudioSource source in audioSources)
        {
            source.volume = sliderValue;
        }
    }
}

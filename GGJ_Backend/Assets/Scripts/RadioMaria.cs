using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMaria : MonoBehaviour {
    public AudioClip[] clip;
    public AudioSource musicSource;
    public int index = 0;
    private AudioSource audio;
    private float oldVolume;
    public float lowVolume;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        oldVolume = musicSource.volume;
    }

    public void PlayRadio()
    {
        if (audio.isPlaying) return;

        enabled = true;
        audio.clip = clip[index];
        audio.Play();
        index = (index + 1) % clip.Length;
        musicSource.volume = lowVolume;
    }

    void Update()
    {
        if (!audio.isPlaying)
        {
            musicSource.volume = oldVolume;
            enabled = false;
        }
    }

}

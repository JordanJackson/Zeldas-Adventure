using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : Singleton<MusicManager>
{
    public AudioClip level1Music;
    public AudioClip level2Music;

    public AudioClip deathMusic;
    public AudioClip hammerMusic;

    AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayDeathMusic()
    {
        audioSource.clip = deathMusic;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayHammerMusic()
    {
        audioSource.clip = hammerMusic;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayLevelMusic()
    {
        audioSource.clip = level1Music;
        audioSource.loop = true;
        audioSource.Play();
    }
}

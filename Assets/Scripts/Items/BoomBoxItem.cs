using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    public AudioClip[] clips;
    private AudioClip currentClip;
    protected AudioSource audioSource;
    int i = 0;
   


    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();


    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayClip();
        }

    }
    /// <summary>
    /// Initial code was random. Was asked for a set playlist. Left code to be able to switch between random play and playlist
    /// </summary>


    public void PlayClip()
    {
        currentClip = clips[Random.Range(0, clips.Length)];
        // audioSource.clip = currentClip;
        audioSource.clip = clips[i];
        audioSource.Play();

    }

    public override void OnUse()
    {
        base.OnUse();

        i++;
        if (i == clips.Length - 1)
        {
            i = 0;
        }


        PlayClip();


    }
}

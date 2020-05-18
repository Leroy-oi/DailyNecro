using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip dig, undig, burn, button, respawn;
    public AudioSource audio;

    void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }

    public void SoundDig()
    {
        audio.clip = dig;
        audio.Play();
    }
    public void SoundRespawn()
    {
        audio.clip = respawn;
        audio.Play();
    }


    public void SoundUnDig()//выкапывание
    {
        audio.clip = undig;
        audio.Play();
    }

    public void SoundBurn()
    {
        audio.clip = burn;
        audio.Play();
    }

    public void SoundButton()
    {
        audio.clip = button;
        audio.Play();
    }

}

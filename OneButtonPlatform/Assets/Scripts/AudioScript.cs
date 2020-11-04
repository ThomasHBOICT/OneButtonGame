using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioSource source;
    public void PlayAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}

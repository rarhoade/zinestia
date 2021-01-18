using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(){
        audioSource.Play();
    }
}

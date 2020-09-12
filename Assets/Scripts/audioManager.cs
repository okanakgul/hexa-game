using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    // Start is called before the first frame update


    // Update is called once per frame
  
    void Awake()
    {
        foreach (AudioClip au in audioClipArray)
        {
            au.LoadAudioData();
        }
    }

    public void Play()
    {
        audioSource.PlayOneShot(audioClipArray[Random.Range(0, audioClipArray.Length)]);
    }
}

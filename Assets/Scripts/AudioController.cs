/*using UnityEngine;


public class AudioController : MonoBehaviour
{


    public AudioClip[] audioclips;
    
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.clip.LoadAudioData();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (int index)
    {
        Sound s = sounds[index];
        s.source.Play();
        Debug.Log("Called");
    }
    
}
*/
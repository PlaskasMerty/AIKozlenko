using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ButtonClip;
    public AudioClip CardClip;
    public static AudioClip StaticCardClip;
    public static AudioSource StaticAudioSource;
    
    public void AudioButton()
    {
        AudioSource.clip = ButtonClip;
        AudioSource.Play();
    }

    public static void AudioCard()
    {
        StaticAudioSource.clip = StaticCardClip;
        StaticAudioSource.Play();
    }

    public void Awake()
    {
        StaticCardClip      = CardClip;
        StaticAudioSource   = AudioSource;
    }
}

using UnityEngine;

public class SaveObjects : MonoBehaviour
{
    public  GameObject[] Objects;
    
    void Start()
    {
        foreach (GameObject Object in GameObject.FindGameObjectsWithTag("ToDestroy"))
        {
            StartCoroutine(FadeAudioSource.StartFade(Object.GetComponent<AudioSource>(), 5.0f, 0.0f));
            Destroy(Object, 5.0f);
        }

        foreach (GameObject Object in Objects)
        {
            DontDestroyOnLoad(Object);
            StartCoroutine(FadeAudioSource.StartFade(Object.GetComponent<AudioSource>(), 3.0f, 0.2f));
            Object.tag = "ToDestroy";
        }
    }
}
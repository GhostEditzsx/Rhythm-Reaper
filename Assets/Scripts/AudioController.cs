using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    public float CurrentTime => audioSource.time;

    public void Play()
    {
        audioSource.Play();
    }
}
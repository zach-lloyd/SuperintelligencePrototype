using UnityEngine;

public class SoundEffectsManager2 : MonoBehaviour
{
    private static SoundEffectsManager2 instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            // PlayOneShot won't interrupt a currently playing sound on this AudioSource
            audioSource.PlayOneShot(clip);
        }
    }
}

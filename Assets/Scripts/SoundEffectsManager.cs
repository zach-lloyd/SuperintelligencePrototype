using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    private static SoundEffectsManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Similar to the music manager, make sure only one sound effects manager 
        // gets created.
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
            // PlayOneShot won't interrupt a currently playing sound on this 
            // AudioSource.
            audioSource.PlayOneShot(clip);
        }
    }
}

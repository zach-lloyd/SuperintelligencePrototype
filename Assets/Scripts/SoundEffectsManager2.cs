using UnityEngine;

// I ultimately ended up having to create separate sound effects managers for 
// each scene to avoid errors, which is why there are 3 of them.
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
            // PlayOneShot won't interrupt a currently playing sound on this 
            // AudioSource.
            audioSource.PlayOneShot(clip);
        }
    }
}

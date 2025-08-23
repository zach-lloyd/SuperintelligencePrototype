using UnityEngine;

// Create a single music manager that persists across different scenes without 
// restarting.
public class MusicManager : MonoBehaviour
{
    // Use static to ensure this variable belongs to the class itself rather than
    // any specific object instance.
    public static MusicManager instance;

    // Holds the audio source component that will play my game's audio clips.
    private AudioSource audioSource;

    // Called by Unity automatically when the script is first loaded, before the
    // game starts.
    void Awake()
    {
        // If the instance variable hasn't been set yet, set it to this object.
        if (instance == null)
        {
            instance = this;
            // Make sure Unity doesn't destroy this object when a new scene is 
            // loaded, so music keeps playing when switching scenes.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // When a new scene is loaded, it will try to create a new music 
            // manager. This ensures a new one is not created and that the initial
            // music manager is the only music manager created throughout the entire
            // game.
            Destroy(gameObject);
        }

        // Finds the AudioSource component on the GameObject that this script is 
        // attached to.
        audioSource = GetComponent<AudioSource>();
    }

    // Function that other scripts can call to stop music from playing.
    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

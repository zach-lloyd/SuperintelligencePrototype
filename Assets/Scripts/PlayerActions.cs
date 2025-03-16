using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip shutdownSuccessClip;
    public AudioClip shutdownFailClip;

    public void OnAddComputePressed()
    {
        // Increase power, possibly reduce alignment, etc.
        // For example:
        // gameManager.power++;
        // Some random check for alignment drop
        // Then call gameManager.NextTurn();
        Debug.Log("Add Compute Pressed");
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.power++;
        int roll = Random.Range(0, 6);

        if (roll == 0)
        {
            gameManager.alignment--;
        }

        Debug.Log(gameManager.power);
        Debug.Log(gameManager.alignment);

        gameManager.EndPlayerAction();
    }

    public void OnEnhanceAlignmentPressed()
    {
        // Increase alignment, possibly reduce power
        // Then call gameManager.NextTurn();
        Debug.Log("Enhance Alignment Pressed");
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.alignment++;
        int roll = Random.Range(0, 6);

        if (roll == 0)
        {
            gameManager.power--;
        }

        Debug.Log(gameManager.power);
        Debug.Log(gameManager.alignment);

        gameManager.EndPlayerAction();
    }

    public void OnShutDownPressed()
    {
        // Attempt shutdown logic (depends on alignment?)
        // If success, gameManager.EndGame();
        // else, gameManager.NextTurn();
        int roll = Random.Range(0, 60);

        if (roll <= gameManager.alignment || 
            gameManager.itemsPurchased.Contains("Shutdown Failsafe"))
        {
            gameManager.aiActionText.text = "";
            MusicManager.instance.StopMusic();
            SoundEffectsManager3.instance.PlaySFX(shutdownSuccessClip);
            gameManager.EndGame("The AI was successfully shut down");
        }
        else 
        {
            gameManager.unsuccessfulShutdown.SetActive(true);
            SoundEffectsManager3.instance.PlaySFX(shutdownFailClip);
            gameManager.DeactivateButtons();
            gameManager.alignment--;
        }
        Debug.Log("Shut Down Pressed");
        Debug.Log(gameManager.power);
        Debug.Log(gameManager.alignment);
    }

    public void OnDoNothingPressed()
    {
        // Simply pass the turn
        Debug.Log("Do Nothing Pressed");
        Debug.Log(gameManager.power);
        Debug.Log(gameManager.alignment);
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.EndPlayerAction();
    }
}

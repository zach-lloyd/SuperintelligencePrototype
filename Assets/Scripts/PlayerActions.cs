using UnityEngine;

// On each turn, the player can choose whether to add compute to power up the AI,
// enhance the AI's alignment, try to shut down the AI, or do nothing. Each 
// decision has different effects on the state of the AI. This class has functions
// that handle each player choice.

// Note: Regardless of which button the player presses, I need to address the 
// possibility that the previous turn saw the player unsuccessfully attempt to
// shut the AI down, prompting the unsuccessfulShutdown window to pop up. That's
// why each function below contains a line setting that window to be inactive.
public class PlayerActions : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip shutdownSuccessClip;
    public AudioClip shutdownFailClip;

    public void OnAddComputePressed()
    {
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.power++;
        int roll = Random.Range(0, 6);

        // When the player adds compute, it increases the AI's power by 1, but
        // it also has a 1/6 chance of decreasing its alignment by 1.
        if (roll == 0)
        {
            gameManager.alignment--;
        }

        gameManager.EndPlayerAction();
    }

    public void OnEnhanceAlignmentPressed()
    {
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.alignment++;
        int roll = Random.Range(0, 6);

        // When the player enhances alignment, it increases the AI's alignment 
        // by 1, but it also has a 1/6 chance of decreasing its power by 1.
        if (roll == 0)
        {
            gameManager.power--;
        }

        gameManager.EndPlayerAction();
    }

    public void OnShutDownPressed()
    {
        int roll = Random.Range(0, 60);

        // When the user attempts to shut the AI down, whether the shutdown 
        // attempt is successful is determined randomly in relation to the AI's
        // current alignment level, unless the user has purchased the Shutdown
        // Failsafe item, in which case the shutdown is guaranteed to be 
        // successful.
        if (roll <= gameManager.alignment ||
            gameManager.itemsPurchased.Contains("Shutdown Failsafe"))
        {
            // Make sure to clear out the text describing the AI's action from
            // the prior turn.
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
            // If the user tries to shut down the AI and is unsuccessful, it
            // reduces the AI's future alignment.
            gameManager.alignment--;
        }
    }

    // If the user clicks the Do Nothing button, it basically amounts to 
    // passing the turn. There is no change in the AI's power or alignment, but
    // the AI still may take an action during that turn and an AI event still 
    // may be triggered.
    public void OnDoNothingPressed()
    {
        gameManager.unsuccessfulShutdown.SetActive(false);
        gameManager.EndPlayerAction();
    }
}

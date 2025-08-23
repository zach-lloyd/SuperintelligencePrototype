using UnityEngine;
using TMPro;

// Display the player's final score and the overall result of the game 
// (singularity, doomsday, AI shut down, etc.) at the end of the game.
public class ResultsPanelController : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI outcomeText;

    public void SetupResults(int score, string outcomeMessage)
    {
        finalScoreText.text = "Final Score: " + score.ToString();
        outcomeText.text = outcomeMessage;
    }
}

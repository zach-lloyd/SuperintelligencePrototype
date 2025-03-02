using UnityEngine;
using TMPro;

public class ResultsPanelController : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI outcomeText;

    // Called when we activate or show the panel
    public void SetupResults(int score, string outcomeMessage)
    {
        finalScoreText.text = "Final Score: " + score.ToString();
        outcomeText.text = outcomeMessage;
    }
}

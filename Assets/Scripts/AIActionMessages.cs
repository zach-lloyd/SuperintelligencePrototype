using UnityEngine;

// Text messages that tell the user which type of action the AI took on each turn.
// The effect on the user's score is specified in parentheses.
public class AIActionMessages : MonoBehaviour
{
    public string minorGoodMessage = "The AI performed a minor good act (+1)";
    public string majorGoodMessage = "The AI performed a major good act (+5)";
    public string minorBadMessage = "The AI performed a minor bad act (-1)";
    public string majorBadMessage = "The AI performed a major bad act (-5)";
    public string noActionMessage = "The AI took no action this turn (0)";
}

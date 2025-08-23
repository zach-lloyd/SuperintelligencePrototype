using UnityEngine;

// Template for creating events that pop up randomly during the game and allow 
// the user to chose one of a few different ways to respond. The response they 
// choose can potentially influence their score and the AI's future behavior.
[CreateAssetMenu(fileName = "NewAIEvent", menuName = "AI Events/AI Event")]
public class AIEventData : ScriptableObject
{
    [Header("Basic Info")]
    public string eventTitle;
    [TextArea] public string eventDescription;

    [Header("Choices")]
    public AIEventChoice[] choices;
}

[System.Serializable]
public class AIEventChoice
{
    public string choiceText;

    public int scoreChange;
    public int powerChange;
    public int alignmentChange;
}

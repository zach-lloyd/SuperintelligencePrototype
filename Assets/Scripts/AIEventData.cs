using UnityEngine;

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

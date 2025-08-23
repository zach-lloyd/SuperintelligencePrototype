using UnityEngine;
using System.Collections.Generic;

public class AIEventManager : MonoBehaviour
{
    [Header("Available Events")]
    [Tooltip("Populate this array with references to your AIEventData assets.")]
    public AIEventData[] allEvents;
    public List<AIEventData> availableEvents;

    [Header("UI Popup In Scene")]
    [Tooltip("Drag the EventPopup Panel from your Canvas here.")]
    public AIEventPopup eventPopup;

    void Awake()
    {
        availableEvents = new List<AIEventData>(allEvents);
    }

    // Returns a random event from the allEvents array if any events are available.
    public AIEventData GetRandomEvent()
    {
        if (availableEvents == null || availableEvents.Count == 0)
            return null;

        int index = Random.Range(0, availableEvents.Count);
        AIEventData chosenEvent = availableEvents[index];
        // Remove the event so it can't occur more than once in a single game.
        availableEvents.RemoveAt(index);

        return chosenEvent;
    }

    // Call this to display a specific AI Event on the popup panel.
    public void TriggerEvent(AIEventData eventData)
    {
        if (eventData == null)
        {
            Debug.LogWarning("No event data provided to TriggerEvent.");
            return;
        }

        // Make sure the popup panel is active so it's visible.
        eventPopup.gameObject.SetActive(true);

        // Pass the event data to the popup so it can fill in UI.
        eventPopup.SetupPopup(eventData);
    }
}

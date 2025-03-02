using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class AIEventPopup : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI descriptionText;

    public Button choiceButton1;
    public Button choiceButton2;
    public Button choiceButton3;

    // A method to populate the UI
    public void SetupPopup(AIEventData eventData)
    {
        descriptionText.text = eventData.eventDescription;

        // For each choice, set the button text and onClick logic
        if (eventData.choices.Length > 0)
        {
            choiceButton1.gameObject.SetActive(true);
            // Suppose you have a child text element or a TextMeshProUGUI on the button
            TextMeshProUGUI btnText = choiceButton1.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = eventData.choices[0].choiceText;

            // Clear old listeners
            choiceButton1.onClick.RemoveAllListeners();
            // Add a new listener to handle outcome
            int index = 0; // index of choice
            choiceButton1.onClick.AddListener(() => OnChoiceSelected(eventData, index));
        }
        else
        {
            choiceButton1.gameObject.SetActive(false);
        }

        if (eventData.choices.Length > 1)
        {
            choiceButton2.gameObject.SetActive(true);
            TextMeshProUGUI btnText = choiceButton2.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = eventData.choices[1].choiceText;

            choiceButton2.onClick.RemoveAllListeners();
            int index = 1;
            choiceButton2.onClick.AddListener(() => OnChoiceSelected(eventData, index));
        }
        else
        {
            choiceButton2.gameObject.SetActive(false);
        }

        if (eventData.choices.Length > 2)
        {
            choiceButton3.gameObject.SetActive(true);
            TextMeshProUGUI btnText = choiceButton3.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = eventData.choices[2].choiceText;

            choiceButton3.onClick.RemoveAllListeners();
            int index = 2;
            choiceButton3.onClick.AddListener(() => OnChoiceSelected(eventData, index));
        }
        else
        {
            choiceButton3.gameObject.SetActive(false);
        }
    }

    // Called when a choice is clicked
    private void OnChoiceSelected(AIEventData eventData, int choiceIndex)
    {
        AIEventChoice choice = eventData.choices[choiceIndex];
        GameManager.Instance.AddScore(choice.scoreChange);
        GameManager.Instance.power += choice.powerChange;
        GameManager.Instance.alignment += choice.alignmentChange;
        GameManager.Instance.NextTurn();

        // Hide or destroy the popup
        ClosePopup();
    }

    public void ClosePopup()
    {
        // e.g., gameObject.SetActive(false);
        // or Destroy(gameObject) if it's instantiated dynamically
        gameObject.SetActive(false);
    }
}


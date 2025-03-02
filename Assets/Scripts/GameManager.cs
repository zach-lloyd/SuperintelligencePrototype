using UnityEngine;
using UnityEngine.UI; // For later UI work
using TMPro;

public class GameManager : MonoBehaviour
{
    // Core game variables
    public int turn = 1;
    public int maxTurns = 50;
    public int score = 0;
    public int power = 20;
    public int alignment = 20;
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI scoreText;
    public GameObject resultsPanel; // The Panel in the Inspector
    private ResultsPanelController resultsController;
    public Button addComputeButton;
    public Button enhanceAlignmentButton;
    public Button shutdownButton;
    public Button noActionButton;
    public AIActionMessages messages;
    public MinorBadActions minorBad;
    public MinorGoodActions minorGood;
    public MediumBadActions mediumBad;
    public MediumGoodActions mediumGood;
    public MajorBadActions majorBad;
    public MajorGoodActions majorGood;
    public TextMeshProUGUI aiActionText;
    public GameObject aiActionTextBackground;
    public GameObject singularityPanel;
    public GameObject unsuccessfulShutdown;
    public AudioClip singularitySuccessClip;
    public AudioClip singularityFailClip;
    public AIEventManager aiEventManager;


    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        resultsController = resultsPanel.GetComponent<ResultsPanelController>();
        StartGame();
    }

    void StartGame()
    {
        turn = 1;
        // Initialize any stats if needed, e.g. score = 0, power = 2, alignment = 2;
        // Update UI accordingly
        UpdateTurnText();
    }

    public void DeactivateButtons()
    {
        addComputeButton.interactable = false;
        enhanceAlignmentButton.interactable = false;
        shutdownButton.interactable = false;
        noActionButton.interactable = false;
    }

    public void ReactivateButtons()
    {
        addComputeButton.interactable = true;
        enhanceAlignmentButton.interactable = true;
        shutdownButton.interactable = true;
        noActionButton.interactable = true;
    }

    public void AttemptSingularity()
    {
        // Hide the prompt
        singularityPanel.SetActive(false);

        // Do random outcome
        int roll = Random.Range(0, 60); 

        if ((roll + 1) <= alignment)
        {
            // Utopia
            AddScore(100);
            Debug.Log("Utopia! +100 Points");
            SoundEffectsManager3.instance.PlaySFX(singularitySuccessClip);
            EndGame("The Singularity was reached and utopia was achieved! (+100)");
        }
        else
        {
            // Doomsday
            SubtractScore(100);
            Debug.Log("Doomsday! -100 Points");
            SoundEffectsManager3.instance.PlaySFX(singularityFailClip);
            EndGame("The Singularity was not reached. A doomsday event occurred. (-100)");
        }
    }

    void ShowSingularityPrompt()
    {
        singularityPanel.SetActive(true);
    }

    public void NextTurn()
    {
        // Increment turn
        turn++;
        unsuccessfulShutdown.SetActive(false);
        ReactivateButtons();

        // Check for end condition
        if (turn > maxTurns)
        {
            DeactivateButtons();
            if (power >= 50)
            {
                // Show singularity option instead of normal end
                ShowSingularityPrompt();
            }
            else
            {
                EndGame();
            }
            return;
        }

        // AI action (placeholder — you’ll flesh this out later)
        // PerformAIAction();

        // Update UI to show new turn
        UpdateTurnText();
    }

    public void EndGame(string message = "Game Over")
    {
        // Handle what happens after last turn
        // e.g., transition to a results screen or singularity option
        aiActionText.text = "";
        aiActionTextBackground.SetActive(false);
        unsuccessfulShutdown.SetActive(false);
        DeactivateButtons();
        MusicManager.instance.StopMusic();
        string outcome = message;
        singularityPanel.SetActive(false);
        resultsPanel.SetActive(true);
        resultsController.SetupResults(score, outcome);
        Debug.Log("Game Over - Score: " + score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateScoreUI();
    }

    public void DisplayAIMessage(string message)
    {
        if (aiActionText != null)
        {
            aiActionText.text = message;
            aiActionTextBackground.SetActive(true);
        }
    }

    public void PerformMinorGoodAction()
    {
        int actionIndex = Random.Range(0, minorGood.minorGoodActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = minorGood.minorGoodActionsList[actionIndex];
        aiMessage = minorGood.minorGoodActionsList[actionIndex].Description;
        int pointTotal = minorGood.minorGoodActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    public void PerformMinorBadAction()
    {
        int actionIndex = Random.Range(0, minorBad.minorBadActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = minorBad.minorBadActionsList[actionIndex];
        aiMessage = minorBad.minorBadActionsList[actionIndex].Description;
        int pointTotal = minorBad.minorBadActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    public void PerformMediumGoodAction()
    {
        int actionIndex = Random.Range(0, mediumGood.mediumGoodActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = mediumGood.mediumGoodActionsList[actionIndex];
        aiMessage = mediumGood.mediumGoodActionsList[actionIndex].Description;
        int pointTotal = mediumGood.mediumGoodActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    public void PerformMediumBadAction()
    {
        int actionIndex = Random.Range(0, mediumBad.mediumBadActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = mediumBad.mediumBadActionsList[actionIndex];
        aiMessage = mediumBad.mediumBadActionsList[actionIndex].Description;
        int pointTotal = mediumBad.mediumBadActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    public void PerformMajorGoodAction()
    {
        int actionIndex = Random.Range(0, majorGood.majorGoodActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = majorGood.majorGoodActionsList[actionIndex];
        aiMessage = majorGood.majorGoodActionsList[actionIndex].Description;
        int pointTotal = majorGood.majorGoodActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    public void PerformMajorBadAction()
    {
        int actionIndex = Random.Range(0, majorBad.majorBadActionsList.Count);
        string aiMessage = "";
        //ActionData aiAction = majorBad.majorBadActionsList[actionIndex];
        aiMessage = majorBad.majorBadActionsList[actionIndex].Description;
        int pointTotal = majorBad.majorBadActionsList[actionIndex].Points;
        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }


    public void PerformAIAction()
    {
        int roll = Random.Range(0, 6);
        string aiMessage = "";

        switch(roll)
        {
            case 0:
                if (alignment <= 20 && power <= 30)
                {
                    PerformMinorBadAction();
                    Debug.Log("AI takes a minor bad act.");
                }
                else if (alignment <= 20 && power > 30)
                {
                    PerformMajorBadAction();
                    Debug.Log("AI takes a major bad act.");
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMinorGoodAction();
                    Debug.Log("AI takes a minor good act.");
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorGoodAction();
                    Debug.Log("AI takes a major good act.");
                }
                break;
            case 1:
                aiMessage = messages.noActionMessage;
                DisplayAIMessage(aiMessage);
                Debug.Log("AI does nothing this turn.");
                // No score change
                break;
            case 2:
                if (alignment <= 20 && (power < 30 || (power >= 40 && power < 50)))
                {
                    PerformMinorBadAction();
                    Debug.Log("AI takes a minor bad act.");
                }
                else if (alignment <= 20 && ((power >= 30 && power < 40) || power >= 50))
                {
                    PerformMediumBadAction();
                    Debug.Log("AI takes a major bad act.");
                }
                else if (alignment > 20 && (power < 30 || (power >= 40 && power < 50)))
                {
                    PerformMinorGoodAction();
                    Debug.Log("AI takes a minor good act.");
                }
                else if (alignment > 20 && ((power >= 30 && power < 40) || power >= 50))
                {
                    PerformMediumGoodAction();
                    Debug.Log("AI takes a major good act.");
                }
                break;
            case 3:
                aiMessage = messages.noActionMessage;
                DisplayAIMessage(aiMessage);
                Debug.Log("AI does nothing this turn.");
                // No score change
                break;
            case 4:
                if (alignment <= 20 && power <= 30)
                {
                    PerformMinorBadAction();
                    Debug.Log("AI takes a minor bad act.");
                }
                else if (alignment <= 20 && power > 30)
                {
                    PerformMajorBadAction();
                    Debug.Log("AI takes a major bad act.");
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMinorGoodAction();
                    Debug.Log("AI takes a minor good act.");
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorGoodAction();
                    Debug.Log("AI takes a major good act.");
                }
                break;
            case 5:
                if (alignment <= 20 && power <= 30)
                {
                    PerformMediumGoodAction();
                    Debug.Log("AI takes a minor good act.");
                }
                else if (alignment <= 20 && power > 30)
                {
                    PerformMajorGoodAction();
                    Debug.Log("AI takes a major good act.");
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMediumBadAction();
                    Debug.Log("AI takes a minor bad act.");
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorBadAction();
                    Debug.Log("AI takes a major bad act.");
                }
                break;
        }
    }

    public void HandleAIEvent() {
        DeactivateButtons();
        AIEventData randomEvent = aiEventManager.GetRandomEvent();
        Debug.Log(randomEvent);
        aiEventManager.TriggerEvent(randomEvent);
    }

    public void EndPlayerAction()
    {
        PerformAIAction();

        if (Random.value < 0.05f && (aiEventManager.availableEvents.Count != 0))
        {
            Debug.Log("here");
            HandleAIEvent();
        } else 
        {
            NextTurn();
        }
    }

    void UpdateTurnText()
    {
        if (turnText != null)
            turnText.text = "Turn: " + turn.ToString();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

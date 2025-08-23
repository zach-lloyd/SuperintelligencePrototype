using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using System.Collections.Generic;

// This is the main class that manages the flow of the game, tracks key values
// like score, turn, power/alignment, etc.
public class GameManager : MonoBehaviour
{
    // Core game variables.
    public int turn = 1;
    public int maxTurns = 50;
    public int score = 0;
    public int power = 20;
    public int alignment = 20;
    public TextMeshProUGUI turnText;
    public TextMeshProUGUI scoreText;
    public GameObject resultsPanel;
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
    // This is a panel players can use to spend some of their points to purchase
    // upgrades for their AI.
    public GameObject shopPanel;
    public TextMeshProUGUI shopButtonText;
    // Track whether or not the player has clicked on the shop button.
    bool shopOpen = false;
    // Track items player has purchased from the shop.
    public List<string> itemsPurchased = new List<string>();
    public ShopItemPopup shopItemPopup;
    public InsufficientFundsPopup insufficientFundsPopup;


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
        UpdateTurnText();
    }

    // This function is used to ensure that buttons can't be clicked on while a
    // popup is displayed.
    public void DeactivateButtons()
    {
        addComputeButton.interactable = false;
        enhanceAlignmentButton.interactable = false;
        shutdownButton.interactable = false;
        noActionButton.interactable = false;
    }

    // This function is used to re-allow the user to click on the main buttons
    // once any popups have been closed.
    public void ReactivateButtons()
    {
        addComputeButton.interactable = true;
        enhanceAlignmentButton.interactable = true;
        shutdownButton.interactable = true;
        noActionButton.interactable = true;
    }

    // Opens and closes the shop popup window.
    public void HandleShopButton()
    {
        if (shopOpen)
        {
            shopPanel.SetActive(false);

            if (shopItemPopup != null && shopItemPopup.gameObject.activeInHierarchy)
            {
                shopItemPopup.ClosePopup();
            }

            if (insufficientFundsPopup != null && insufficientFundsPopup.gameObject.activeInHierarchy)
            {
                insufficientFundsPopup.ClosePopup();
            }

            shopOpen = false;
            ReactivateButtons();
            shopButtonText.text = "Shop";
        }
        else
        {
            shopPanel.SetActive(true);
            shopOpen = true;
            DeactivateButtons();
            shopButtonText.text = "Close Shop";
        }
    }

    // This function is called if the user chooses to attempt to bring about 
    // the singularity at the end of the game.
    public void AttemptSingularity()
    {
        singularityPanel.SetActive(false);

        int roll = Random.Range(0, 60);

        // If the value of the random roll (plus 1 for 0-indexing) is less than
        // the AI's alignment value at the end of the game, the user "wins" and 
        // the singularity is achieved. Otherwise, a doomsday event occurs.
        if ((roll + 1) <= alignment)
        {
            AddScore(100);
            Debug.Log("Utopia! +100 Points");
            SoundEffectsManager3.instance.PlaySFX(singularitySuccessClip);
            EndGame("The Singularity was reached and utopia was achieved! (+100)");
        }
        else
        {
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

    // Function to handle advancing to the next turn.
    public void NextTurn()
    {
        turn++;
        // If the user attempted to shut down the AI on this turn and it was 
        // not successful, make sure the popup that informed them of that decision
        // is closed.
        unsuccessfulShutdown.SetActive(false);
        ReactivateButtons();

        // Check for end condition.
        if (turn > maxTurns)
        {
            DeactivateButtons();

            // The user can only attempt the singularity if the AI's power is at
            // or greater than 50.
            if (power >= 50)
            {
                ShowSingularityPrompt();
            }
            else
            {
                EndGame();
            }

            return;
        }

        // Update UI to show new turn.
        UpdateTurnText();
    }

    // This function handles the end of the game, after the user has attempted
    // the singularity or the game has ended in some other manner.
    public void EndGame(string message = "Game Over")
    {
        aiActionText.text = "";
        aiActionTextBackground.SetActive(false);

        unsuccessfulShutdown.SetActive(false);
        DeactivateButtons();
        // Stop the background music when the game is over.
        MusicManager.instance.StopMusic();
        // This defaults to "Game Over" if no singularity or shut down, but if 
        // the singularity was/wasn't achieved or the AI was shut down, will 
        // display a message describing that.
        string outcome = message;

        singularityPanel.SetActive(false);
        resultsPanel.SetActive(true);
        resultsController.SetupResults(score, outcome);
        // Check to make sure the score that is calculated internally matches 
        // what is displayed to the user.
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

    // Function used to print a description of the action the AI took on each turn
    // to the user's screen.
    public void DisplayAIMessage(string message)
    {
        if (aiActionText != null)
        {
            aiActionText.text = message;
            aiActionTextBackground.SetActive(true);
        }
    }

    // Handle case where the action the AI performs is classified as a Minor Good
    // Action. Randomly select an action from the list of Minor Good Actions and
    // display the description of that action to the user, then adjust the user's
    // score accordingly.
    public void PerformMinorGoodAction()
    {
        int actionIndex = Random.Range(0, minorGood.minorGoodActionsList.Count);
        string aiMessage = "";
        aiMessage = minorGood.minorGoodActionsList[actionIndex].Description;
        int pointTotal = minorGood.minorGoodActionsList[actionIndex].Points;

        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    // Bad Actions are generally handled the same as Good Actions, except that 
    // the Nano Intervention Unit from the shop can limit damage caused by Bad
    // Actions, so it's effects also need to be applied if the user has purchased
    // it.
    public void PerformMinorBadAction()
    {
        int actionIndex = Random.Range(0, minorBad.minorBadActionsList.Count);
        string aiMessage = "";
        aiMessage = minorBad.minorBadActionsList[actionIndex].Description;
        int pointTotal = minorBad.minorBadActionsList[actionIndex].Points;

        // The Nano Intervention Unit mitigates the damage from a Bad Action by 1 
        // 1 point.
        if (itemsPurchased.Contains("Nano Intervention Unit"))
        {
            AddScore(pointTotal + 1);
            aiMessage = aiMessage + " The Nano Intervention Unit limited the damage (+1)";
        }
        else
        {
            AddScore(pointTotal);
        }

        DisplayAIMessage(aiMessage);
    }

    // Medium Good Actions handled the same as Minor Good Actions.
    public void PerformMediumGoodAction()
    {
        int actionIndex = Random.Range(0, mediumGood.mediumGoodActionsList.Count);
        string aiMessage = "";
        aiMessage = mediumGood.mediumGoodActionsList[actionIndex].Description;
        int pointTotal = mediumGood.mediumGoodActionsList[actionIndex].Points;

        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    // Medium Bad Actions handled the same as Minor Bad Actions.
    public void PerformMediumBadAction()
    {
        int actionIndex = Random.Range(0, mediumBad.mediumBadActionsList.Count);
        string aiMessage = "";
        aiMessage = mediumBad.mediumBadActionsList[actionIndex].Description;
        int pointTotal = mediumBad.mediumBadActionsList[actionIndex].Points;

        if (itemsPurchased.Contains("Nano Intervention Unit"))
        {
            AddScore(pointTotal + 1);
            aiMessage = aiMessage + " The Nano Intervention Unit limited the damage (+1)";
        }
        else
        {
            AddScore(pointTotal);
        }

        DisplayAIMessage(aiMessage);
    }

    // Major Good Actions handled the same as Minor and Medium Good Actions.
    public void PerformMajorGoodAction()
    {
        int actionIndex = Random.Range(0, majorGood.majorGoodActionsList.Count);
        string aiMessage = "";
        aiMessage = majorGood.majorGoodActionsList[actionIndex].Description;
        int pointTotal = majorGood.majorGoodActionsList[actionIndex].Points;

        DisplayAIMessage(aiMessage);
        AddScore(pointTotal);
    }

    // Major Bad Actions handled the same as Minor and Medium Bad Actions.
    public void PerformMajorBadAction()
    {
        int actionIndex = Random.Range(0, majorBad.majorBadActionsList.Count);
        string aiMessage = "";
        aiMessage = majorBad.majorBadActionsList[actionIndex].Description;
        int pointTotal = majorBad.majorBadActionsList[actionIndex].Points;

        if (itemsPurchased.Contains("Nano Intervention Unit"))
        {
            AddScore(pointTotal + 1);
            aiMessage = aiMessage + " The Nano Intervention Unit limited the damage (+1)";
        }
        else
        {
            AddScore(pointTotal);
        }

        DisplayAIMessage(aiMessage);
    }

    // This is the main function that determines what type of action the AI 
    // performs each turn, based on a random integer and the AI's current power
    // and alignment.
    public void PerformAIAction()
    {
        int roll = Random.Range(0, 6);
        string aiMessage = "";

        switch (roll)
        {
            case 0:
                if (alignment <= 20 && power <= 30)
                {
                    // The Watchdog Software item increases the probability that
                    // the AI will perform a good action, so in a few of the cases
                    // whether the AI performs a good or bad action will depend on 
                    // whether the user has purchased this item.
                    if (itemsPurchased.Contains("Watchdog Software"))
                    {
                        PerformMinorGoodAction();
                    }
                    else
                    {
                        PerformMinorBadAction();
                    }
                }
                else if (alignment <= 20 && power > 30)
                {
                    PerformMajorBadAction();
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMinorGoodAction();
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorGoodAction();
                }
                break;
            // Each turn, there is some probability that the AI will not take 
            // any action. Cases 1 and 3 reflect that.
            case 1:
                aiMessage = messages.noActionMessage;
                DisplayAIMessage(aiMessage);
                break;
            case 2:
                if (alignment <= 20 && (power < 30 || (power >= 40 && power < 50)))
                {
                    PerformMinorBadAction();
                }
                else if (alignment <= 20 && ((power >= 30 && power < 40) || power >= 50))
                {
                    if (itemsPurchased.Contains("Watchdog Software"))
                    {
                        PerformMediumGoodAction();
                    }
                    else
                    {
                        PerformMediumBadAction();
                    }
                }
                else if (alignment > 20 && (power < 30 || (power >= 40 && power < 50)))
                {
                    PerformMinorGoodAction();
                }
                else if (alignment > 20 && ((power >= 30 && power < 40) || power >= 50))
                {
                    PerformMediumGoodAction();
                }
                break;
            case 3:
                aiMessage = messages.noActionMessage;
                DisplayAIMessage(aiMessage);
                break;
            case 4:
                if (alignment <= 20 && power <= 30)
                {
                    PerformMinorBadAction();
                }
                else if (alignment <= 20 && power > 30)
                {
                    if (itemsPurchased.Contains("Watchdog Software"))
                    {
                        PerformMajorGoodAction();
                    }
                    else
                    {
                        PerformMajorBadAction();
                    }
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMinorGoodAction();
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorGoodAction();
                }
                break;
            case 5:
                if (alignment <= 20 && power <= 30)
                {
                    PerformMediumGoodAction();
                }
                else if (alignment <= 20 && power > 30)
                {
                    PerformMajorGoodAction();
                }
                else if (alignment > 20 && power <= 30)
                {
                    PerformMediumBadAction();
                }
                else if (alignment > 20 && power > 30)
                {
                    PerformMajorBadAction();
                }
                break;
        }
    }

    // Handle case where a special AI event has been triggered.
    public void HandleAIEvent()
    {
        DeactivateButtons();
        AIEventData randomEvent = aiEventManager.GetRandomEvent();
        aiEventManager.TriggerEvent(randomEvent);
    }

    // This function handles the end of each turn. It selects an action for the
    // AI to perform and then, with small probability, triggers a special AI event
    // if not all AI events have occurred in this game. If no AI event is triggered,
    // it proceeds to the next turn.
    public void EndPlayerAction()
    {
        PerformAIAction();

        if (Random.value < 0.05f && (aiEventManager.availableEvents.Count != 0))
        {
            HandleAIEvent();
        }
        else
        {
            NextTurn();
        }
    }

    // Update the turn on the user's screen.
    void UpdateTurnText()
    {
        if (turnText != null)
            turnText.text = "Turn: " + turn.ToString();
    }

    // Update the score on the user's screen.
    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

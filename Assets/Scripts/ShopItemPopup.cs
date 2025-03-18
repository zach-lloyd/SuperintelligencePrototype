using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class ShopItemPopup : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public TextMeshProUGUI itemCost;
    public Button purchaseItemButton;

    public GameManager gameManager;
    public InsufficientFundsPopup insufficientFundsPopup;

    public void SetupPopup(ShopItemData itemData, GameObject itemUI)
    {
        itemName.text = itemData.itemName;
        itemDescription.text = itemData.itemDescription;
        itemCost.text = "Price: " + itemData.itemPrice.ToString() + " points";
        purchaseItemButton.onClick.RemoveAllListeners();
        purchaseItemButton.onClick.AddListener(OnButtonClicked);

        void OnButtonClicked() {
            OnPurchased(itemData, itemUI);
        }
    }

    public void OnPurchased(ShopItemData itemData, GameObject itemUI)
    {
        if (itemData.itemPrice > gameManager.score) 
        {
            Debug.Log("Insufficient Funds!");
            ClosePopup();
            insufficientFundsPopup.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log(itemData.itemPrice);
            GameManager.Instance.SubtractScore(itemData.itemPrice);
            GameManager.Instance.itemsPurchased.Add(itemData.itemName);

            if (itemData.itemName == "Quantum Chip") 
            {
                gameManager.power += 5;
                gameManager.alignment += 5;
            } else if (itemData.itemName == "Compute Overclock")
            {
                gameManager.power += 10;
                gameManager.alignment -= 3;
            }

            if (itemUI != null)
            {
                itemUI.SetActive(false);
            }

            // Hide or destroy the popup
            ClosePopup();
        }
    }

    public void ClosePopup()
    {
        // e.g., gameObject.SetActive(false);
        // or Destroy(gameObject) if it's instantiated dynamically
        gameObject.SetActive(false);
    }
}

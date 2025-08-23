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
    public AudioClip purchaseSuccessClip;
    public AudioClip purchaseFailClip;

    // Populate the item pop up with the information of the item that the player
    // clicked on.
    public void SetupPopup(ShopItemData itemData, GameObject itemUI)
    {
        itemName.text = itemData.itemName;
        itemDescription.text = itemData.itemDescription;
        itemCost.text = "Price: " + itemData.itemPrice.ToString() + " points";
        // Deactivate other event listeners while the item popup is displayed.
        purchaseItemButton.onClick.RemoveAllListeners();
        purchaseItemButton.onClick.AddListener(OnButtonClicked);
        // Handle player's attempt to purchase the item.
        void OnButtonClicked()
        {
            OnPurchased(itemData, itemUI);
        }
    }

    public void OnPurchased(ShopItemData itemData, GameObject itemUI)
    {
        // Players have to have enough points to afford the item's price. This 
        // branch handles case where the player tries to buy an item they can't
        // afford.
        if (itemData.itemPrice > gameManager.score)
        {
            SoundEffectsManager3.instance.PlaySFX(purchaseFailClip);
            ClosePopup();
            // Inform the player they don't have enough points to buy this item.
            insufficientFundsPopup.gameObject.SetActive(true);
        }
        // Handle case where the purchase is successful.
        else
        {
            SoundEffectsManager3.instance.PlaySFX(purchaseSuccessClip);
            GameManager.Instance.SubtractScore(itemData.itemPrice);
            GameManager.Instance.itemsPurchased.Add(itemData.itemName);

            // The Quantum Chip and Compute Overclock items change the AI's state.
            // This code implements those changes.
            if (itemData.itemName == "Quantum Chip")
            {
                gameManager.power += 5;
                gameManager.alignment += 5;
            }
            else if (itemData.itemName == "Compute Overclock")
            {
                gameManager.power += 10;
                gameManager.alignment -= 3;
            }

            if (itemUI != null)
            {
                itemUI.SetActive(false);
            }

            ClosePopup();
        }
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

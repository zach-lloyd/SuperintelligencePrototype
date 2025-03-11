using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class ShopItemPopup : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public TextMeshProUGUI itemCost;

    public void SetupPopup(ShopItemData itemData)
    {
        itemName.text = itemData.itemName;
        itemDescription.text = itemData.itemDescription;
        itemCost.text = itemData.itemPrice.ToString();
    }

    public void ClosePopup()
    {
        // e.g., gameObject.SetActive(false);
        // or Destroy(gameObject) if it's instantiated dynamically
        gameObject.SetActive(false);
    }
}

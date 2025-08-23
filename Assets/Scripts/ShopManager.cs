using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItemPopup itemPopup;

    public void HandleItemClick(ShopItemData itemData)
    {
        // Debug/handle error where item data was not successfully passed.
        if (itemData == null)
        {
            Debug.LogWarning("No shop item data provided to HandleItemClick.");
            return;
        }
        
        itemPopup.gameObject.SetActive(true);
    }
}

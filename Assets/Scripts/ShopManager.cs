using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItemPopup itemPopup;

    public void HandleItemClick(ShopItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogWarning("No shop item data provided to HandleItemClick.");
            return;
        }
        // Make sure the popup panel is active so it's visible
        itemPopup.gameObject.SetActive(true);

        itemPopup.SetupPopup(itemData);
    }
}

using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    public ShopItemData shopItemData;   
    public ShopItemPopup shopItemPopup;

    public void OnItemClicked()
    {
        // Activate the purchase panel.
        shopItemPopup.gameObject.SetActive(true);

        // Pass both the data and this UI element's GameObject to the popup.
        shopItemPopup.SetupPopup(shopItemData, this.gameObject);
    }
}

using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    public ShopItemData shopItemData;   
    public ShopItemPopup shopItemPopup;

    // Function that handles when a player clicks on an item in the store. Opens
    // the item popup and populates it with the information of the clicked item.
    public void OnItemClicked()
    {
        shopItemPopup.gameObject.SetActive(true);
        shopItemPopup.SetupPopup(shopItemData, this.gameObject);
    }
}

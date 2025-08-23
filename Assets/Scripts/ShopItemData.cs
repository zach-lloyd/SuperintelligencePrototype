using UnityEngine;

// Allows for creating instances of ShopItemData as reusable asset files.
[CreateAssetMenu(fileName = "ShopItems", menuName = "Shop Items/Shop Item")]
public class ShopItemData : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    
    [TextArea] 
    public string itemDescription;

    [Header("Pricing")]
    public int itemPrice;
}

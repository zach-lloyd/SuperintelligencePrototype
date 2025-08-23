using UnityEngine;
using TMPro; 
using UnityEngine.UI;

// This function handles the popup window that appears if a player tries to purchase 
// an item but does not have enough funds to afford its price.
public class InsufficientFundsPopup : MonoBehaviour
{
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

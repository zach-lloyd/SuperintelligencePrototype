using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class InsufficientFundsPopup : MonoBehaviour
{
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI collectibleText;

    // Start is called before the first frame update
    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCollectibleText(PlayerInventory playerInventory)
    {
        int collectedCount = playerInventory.NumberOfCollectibles;
        int totalCollectibles = 14;
        collectibleText.text = $"{collectedCount}/{totalCollectibles}";
        StartCoroutine(DisplayForDuration(2f)); 
    }

    IEnumerator DisplayForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        collectibleText.text = ""; 
    }
}

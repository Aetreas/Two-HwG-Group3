using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip wispCollect;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        SoundFXManager.Instance.PlaySoundFXClip(wispCollect, transform, 0.2f);
        if (playerInventory != null)
        {
            playerInventory.Collected();
            gameObject.SetActive(false);
        }
    }
}

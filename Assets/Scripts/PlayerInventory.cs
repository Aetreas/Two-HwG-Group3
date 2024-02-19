using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectibles { get; private set; }

    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject door;

    public UnityEvent<PlayerInventory> OnCollected;

    [SerializeField] private AudioClip teleportActive;

    
    public void Collected()
    {
        NumberOfCollectibles++;
        OnCollected.Invoke(this);
    }

    void Update()
    {
        if (NumberOfCollectibles != 8)
        {
            teleporter.SetActive(false);
        }

        else
        {
            teleporter.SetActive(true);
        }

        if (NumberOfCollectibles != 14)
        {
            door.SetActive(false);
        }

        else
        {
            door.SetActive(true);
        }
    }

    public void teleportSound()
    {
        if (NumberOfCollectibles == 8)
        {
            SoundFXManager.Instance.PlaySoundFXClip(teleportActive, transform, 0.5f);

        }
    }

}

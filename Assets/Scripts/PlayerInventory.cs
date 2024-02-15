using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectibles { get; private set; }

    [SerializeField] GameObject teleporter;

    public UnityEvent<PlayerInventory> OnCollected;

    public void Collected()
    {
        NumberOfCollectibles++;
        OnCollected.Invoke(this);
    }

    void Update()
    {
        if (NumberOfCollectibles != 1)
        {
            teleporter.SetActive(false);
        }

        else
        {
            teleporter.SetActive(true);
        }
    }
}

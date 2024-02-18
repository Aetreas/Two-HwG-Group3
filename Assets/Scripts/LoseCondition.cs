using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{


    [SerializeField] GameObject player;
    [SerializeField] GameObject losetext;

    // Start is called before the first frame update
    void Start()
    {
        losetext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            player.SetActive(false);
            losetext.SetActive(true);
        }
    }
}

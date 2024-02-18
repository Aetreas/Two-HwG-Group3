using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Door : MonoBehaviour

{


   [SerializeField] GameObject player;
   [SerializeField] GameObject wintext;


    void Start()
    {
      wintext.SetActive(false);
    }

    void Update()
    {
        
    }


   private void OnTriggerEnter(Collider other)
   {
      wintext.SetActive(true);
      player.SetActive(false);
   }



}
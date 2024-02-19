using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Door : MonoBehaviour

{


   [SerializeField] GameObject player;
   [SerializeField] GameObject wintext;

   public string winScene;


    void Start()
    {
      wintext.SetActive(false);
    }

    void Update()
    {
        
    }


   private void OnTriggerEnter(Collider other)//player enters the door and triggers win scene
   {
      SceneManager.LoadScene(winScene);
   }



}
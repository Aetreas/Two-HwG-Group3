using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Teleporter : MonoBehaviour

{

   [SerializeField] Transform tp;

   [SerializeField] GameObject player;

   public bool teleportInput = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            teleportInput = true;
        }

        if (Input.GetButtonUp("Interact"))
        {
            teleportInput = false;
        }
    }


   private void OnTriggerStay(Collider other) {

    if(teleportInput == true)
    {
        StartCoroutine(Teleport());
    }

    

   }



   IEnumerator Teleport()

   {

       yield return new WaitForSeconds(1); //need some kind of delay in this form so player does not infinitely teleport

       player.transform.position = new Vector3(

           tp.transform.position.x,

           tp.transform.position.y,

           tp.transform.position.z

       );

   }

}
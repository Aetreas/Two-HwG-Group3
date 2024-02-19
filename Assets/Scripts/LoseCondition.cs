using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{


    [SerializeField] GameObject player;
    [SerializeField] GameObject losetext;

    public string loseScene;

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
            SceneManager.LoadScene(loseScene);
        }
    }
}

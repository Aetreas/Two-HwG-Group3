using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{


    [SerializeField] GameObject player;
    [SerializeField] GameObject losetext;
    [SerializeField] private AudioClip loseLaugh;
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
            SoundFXManager.Instance.PlaySoundFXClip(loseLaugh, transform, 0.2f);
        }
    }
}

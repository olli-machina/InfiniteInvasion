using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioClip start, gameplay;
    private AudioSource listener;
    private bool menuBool = false, gameplayBool = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        listener = GetComponent<AudioSource>();
        menuBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "SampleScene")
        {
            if (gameplayBool == true)
            {
                listener.clip = gameplay;
                listener.Play();
                gameplayBool = false;
                menuBool = true;
            }
        }

        else
        {
            if(menuBool == true)
            {
                listener.clip = start;
                listener.Play();
                menuBool = false;
                gameplayBool = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioClip start, gameplay;
    private AudioSource listener;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        listener = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "SampleScene")
        {
            listener.clip = gameplay;
            listener.Play();
        }

        else
        {
            listener.clip = start;
            listener.Play();
        }
    }
}

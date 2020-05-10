using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

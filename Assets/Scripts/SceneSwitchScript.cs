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
        SceneManager.LoadScene("CreditsScreen");
    }

    public void LoadHelp1()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void LoadHelp2()
    {
        SceneManager.LoadScene("HelpScene2");
    }

    public void LoadHelp3()
    {
        SceneManager.LoadScene("HelpScene3");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

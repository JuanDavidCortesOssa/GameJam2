using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{

    public GameObject instructionsPanel;

    public GameObject creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }


    public void openInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void closeInstructions()
    {
        instructionsPanel.SetActive(false);


    }

    public void openCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void closeCreditsPanel()
    {
        creditsPanel.SetActive(false);

    }

    public void exitGame()
    {
        Application.Quit();
    }

}

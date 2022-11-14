using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image oxygenImage;

    public GameObject pausePanel;
    public bool pauseResumeBool = true;
    public AudioListener playerListener;
    public GameObject finalStatsPanel;
    public TMP_Text totalScoreText;
    public TMP_Text totalTimeText;
    public TMP_Text scoreText;
    public bool oxygenBool = true;
  



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

    }


    private void Update()
    {
        if (oxygenBool)
        {
        oxygenImage.fillAmount -= 0.05f *Time.deltaTime;

        }

        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void lessOxygen()
    {
        oxygenImage.fillAmount = 1;
    }
 
    public void PauseGame()
    {
        if (pauseResumeBool)
        {
            Time.timeScale = 0f;
            playerListener.enabled = false;
            pausePanel.SetActive(true);
            pauseResumeBool = false;
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            pauseResumeBool = true;
            playerListener.enabled = true;


        }


    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator SetFinalStats()
    {

        print("Entro al metodo final stats");
        totalScoreText.text = scoreText.text;
        totalTimeText.text = "Total time: "+Timer.instance.timerText.text;
        Timer.instance.timerIsRunning = false;
        oxygenBool = false;
        yield return new WaitForSeconds(0.6f);
       
        finalStatsPanel.SetActive(true);

        yield return new WaitForSeconds(3f);
        ReturnToMenu();

    }





}

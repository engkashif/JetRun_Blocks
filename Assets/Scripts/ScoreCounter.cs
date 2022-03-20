using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public GameObject replayPanel;

    public GameObject pauseButton;

    public GameObject pausePanel;

    private int currentHighScore;

    //public GameObject revivePanel;

    public static int score = 0;
    //public static int numCoin = 0;

    public Text scoreCount;

    //public Transform player;
    //private float zCompare;
    //public float zValue;
    //public float inititalValue;

    //public static bool displayPanel;

    public AudioClip button_clip;
    public AudioSource button_source;

    public AudioSource rocket_source;
    public AudioSource background_source;

    void Start()
    {
        //zCompare = inititalValue;
        score = 0;
        scoreCount.text = "Score : " + score;
        //displayPanel = false;
    }


    public void DisplayFinalPanel()
    {
        rocket_source.Stop();
        background_source.Stop();
        StartCoroutine(Delay());
    }

    public void Replay_func()
    {
        button_source.PlayOneShot(button_clip);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu_func()
    {
        button_source.PlayOneShot(button_clip);
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        rocket_source.Stop();
        background_source.Stop();
        button_source.PlayOneShot(button_clip);
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        button_source.PlayOneShot(button_clip);
        background_source.Play();
        rocket_source.Play();
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReviveGame()
    {
        button_source.PlayOneShot(button_clip);
        background_source.Play();
        rocket_source.Play();
        pauseButton.SetActive(true);
        replayPanel.SetActive(false);
    }

    public void MainMenu_paused()
    {
        button_source.PlayOneShot(button_clip);
        Time.timeScale = 1f;

        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }


        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateScore()
    {
        scoreCount.text = "Score : " + score;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.0f);
        replayPanel.SetActive(true);
    }


}

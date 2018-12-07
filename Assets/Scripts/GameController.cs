using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float maxTime;
    float time;
    public Text timeText;
    int scoreA = 0;
    int scoreB = 0;
    public GameObject endUI;

    private void OnEnable()
    {
        if (timeText == null) GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        ResetTime();
    }

    void ResetTime()
    {
        time = maxTime;
    }

    private void Update()
    {
        if (time > 0) time -= Time.deltaTime;

        if (timeText == null) GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        if (timeText != null) timeText.text = "Time: " + Mathf.Round(time).ToString();

        if (time <= 0) ShowEndGame();
    }

    public void ShowEndGame()
    {
        endUI.SetActive(true);
    }

    public void GetPoint(int num)
    {
        if (num == 0) scoreA++;
        else scoreB++;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public float maxTime;
    [SerializeField]
    public bool started = false;
    [SerializeField]
    float time;
    public Text timeText;
    public GameObject timeObj;
    int scoreA = 0;
    int scoreB = 0;
    public GameObject endUI;
    public GameObject[] players;
    public GameObject[] turrets;

    //Customize tank colors
    public Sprite[] hullColors;
    public Sprite[] turretColors;
    public GameObject customizeColors;

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
        if (started)
        {
            if (time > 0) time -= Time.deltaTime;

            if (timeText == null) GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
            if (timeText != null) timeText.text = "Time: " + Mathf.Round(time).ToString();

            if (time <= 0) ShowEndGame();
        }
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

    public void StartGame()
    {
        customizeColors.SetActive(false);
        timeObj.SetActive(true);
        started = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeColorA(int num)
    {
        players[0].GetComponent<SpriteRenderer>().sprite = hullColors[num];
        turrets[0].GetComponent<SpriteRenderer>().sprite = turretColors[num];
    }

    public void ChangeColorB(int num)
    {
        players[1].GetComponent<SpriteRenderer>().sprite = hullColors[num];
        turrets[1].GetComponent<SpriteRenderer>().sprite = turretColors[num];
    }
}

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
    public int scoreA = 0;
    public int scoreB = 0;
    public GameObject endUI;
    public GameObject[] players;
    public GameObject[] turrets;

    //Customize tank colors
    public Sprite[] hullColors;
    public Sprite[] turretColors;
    public GameObject customizeColors;
    public Image TankA;
    public Image TurretA;
    public Image TankB;
    public Image TurretB;

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
        TankA.sprite = hullColors[num];
        TurretA.sprite = turretColors[num];
    }

    public void ChangeColorB(int num)
    {
        players[1].GetComponent<SpriteRenderer>().sprite = hullColors[num];
        turrets[1].GetComponent<SpriteRenderer>().sprite = turretColors[num];
        TankB.sprite = hullColors[num];
        TurretB.sprite = turretColors[num];
    }
}

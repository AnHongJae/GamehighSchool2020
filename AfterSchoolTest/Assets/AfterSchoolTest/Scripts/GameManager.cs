using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SpawnCube m_CubeSpawner;

    public int m_Life = 3;
    public int m_Score = 0;

    public Text ScoreUI;
    public Text TimeUi;
    public Text GameOverUI;
    public float time = 0;


    private void Start()
    {
        time = 30;
        GameOverUI.gameObject.SetActive(false);
    }


    private void Update()
    {
        time -= Time.deltaTime;
        TimeUi.text = "남은시간" + time;
        if (time < 0)
        {
            GameOverUI.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            ScoreUI.gameObject.SetActive(false);
        }

        ScoreUI.text = "SCORE: " + m_Score;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }




    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        m_CubeSpawner.SpawnStart();
    }

    public void AddTime()
    {
        time++;
    }
    public void AddScore()
    {
        m_Score++;
    }

    public void DamageLife()
    {
        m_Life--;
        if(m_Life <= 0)
        {
            GameOverUI.gameObject.SetActive(true);
            m_CubeSpawner.gameObject.SetActive(false);
        }
    }






}

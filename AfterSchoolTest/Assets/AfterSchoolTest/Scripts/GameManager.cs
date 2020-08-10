using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
            //GameOver;
        }
    }


}

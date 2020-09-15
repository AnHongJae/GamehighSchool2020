using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public List<ItemComponet> m_Items
        = new List<ItemComponet>();
    public bool m_IsPlaying;

    public static GameManager Instance;
    public void Awake()
    {
        if (GameManager.Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void Start()
    {
        m_Items.AddRange(FindObjectsOfType<ItemComponet>());


        m_ScoreUI.text
            = string.Format("SCORE:{0}", m_Score);
    }

    public bool m_IsGameOver = false;
    public GameObject m_GameOverUI;
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;


    public void OnplayerDead()
    {
        m_IsGameOver = true;
        m_GameOverUI.SetActive(true);
    }

    public void OnAddScore()
    {
        m_Score++;
        m_ScoreUI.text
            = string.Format("SCORE : {0} ", m_Score);
    }



    private void Update()
    {
        if (m_IsPlaying) return;

        bool result = true;
        foreach(var item in m_Items)
        {
            if (item != null)
                result = false;
        }
        if (result)
        {
            m_IsPlaying = false;
            GameClear();
        }


        if (m_IsGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TestLevel_Character");
        }
    }

    public void GameClear()
    {
        Debug.Log("GameClear");
    }



}


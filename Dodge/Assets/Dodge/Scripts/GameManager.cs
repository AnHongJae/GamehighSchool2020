﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    ////가장 간단한 싱글톤...;
    //public static GameManager instance;
    //void Awake()
    //{
    //    instance = this;
    //}

    public Text m_ScoreUI;
    public Text m_RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletSpawners;

    public bool m_IsPlaying;
    public float m_Score;

    private void Start()  //씬 시작시
    {
        GameStart();  //게임시작
    }

    // Update is called once per frame
    void Update()
    {
        //시간당 점수업
        if (m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }
        }
    }

    public void GameStart() //게임 시작되면 
    {
        //gameobject.Setactive() 게임오브젝트 비활서오하 기능 
        m_IsPlaying = true;
        m_Score = 0f;
        m_RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);

        for(int i=0; i<m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(true);
        }
    }

    public void GameOver()  //게임 오버가 되면
    {
        m_IsPlaying = false;   //플레이어 상태
        m_RestartUI.gameObject.SetActive(true);  //리스타트 UI 활성화
        m_PlayerController.gameObject.SetActive(false); //플레이어 비활성화
        //불랫 스포너들 비활성화

        for (int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(false);
        }
        //총알 제거
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);  //Destroy (게임오브젝트) 게임오브젝트를 제거한다.
        }
        //TopScore 키를 가지고 최고점 가지고 옴
        float topScore = PlayerPrefs.GetFloat("TopScore", 0);
        if (topScore < m_Score)  //현재 내가 낸 점수가 최고 기록보다 높으면
        {
            topScore = m_Score;  //내가 낸 점수로 최고를 변경
        }
        PlayerPrefs.SetFloat("TopScore", topScore); //TopScore에 최고점을 저장하고
        PlayerPrefs.Save(); //저장

        //최고점 표시
        m_RestartUI.text
            = string.Format("게임오버\n최고점 : {0}\n다시 시작하려면 R버튼 누르세요."
            , topScore);
    }
}

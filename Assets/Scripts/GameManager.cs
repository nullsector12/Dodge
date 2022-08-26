using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;

    private float _surviveTime;
    private bool _isGameOver;
    
    void Start()
    {
        _surviveTime = 0;
        _isGameOver = false;
    }
    
    void Update()
    {
        if (!_isGameOver)
        {
            _surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int) _surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        _isGameOver = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (_surviveTime > bestTime)
        {
            bestTime = _surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int) bestTime;
    }
}

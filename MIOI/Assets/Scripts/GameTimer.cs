using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float startTime = 3000f;
    private float currentTime;
    public Animator animator;

    public TMP_Text timerText;
    public GameObject loseScreen;
    private bool hasFinished = false;

    void Start()
    {
        currentTime = startTime;
        loseScreen.SetActive(false);
        if (timerText == null) 
        {
            Debug.LogError("TimerText is niet toegewezen in de inspector!");
        }

    }

    void Update()
    {
        if (!hasFinished)
        {
            //Debug.Log("before"+currentTime);
            currentTime -= Time.deltaTime;
            //Debug.Log("after"+currentTime);
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                currentTime = 0;
                EndGame();
            }
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = currentTime.ToString("F2");
    }

    void EndGame()
    {
        Debug.Log("Tijd is op! Het Spel Stopt.");
        animator.Play("Defeat");
        hasFinished = true;
        loseScreen.SetActive(true);
        Time.timeScale = 1f;
    }

    public void FinishGame()
    {
        Debug.Log("Finish bereikt!");
        hasFinished = true;
        Time.timeScale = 1f;
    }
}

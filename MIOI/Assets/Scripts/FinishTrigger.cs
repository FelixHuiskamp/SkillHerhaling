using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public GameTimer gameTimer;
    public GameObject finishUI;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            animator.Play("Victory");
            Time.timeScale = 1f;
            finishUI.SetActive(true);
            gameTimer.FinishGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

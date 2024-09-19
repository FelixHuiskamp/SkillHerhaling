using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public GameTimer gameTimer;
    public GameObject finishUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Finish Bereikt!!");
            Time.timeScale = 0f;
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

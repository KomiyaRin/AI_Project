using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject pausePanel;
    public void onStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void onExitButtClicked()
    {
        Application.Quit();
    }
    public void onRetryButtonClicked()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }
    /*public void onResumeButtonClicked()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        
        Cursor.lockState = CursorLockMode.Locked;
    }*/
    public void onMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

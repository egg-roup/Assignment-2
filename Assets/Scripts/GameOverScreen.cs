using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject gameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthManager.OnPlayerDied += GameOverScreenOn;
        gameOverScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    void GameOverScreenOn() {
        if (gameOverScreen != null) gameOverScreen.SetActive(true);
        if (gameUI != null) gameUI.SetActive(false);
    }

    public void RestartButton() {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Test");
    }

    public void QuitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        
    }
}

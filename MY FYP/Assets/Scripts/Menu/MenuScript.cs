using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour

{
    public GameObject pausemenuPanel;

    private bool isPaused = false;

    private void Start()
    {
        pausemenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausemenuPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SelectionWindow");
    }

    public void TrainingRoom()
    {
        SceneManager.LoadScene("TrainingRoom");
    }

    public void MatchRoom()
    {
        SceneManager.LoadScene("MatchRoom");
    }

    public void QuitGame()
    {
        Application.Quit();
    }





}
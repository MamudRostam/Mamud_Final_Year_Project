using UnityEngine;
using UnityEngine.SceneManagement;


public class MainGameCanvas : MonoBehaviour

{
    public GameObject PauseButtonPanel;
    public GameObject Crosshair;
    public GameObject OptionsPanel;

    private bool isPaused = false;

    private void Start()
    {
        PauseButtonPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        OptionsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        PauseButtonPanel.SetActive(isPaused);
        Crosshair.SetActive(!isPaused); 

        Time.timeScale = isPaused ? 0f : 1f;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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

    public void OpenOptions()
    {
        PauseButtonPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        PauseButtonPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }






}
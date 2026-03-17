using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{


    public GameObject selectionWindowPanel;

    public void StartGame()
    {
        if (selectionWindowPanel != null)
        {
            selectionWindowPanel.SetActive(true);
        }
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

    public void CloseSelection()
    {
        selectionWindowPanel.SetActive(false);
    }
}
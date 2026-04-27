using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject HowToPlayPanel;
    public GameObject selectionWindowPanel;
    public GameObject CreditsPanel;


    public void StartGame()
    {
        if (selectionWindowPanel != null)
        {
            selectionWindowPanel.SetActive(true);
        }
    }

    public void OpenHowToPlay()
    {
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(true);
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

    public void CloseHowToPlayPanel()
    {
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
    }

    public void OpenCreditsPanel()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(true);
        }
    }


    public void CloseCreditsPanel()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
        }
    }
}
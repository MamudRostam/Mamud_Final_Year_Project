using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
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
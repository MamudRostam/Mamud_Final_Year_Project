using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameCompleteUI;
    private int enemiesAlive;

    void Start()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
        gameCompleteUI.SetActive(false);
    }

    public void EnemyKilled()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            GameComplete();
        }
    }

    void GameComplete()
    {
        Audiomanager.instance.PlayGameComplete();

        Time.timeScale = 0f;
        gameCompleteUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        var canvas = FindFirstObjectByType<MainGameCanvas>();
        if (canvas != null)
        {
            canvas.isGameOver = true;
        }
    }
}

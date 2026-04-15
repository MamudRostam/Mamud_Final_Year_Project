using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameCompleteUI;
    private int enemiesAlive;

    void Start()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
        gameCompleteUI.SetActive(true);
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
        Time.timeScale = 0f;
        gameCompleteUI.SetActive(true);
    }
}

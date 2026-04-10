using UnityEngine;

public class SpawnerButton : MonoBehaviour
{
    public EnemySpawner[] spawners;

    void OnMouseDown()
    {
        if (spawners == null || spawners.Length == 0) return;

        foreach (EnemySpawner spawner in spawners)
        {
            spawner.ToggleSpawner();
        }

        Debug.Log("Button Toggled!");
    }
}

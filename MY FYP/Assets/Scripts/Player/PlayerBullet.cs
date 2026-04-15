using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAI enemy = collision.gameObject.GetComponentInParent<EnemyAI>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

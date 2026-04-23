using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 50f;

    public void Fire()
    {

        Audiomanager.instance.PlayPlayerShoot();

        if(Time.timeScale == 0f) return;

        if (bulletPrefab == null || spawnPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * bulletSpeed;
        }
    }
}

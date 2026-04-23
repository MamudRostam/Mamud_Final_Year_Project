using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 50f;

    public void Fire()
    {
       
        if (Time.timeScale == 0f) return;

        if (bulletPrefab == null || spawnPoint == null) return;

        if (Audiomanager.instance != null)
        {
            Audiomanager.instance.PlayPlayerShoot();
        }

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * bulletSpeed;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Shooting : MonoBehaviour
{
    public float firerate = 3f;
    public float bulletshootingtime = 0;
    public GameObject bulletprefab;

    private bool shootingEnabled = false;

    [SerializeField]
    private AudioSource Shoot;

    void Update()
    {
        bulletshootingtime -= Time.deltaTime;
        if (bulletshootingtime <= 0)
        {
            shootingEnabled = true;
        }

        if(Input.GetKey(KeyCode.Space) && shootingEnabled)
        {
            shoot();
            shootingEnabled =false;
        }

    }

    private void shoot()
    {
        if(Shoot != null)
        {
            Shoot.Play();
        }

        float timeuntilshoot = 1f / firerate;
        bulletshootingtime = timeuntilshoot;
        GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
    }
}

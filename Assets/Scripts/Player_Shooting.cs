using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public float firerate = 3f;
    public float bulletshootingtime = 2;
    public GameObject bulletprefab;

    private bool shootingEnabled = false;

    // Update is called once per frame
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
        float timeuntilshoot = 1f / firerate;
        bulletshootingtime = timeuntilshoot;
        GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
    }
}

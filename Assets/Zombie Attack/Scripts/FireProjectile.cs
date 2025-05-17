using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletActiveTime = 3;
    public float bulletPower = 10;

    public GameObject firepoint;

    public float maxAmmo = 200;
    public TextMeshProUGUI ammoText;
    public float reloadTime = 3f;
    private float ammoCount;

    void Start()
    {
        ammoCount = maxAmmo;
        ammoText.text = $"Ammo: {ammoCount}";
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            BulletScript bulletScript = bullet.GetComponent<BulletScript>();
            FireBullet(bulletScript);
            ammoText.text = $"Ammo: {ammoCount}";
            ammoCount -= 1;

        }
        if(ammoCount == 0)
        {
            StartCoroutine(Reloading());
        }

        // LESSON 3-4: Add code below.
    }

    private void FireBullet(BulletScript bullet)
    {
        bullet.transform.position = firepoint.transform.position;
        bullet.FireBullet(this.transform.forward, bulletPower);
    }

    public IEnumerator Reloading()
    {
        ammoText.text = "Be Patient I Need Some Rest";

        yield return new WaitForSeconds(reloadTime);

        ammoCount = maxAmmo;
        ammoText.text = $"Ammo:{ammoCount}";
    }
}

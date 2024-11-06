using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShoot : MonoBehaviour
{

    [SerializeField] Rigidbody2D bullet;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] float bulletSpeed;
    [SerializeField] Rigidbody2D referenceVelocity;

    [SerializeField] int ammo;
    [SerializeField] private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, bulletSpawnPos.position, transform.rotation);
            Debug.Log(referenceVelocity.velocity);

            bulletClone.velocity = transform.right * bulletSpeed;
            bulletClone.velocity = new Vector2 (referenceVelocity.velocity.x + bulletClone.velocity.x, referenceVelocity.velocity.y + bulletClone.velocity.y);
            //bulletClone.velocity = (transform.right * bulletSpeed);
            ammo--;
        }

        if (ammo == 0 && !reloading)
        {
            Debug.Log("reload");
            ReloadGun();
        }
    }

    private IEnumerator ReloadGun()
    {
        reloading = true;
        yield return new WaitForSeconds(2);
        reloading = false;
        ammo = 4;
    }
}

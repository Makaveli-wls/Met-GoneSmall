using UnityEngine;
using System.Collections;

public class Singleshot : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 5f;
    public float range = 100f;
    public int currentAmmo;
    public int maxAmmo = 7;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reloaded");
    }

    void Shoot()
    {
        RaycastHit hit;
        currentAmmo--;
         Debug.Log("Ammo: " + currentAmmo);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range));
        {
            

        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SingleShot : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 5f;
    public float range = 100f;
    public int currentAmmo =1;
    public int maxAmmo = 7;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public TMP_Text ammoDisplay;

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

        ammoDisplay.text = currentAmmo.ToString();

        if (Input.GetKeyDown("r") && (currentAmmo < maxAmmo))
        {
            StartCoroutine(Reload());
            return;
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
